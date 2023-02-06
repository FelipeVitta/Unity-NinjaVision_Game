using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    void Start()
    {
        
    }

    public void onClick(string nomecena){
        SceneManager.LoadScene(nomecena);
    }
   
}
