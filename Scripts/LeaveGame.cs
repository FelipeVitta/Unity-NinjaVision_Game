using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void sairJogo(){
        PlayerPrefs.DeleteAll();  
        Application.Quit();
    }
    
}
