using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralVolume : MonoBehaviour
{
    public Slider volumeSlider;
    void Start()
    {
        if (!PlayerPrefs.HasKey("generalVolume"))
        {
            PlayerPrefs.SetFloat("generalVolume", 1);
            Load();
        }else{
            volumeSlider.value = AudioListener.volume;
            Load();
        }

    }

    private void Load(){
        AudioListener.volume = PlayerPrefs.GetFloat("generalVolume");
    }

    public void Save(){
        PlayerPrefs.SetFloat("generalVolume", volumeSlider.value);
    }

    public void changeVolume(){
        AudioListener.volume = volumeSlider.value;
        Save();
    }


}
