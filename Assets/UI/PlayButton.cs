using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPause() {
        GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause = !GameObject.Find("AudioHelmClock").GetComponent<AudioHelm.AudioHelmClock>().pause;
    }
}
