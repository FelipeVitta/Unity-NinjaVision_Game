using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightImage : MonoBehaviour
{
    public Image image;
    public Color myColor;
    private Color imageColor;
    public AudioSource audo;
    public AudioClip bomp;

    //0->imagemInicio 1->tundra 2->jardim 3->arvoredo 4->labirinto 5->rospea 6->afoiteza
    public GameObject locked;

    
    void Start()
    {
         imageColor = image.color;
    }

    public void onHigh(){
        if(!locked.activeSelf){
            image.color = myColor;
            audo.PlayOneShot(bomp);
        }
    }

    public void onExit(){
        if(!locked.activeSelf){
            image.color = imageColor;
        }
    }

    public void onHighMargens(){
        image.color = myColor;
        audo.PlayOneShot(bomp);    
    }

    public void onHighFirst(){
        image.color = myColor;
        audo.PlayOneShot(bomp);
    }

     public void onExitFirst(){
            image.color = imageColor;
        
    }



    

}
