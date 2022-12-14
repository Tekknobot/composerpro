using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;
using UnityEngine.UI;

public class SequencerPos : MonoBehaviour
{
    public GameObject drumSeqeuncer;
    public GameObject synthSequencer;
    public GameObject sampleSequencer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("SQPOS "+ drumSeqeuncer.GetComponent<SampleSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        GameObject.Find("SQPOS_SYNTH "+ synthSequencer.GetComponent<HelmSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
        GameObject.Find("SQPOS_SAMPLE "+ sampleSequencer.GetComponent<SampleSequencer>().currentIndex.ToString()).GetComponent<RawImage>().color = Color.yellow;
    }
}
