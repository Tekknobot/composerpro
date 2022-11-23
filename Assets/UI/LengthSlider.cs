using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LengthSlider : MonoBehaviour
{
    Slider mySlider = null;
 
    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();
    }
 
    public void UpdateSlider()
    {
        if (mySlider.value == 1) {
            GameObject.Find("HelmSequencer").GetComponent<AudioHelm.HelmSequencer>().length = 16;
            GameObject.Find("DrumSequencer").GetComponent<AudioHelm.SampleSequencer>().length = 16;
        }
        if (mySlider.value == 2) {
            GameObject.Find("HelmSequencer").GetComponent<AudioHelm.HelmSequencer>().length = 32;
            GameObject.Find("DrumSequencer").GetComponent<AudioHelm.SampleSequencer>().length = 32;
        }
        if (mySlider.value == 3) {
            GameObject.Find("HelmSequencer").GetComponent<AudioHelm.HelmSequencer>().length = 64;
            GameObject.Find("DrumSequencer").GetComponent<AudioHelm.SampleSequencer>().length = 64;
        }
        if (mySlider.value == 4) {
            GameObject.Find("HelmSequencer").GetComponent<AudioHelm.HelmSequencer>().length = 128;
            GameObject.Find("DrumSequencer").GetComponent<AudioHelm.SampleSequencer>().length = 128;
        }   
        if (mySlider.value == 5) {
            GameObject.Find("HelmSequencer").GetComponent<AudioHelm.HelmSequencer>().length = 256;
            GameObject.Find("DrumSequencer").GetComponent<AudioHelm.SampleSequencer>().length = 256;
        }
        if (mySlider.value == 6) {
            GameObject.Find("HelmSequencer").GetComponent<AudioHelm.HelmSequencer>().length = 512;
            GameObject.Find("DrumSequencer").GetComponent<AudioHelm.SampleSequencer>().length = 512;
        }                                      
    }
}
