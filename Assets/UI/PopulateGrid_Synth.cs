using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid_Synth : MonoBehaviour
{
    public GameObject cell;
    public int numberToCreate = 16;
    public int groupTotal = 7;
    public string noteName;
    int rowCount = -1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < groupTotal; i++) {
            PopulateWhiteRow();
            PopulateWhiteRow();
            PopulateBlackRow();
            PopulateWhiteRow();
            PopulateBlackRow();
            PopulateWhiteRow();
            PopulateBlackRow();
            PopulateWhiteRow();                        
            PopulateWhiteRow();
            PopulateBlackRow();
            PopulateWhiteRow();
            PopulateBlackRow();                        
        }
    }

    void PopulateWhiteRow() {
        GameObject newObj;
        rowCount++;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(cell, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f); 
            newObj.name = noteName+rowCount+"_"+i;                                                      
        } 
    }   

    void PopulateBlackRow() {
        GameObject newObj;
        rowCount++;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(cell, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);   
            newObj.name = noteName+rowCount+"_"+i;                                                      
        } 
    }                               
}
