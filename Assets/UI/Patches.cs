using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using TMPro;

public class Patches : MonoBehaviour
{
    public GameObject synthSequencer;
    public AudioHelm.HelmPatch[] patches;
    public GameObject patchLabel;
    public int patchNumber = 0;
    TextMeshProUGUI textmeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GameObject.Find("PatchName").GetComponent<TextMeshProUGUI>();
        synthSequencer.GetComponent<HelmController>().LoadPatch(patches[patchNumber]);
        textmeshPro.text = patches[patchNumber].name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextPatchData () {     
        patchNumber++;     
        if (patchNumber >= 162) {
            patchNumber = 162;
        }            
        textmeshPro.text = patches[patchNumber].name;
        synthSequencer.GetComponent<HelmController>().LoadPatch(patches[patchNumber]);	          
    }

    public void LoadPreviousPatchData () {	
        patchNumber--;        
        if (patchNumber <= 0) {
            patchNumber = 0;
        }         
        textmeshPro.text = patches[patchNumber].name;
        synthSequencer.GetComponent<HelmController>().LoadPatch(patches[patchNumber]);       
    }    
}
