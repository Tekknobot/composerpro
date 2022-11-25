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
    public int dragCellCount = 0;
    public int itemOne;
    public int itemTwo;

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
        string nameCell = UIRaycast(mousePos).name;
        string numbersOnly = Regex.Replace(nameCell, "[^0-9]", "");
        int numCell = int.Parse(numbersOnly);
        itemOne = (numCell % 1000) / 10;
        itemTwo = numCell % 10;
                    
        if (this.GetComponent<RawImage>().color == Color.red) {
            this.GetComponent<RawImage>().color = gridCellColor;
            GetComponent<Outline>().enabled = true;      
            noteTemp = synthSequencer.GetComponent<HelmSequencer>().GetNoteInRange(108-itemOne, itemTwo, itemTwo+1);           
            synthSequencer.GetComponent<HelmSequencer>().RemoveNotesInRange(108-itemOne, itemTwo, itemTwo+1);            
            for (int k = 0; k < (noteTemp.end_ - noteTemp.start_); k++) { 
                GameObject.Find("Row_"+itemOne.ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<RawImage>().color = gridCellColor;
                GameObject.Find("Row_"+itemOne.ToString()+"_"+(noteTemp.start_+k).ToString()).GetComponent<Outline>().enabled = true; 
            }
            return;
        } 
        else {          
            this.GetComponent<RawImage>().color = Color.red;
            synthSequencer.GetComponent<HelmSequencer>().AddNote(108-itemOne, itemTwo, itemTwo+1);        
            Debug.Log(itemOne +" "+ itemTwo);   
        }     
    }

    public void MouseDragBegin() {		
        string nameCell = UIRaycast(mousePos).name;
		string numbersOnly = Regex.Replace(nameCell, "[^0-9]", "");
		int numCell = int.Parse(numbersOnly);
        itemOne = (numCell % 1000) / 10;
        itemTwo = numCell % 10;      
        Debug.Log(itemOne +" "+ itemTwo);
    }

    public void MouseDragLength() {
        UIRaycast(mousePos).GetComponent<RawImage>().color = Color.red; 
        UIRaycast(mousePos).GetComponent<Outline>().enabled = false;  
        MyVar = UIRaycast(mousePos).name;     
    }   

    public void MouseDragEnd() {        
        synthSequencer.GetComponent<HelmSequencer>().AddNote(108-itemOne, itemTwo, itemTwo+dragCellCount);
        Debug.Log("DC " + dragCellCount);
        ResetDragCount();
    }    

    public void ResetDragCount() {
        dragCellCount = 0;
    }    
}
