using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class config : MonoBehaviour

{
    public Button buttonPause;
    public GameObject screenConfig;
    private bool isPause;
    // Start is called before the first frame update
    void Start()
    {

    }

     void Update() {

        if(screenConfig.activeSelf == true){
            isPause = true;
        }else{
            isPause = false;
        }

        if(isPause){
            Pause();
        }else{
            Unpause();
        }
    }

    void Pause(){
        Time.timeScale = 0;
        isPause = true;
    }

    void Unpause(){
        Time.timeScale = 1;
        isPause = false;
    }
    public void onClick(){

        buttonPause.interactable = false;
        screenConfig.SetActive(true);
        Pause();

    }

    public void close(){
        
        buttonPause.interactable = true;
        screenConfig.SetActive(false);
        Unpause();

    }

  
}
