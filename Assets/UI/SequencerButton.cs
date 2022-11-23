using UnityEngine;
using TMPro;

public class SequencerButton : MonoBehaviour
{
    public int sequencer = 0;
    public GameObject drum;
    public GameObject synth;

    TextMeshProUGUI textmeshPro;

    // Start is called before the first frame update
    void Start()
    {   
        drum.SetActive(true);
        synth.SetActive(false);  
        textmeshPro = GameObject.Find("SequencerButtonText").GetComponent<TextMeshProUGUI>();
        textmeshPro.text = "DRUM SEQ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SequencerButtonElement() {
        if (sequencer == 0) {
            drum.SetActive(true);
            synth.SetActive(false);    
            textmeshPro.text = "DRUM SEQ";
            sequencer = 1;
            
        }
        else if (sequencer == 1) {
            drum.SetActive(false);
            synth.SetActive(true);           
            textmeshPro.text = "SYNTH SEQ";
            sequencer = 0;
        }        
    }
}