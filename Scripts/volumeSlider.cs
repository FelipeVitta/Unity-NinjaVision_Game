using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeSlider : MonoBehaviour

{
    public Slider slider;
    public AudioSource song;
    
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume", 0.3F);
            Load();
        }else{
            slider.value = song.volume;
            Load();
        }
    }

    public void changeVolume(){
        song.volume = slider.value;
        Save();
    }

    public void Save(){
        PlayerPrefs.SetFloat("musicVolume", slider.value);
    }

    private void Load(){
        slider.value = PlayerPrefs.GetFloat("musicVolume");
        song.volume = slider.value;
    }

  
   
}
