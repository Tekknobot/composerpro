using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioHelm;

public class LengthSlider : MonoBehaviour
{
    Slider mySlider = null;
    public GameObject seqBarContent;
    public GameObject synthSeqBarContent;
    public GameObject drumContent;
    public GameObject synthContent;

    public GameObject saveManager;
    public Toggle playButton;
 
    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();
        mySlider.value = 1;
        StartCoroutine(WaitFor());
    }
 
    public void UpdateSlider()
    {
        if (mySlider.value == 1) {
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length = 16;
            GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().length = 16;
            seqBarContent.GetComponent<PopulateSeqBar>().PopulateBar(16);
            drumContent.GetComponent<PopulateGrid>().PopulateGridFunction(16);
            drumContent.GetComponent<GridLayoutGroup>().constraintCount = 16;

            synthSeqBarContent.GetComponent<PopulateSeqBar>().PopulateSynthBar(16);
            synthContent.GetComponent<PopulateGrid_Synth>().rowCount = -1;
            synthContent.GetComponent<PopulateGrid_Synth>().PopulateSynthGridFunction(16);
            synthContent.GetComponent<GridLayoutGroup>().constraintCount = 16;

            StartCoroutine(saveManager.GetComponent<SaveManager>().LoadDrumNotesIntoSeq());
            StartCoroutine(saveManager.GetComponent<SaveManager>().LoadNotesIntoSeq());
            playButton.isOn = false;
        }
        if (mySlider.value == 2) {
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length = 32;
            GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().length = 32;
            seqBarContent.GetComponent<PopulateSeqBar>().PopulateBar(32);
            drumContent.GetComponent<PopulateGrid>().PopulateGridFunction(32);
            drumContent.GetComponent<GridLayoutGroup>().constraintCount = 32;

            synthSeqBarContent.GetComponent<PopulateSeqBar>().PopulateSynthBar(32);
            synthContent.GetComponent<PopulateGrid_Synth>().rowCount = -1;
            synthContent.GetComponent<PopulateGrid_Synth>().PopulateSynthGridFunction(32);
            synthContent.GetComponent<GridLayoutGroup>().constraintCount = 32;

            StartCoroutine(saveManager.GetComponent<SaveManager>().LoadDrumNotesIntoSeq());
            StartCoroutine(saveManager.GetComponent<SaveManager>().LoadNotesIntoSeq());
            playButton.isOn = false;
        }
        if (mySlider.value == 3) {
            GameObject.Find("SynthSequencer").GetComponent<AudioHelm.HelmSequencer>().length = 64;
            GameObject.Find("DrumSampler").GetComponent<AudioHelm.SampleSequencer>().length = 64;
            seqBarContent.GetComponent<PopulateSeqBar>().PopulateBar(64);
            drumContent.GetComponent<PopulateGrid>().PopulateGridFunction(64);
            drumContent.GetComponent<GridLayoutGroup>().constraintCount = 64;

            synthSeqBarContent.GetComponent<PopulateSeqBar>().PopulateSynthBar(64);
            synthContent.GetComponent<PopulateGrid_Synth>().rowCount = -1;
            synthContent.GetComponent<PopulateGrid_Synth>().PopulateSynthGridFunction(64);   
            synthContent.GetComponent<GridLayoutGroup>().constraintCount = 64;     

            StartCoroutine(saveManager.GetComponent<SaveManager>().LoadDrumNotesIntoSeq());
            StartCoroutine(saveManager.GetComponent<SaveManager>().LoadNotesIntoSeq());   
            playButton.isOn = false;            
        }                                    
    }

    IEnumerator WaitFor() {
        yield return new WaitForSeconds(0.1f);
        UpdateSlider();
    }
}
