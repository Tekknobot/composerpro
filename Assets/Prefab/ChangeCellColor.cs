using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class ChangeCellColor : MonoBehaviour
{
    public RawImage img;
    public Color gridCellColor;
    public GameObject drumSampler;
    bool flag = false;

    void Start() {
        gridCellColor = img.GetComponent<RawImage>().color;
        drumSampler = GameObject.Find("DrumSampler");
    }

    public void ChangeColorToRed() {
        if (this.GetComponent<RawImage>().color == Color.red) {
            RemoveNotesFromDrumSequencer(this.gameObject);
            img.GetComponent<RawImage>().color = gridCellColor;             
        }
        else {
            for (int i = 0; i < drumSampler.GetComponent<SampleSequencer>().length; i++) {
                img.GetComponent<RawImage>().color = Color.red;
                
                if (GameObject.Find("KICK "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(60, i, i+1);
                }     
                if (GameObject.Find("SNARE "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(61, i, i+1);
                } 
                if (GameObject.Find("CHAT "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(62, i, i+1);
                } 
                if (GameObject.Find("OHAT "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(63, i, i+1);
                } 
                if (GameObject.Find("CLAP "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(64, i, i+1);
                } 
                if (GameObject.Find("CRASH "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(65, i, i+1);
                } 
                if (GameObject.Find("RIDE "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(66, i, i+1);
                } 
                if (GameObject.Find("RIM "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                    drumSampler.GetComponent<SampleSequencer>().AddNote(67, i, i+1);
                }                                                                   
            } 
            PlayDrumRoll();           
        }
    }

    public void ChangeColorBack() {
        img.GetComponent<RawImage>().color = gridCellColor;
        flag = false;
    }    

    public void RemoveNotesFromDrumSequencer(GameObject cell) {
        for (int i = 0; i < drumSampler.GetComponent<SampleSequencer>().length; i++) {        
            if (cell.name == "KICK "+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(60, i, i+1);
            }   
            if (cell.name == "SNARE "+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(61, i, i+1);
            } 
            if (cell.name == "CHAT "+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(62, i, i+1);
            }   
            if (cell.name == "OHAT "+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(63, i, i+1);
            }     
            if (cell.name == "CLAP "+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(64, i, i+1);
            }   
            if (cell.name == "CRASH "+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(65, i, i+1);
            }     
            if (cell.name == "RIDE "+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(66, i, i+1);
            }   
            if (cell.name == "RIM "+ i.ToString()) {
                drumSampler.GetComponent<SampleSequencer>().RemoveNotesInRange(67, i, i+1);
            }                                                              
        }         
    }

    public void PlayDrumRoll() {
        for (int i = 0; i < drumSampler.GetComponent<SampleSequencer>().length; i++) {
            if (GameObject.Find("DrumNote "+ i.ToString()).GetComponent<RawImage>().color == Color.red) {
                drumSampler.GetComponent<Sampler>().NoteOn(67-i);
            }     
        }                        
    }    
}
