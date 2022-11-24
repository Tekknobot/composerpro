using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;
using TMPro;

public class PopulatePianoRoll_Labels : MonoBehaviour
{
    public GameObject prefab;
    public int numberToCreate = 12;
    public int numberOfGroups = 10;

    public string noteName = "Label_";
    int totalNotes = -1;

    TextMeshProUGUI textmeshPro;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfGroups; i++) {
            PopulateRoll(noteName);
        }
    }

    void Update() {
        
    }

    void PopulateRoll(string noteName) {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            totalNotes++;
            newObj = (GameObject)Instantiate(prefab, transform);
            if (i == 0) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "C7"; 
            }  
            if (i == 1) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "B6";                  
            }    
            if (i == 2) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "A#6";                   
            }    
            if (i == 3) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "A6";                  
            }    
            if (i == 4) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "G#6";                   
            }    
            if (i == 5) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "G6";                  
            }    
            if (i == 6) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "F#6";                  
            }    
            if (i == 7) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "F6";  
            }  
            if (i == 8) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "E6";                    
            }     
            if (i == 9) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "D#6";     
            }   
            if (i == 10) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "D6";                 
            }    
            if (i == 11) {
                newObj.name = noteName+ totalNotes.ToString();
                textmeshPro = GameObject.Find(newObj.name).GetComponent<TextMeshProUGUI>();
                textmeshPro.text = "C#6";    
            }                                                                                                                                                                                                   
        }
    }                             
}
