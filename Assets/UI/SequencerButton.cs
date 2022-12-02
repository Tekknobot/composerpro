using UnityEngine;
using TMPro;

public class SequencerButton : MonoBehaviour
{
    public int sequencer = 0;
    public GameObject drum;
    public GameObject synth;
    public GameObject saveManager;
    TextMeshProUGUI textmeshPro;

    // Start is called before the first frame update
    void Start()
    {   
        drum.SetActive(true);
        synth.SetActive(true);
        StartCoroutine(saveManager.GetComponent<SaveManager>().LoadDrumNotesIntoSeq());  
        StartCoroutine(saveManager.GetComponent<SaveManager>().LoadNotesIntoSeq());
        textmeshPro = GameObject.Find("SequencerButtonText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = "DRUM SEQ";
        RectTransform synthRectTransform = synth.GetComponent<RectTransform>();
        synthRectTransform.localPosition = new Vector3(0, 500, 0);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SequencerButtonElement() {
        if (sequencer == 0) {
            drum.transform.SetSiblingIndex(1);
            textmeshPro.text = "SYNTH SEQ";
            RectTransform synthRectTransform = synth.GetComponent<RectTransform>();
            synthRectTransform.localPosition = new Vector3(0, 0, 0);            
            sequencer = 1;
            
        }
        else if (sequencer == 1) {
            drum.transform.SetSiblingIndex(-1);
            textmeshPro.text = "DRUM SEQ";
            RectTransform synthRectTransform = synth.GetComponent<RectTransform>();
            synthRectTransform.localPosition = new Vector3(0, 500, 0);            
            sequencer = 0;
        }        
    }
}