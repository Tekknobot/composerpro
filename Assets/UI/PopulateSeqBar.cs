using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateSeqBar : MonoBehaviour
{
    public GameObject prefab;
    public int numberToCreate = 16;

    // Start is called before the first frame update
    void Start()
    {
        PopulateBar();
    }

    void PopulateBar() {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.name = "SQPOS "+ i.ToString();                                                        
        }
    }                           
}
