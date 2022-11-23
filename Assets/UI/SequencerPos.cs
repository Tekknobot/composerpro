using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;

public class SequencerPos : MonoBehaviour
{
    public GameObject drumSeqeuncer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < drumSeqeuncer.GetComponent<SampleSequencer>().length; i++) {
            if (drumSeqeuncer.GetComponent<SampleSequencer>().currentIndex == i && GameObject.Find("SQPOS "+ i.ToString())) {
                GameObject.Find("SQPOS "+ i.ToString()).GetComponent<RawImage>().color = Color.yellow;
            }
            else if (drumSeqeuncer.GetComponent<SampleSequencer>().currentIndex != i && GameObject.Find("SQPOS "+ i.ToString())) {
                GameObject.Find("SQPOS "+ i.ToString()).GetComponent<RawImage>().color = new Color(0.3f, 0.3f, 0.3f);
            }
        }
    }
}
