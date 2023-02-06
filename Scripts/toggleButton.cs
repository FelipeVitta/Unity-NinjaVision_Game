using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleButton : MonoBehaviour
{
    public GameObject toggle;
    void Start(){

     if(PlayerPrefs.HasKey("Blind")){
        if(PlayerPrefs.GetInt("Blind") == 0){
            toggle.GetComponent<Toggle>().isOn = false;
        }else if(PlayerPrefs.GetInt("Blind") == 1){
            toggle.GetComponent<Toggle>().isOn = true;
        }
     }else{
        PlayerPrefs.SetInt("Blind",0);
        toggle.GetComponent<Toggle>().isOn = false;
     }   
     
    }
    // Start is called before the first frame update
    public void checkValue(){

        if(toggle.GetComponent<Toggle>().isOn){
            PlayerPrefs.SetInt("Blind",1);
        }else{
            PlayerPrefs.SetInt("Blind",0);
        }
    }
}
