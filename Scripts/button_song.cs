using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class button_song : MonoBehaviour
{
    public AudioClip hoverSound;
    public AudioSource mySong;
 
    public void overButton(){
        mySong.PlayOneShot(hoverSound);
    }
  
}
