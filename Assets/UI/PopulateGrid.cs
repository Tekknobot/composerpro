using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;
    public GameObject sequencerIndexObject;
    public int numberToCreate = 16;

    // Start is called before the first frame update
    void Start()
    {
        PopulateRow1();
        PopulateRow2();
        PopulateRow3();
        PopulateRow4();
        PopulateRow5();
        PopulateRow6();
        PopulateRow7();
        PopulateRow8();
    }

    void PopulateRow1() {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);  
            newObj.name = "DrumRow_0_"+ i.ToString();                                                      
        }
    }

    void PopulateRow2() {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);   
            newObj.name = "DrumRow_1_"+ i.ToString();                                                      
        }
    }

    void PopulateRow3() {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            newObj.name = "DrumRow_2_"+ i.ToString();                                                         
        }
    }

    void PopulateRow4() {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            newObj.name = "DrumRow_3_"+ i.ToString();                                                         
        }
    }

    void PopulateRow5() {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f);  
            newObj.name = "DrumRow_4_"+ i.ToString();                                                       
        }
    }

    void PopulateRow6() {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);  
            newObj.name = "DrumRow_5_"+ i.ToString();                                                       
        }
    }

    void PopulateRow7() {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.5f, 0.5f, 0.5f); 
            newObj.name = "DrumRow_6_"+ i.ToString();                                                        
        }
    }    

    void PopulateRow8() {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<RawImage>().color = new Color(0.7f, 0.7f, 0.7f);
            newObj.name = "DrumRow_7_"+ i.ToString();                                                         
        }
    }                              
}
