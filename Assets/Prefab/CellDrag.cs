using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using AudioHelm;
using System.Text.RegularExpressions;

public class CellDrag : MonoBehaviour
{
    public RawImage img;
    public Color gridCellColor;
    public GameObject synthSequencer;

    public int startCell;
    public int startStep;
    public int dragCellCount = 0;
    public int itemOne;
    public int itemTwo;

    string myString;//string with your numbers
    public int[] myNumbers;
    int number;
    
    public GameObject tempStartCell;

    public AudioHelm.Note noteTemp;	
    bool flag = false;
    PointerEventData mousePos;

	private string m_MyVar = null;
	public string MyVar
	{
		get {return m_MyVar;}
		set {
			if (m_MyVar == value) return;
			m_MyVar = value;
			if (OnVariableChange != null)
				OnVariableChange(m_MyVar);
		}
	}
	public delegate void OnVariableChangeDelegate(string newVal);
	public event OnVariableChangeDelegate OnVariableChange;	    

    public static bool PointerIsOverUI(Vector2 screenPos)
    {
        var hitObject = UIRaycast(ScreenPosToPointerData(screenPos));
        return hitObject != null && hitObject.layer == LayerMask.NameToLayer("UI");
    }
    
    static GameObject UIRaycast (PointerEventData pointerData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
    
        return results.Count < 1 ? null : results[0].gameObject;
    }
    
    static PointerEventData ScreenPosToPointerData (Vector2 screenPos)
        => new(EventSystem.current){position = screenPos};


    // Start is called before the first frame update
    void Start()
    {
        gridCellColor = img.GetComponent<RawImage>().color;
        synthSequencer = GameObject.Find("SynthSequencer");
        this.GetComponent<CellDrag>().OnVariableChange += VariableChangeHandler;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = ScreenPosToPointerData(Input.mousePosition);
    }
	
    private void VariableChangeHandler(string newVal) {
        dragCellCount++;
    }   

    public void MouseClick() {
        if (this.GetComponent<RawImage>().color == Color.red) {
            this.GetComponent<RawImage>().color = gridCellColor;
            UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);      
            noteTemp = synthSequencer.GetComponent<HelmSequencer>().GetNoteInRange(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);           
            synthSequencer.GetComponent<HelmSequencer>().RemoveNotesInRange(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);            
            for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                GameObject.Find("Row_"+DecodeStringRow().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                GameObject.Find("Row_"+DecodeStringRow().ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().effectDistance = new Vector2(1, -1);
            }
            return;
        } 
        else {          
            this.GetComponent<RawImage>().color = Color.red;
            synthSequencer.GetComponent<HelmSequencer>().AddNote(108-DecodeStringRow(), DecodeStringStep(), DecodeStringStep()+1);          
        }     
    }

    public void MouseDragBegin() {
        UIRaycast(mousePos).GetComponent<RawImage>().color = Color.red; 
        UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(1, -1);        		
        startStep = DecodeStringStep();
        tempStartCell = UIRaycast(mousePos);
    }

    public void MouseDragLength() {      
        if(Input.GetAxis("Mouse X") > 0) {
            UIRaycast(mousePos).GetComponent<RawImage>().color = Color.red; 
            UIRaycast(mousePos).GetComponent<Outline>().effectDistance = new Vector2(0, -1);  
            MyVar = UIRaycast(mousePos).name; 
        }    
		if(Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse Y") < 0 || Input.GetAxis("Mouse Y") > 0 ) {
			return;
		}            
    }   

    public void MouseDragEnd() {    
        if (UIRaycast(mousePos).GetComponent<RawImage>().color != Color.red) {
            return;
        }    
        synthSequencer.GetComponent<HelmSequencer>().AddNote(108-DecodeStringRow(), startStep, startStep+dragCellCount);
        tempStartCell.GetComponent<Outline>().effectDistance = new Vector2(1, -1);       
        ResetDragCount();
    }    

    public void ResetDragCount() {
        dragCellCount = 0;
    }    
    
    int DecodeStringRow(){
        string nameCell = UIRaycast(mousePos).name;
        string numbersOnly = Regex.Replace(nameCell, "[^0-9]", " ");        
        string[] stringArray = numbersOnly.Split(" "[0]);//Split myString wherever there's a " " and make a string array out of it.
        myNumbers = new int[stringArray.Length];
        for(int num = 0; num < stringArray.Length; num++) {
            if (int.TryParse(stringArray[num], out number)) {
                myNumbers[num] = int.Parse(stringArray[num]);
            }
        } 
        int row = myNumbers[4];
        return row;  
    } 

    int DecodeStringStep(){
        string nameCell = UIRaycast(mousePos).name;
        string numbersOnly = Regex.Replace(nameCell, "[^0-9]", " ");        
        string[] stringArray = numbersOnly.Split(" "[0]);//Split myString wherever there's a " " and make a string array out of it.
        myNumbers = new int[stringArray.Length];
        for(int num = 0; num < stringArray.Length; num++) {
            if (int.TryParse(stringArray[num], out number)) {
                myNumbers[num] = int.Parse(stringArray[num]);
            }
        } 
        int step = myNumbers[5];
        return step;  
    }     
}
