using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveProgress : MonoBehaviour
{
    public GameObject[] margensSetas = new GameObject[2];
    public GameObject[] tundraSetas = new GameObject[2];
    public GameObject[] jardimSetas = new GameObject[2];
    public GameObject arvoredoSeta;
    public GameObject labirintoSeta;
    public GameObject rospeaSeta;

    //0=tundra  1=jardim  2=rospea  3=labirinto  4=arvoredo  5=afoiteza
    public GameObject[] cadeados = new GameObject[6];

    void Start()
    {
        // PlayerPrefs.SetInt("Margens_Turbulentas",0);
        // PlayerPrefs.SetInt("Tundra_Amarela",0);
        // PlayerPrefs.SetInt("Jardim_Sem_Voz",0);
        // PlayerPrefs.SetInt("Rospea",0);
        // PlayerPrefs.SetInt("Arvoredo_Sagrado",0);
        // PlayerPrefs.SetInt("Labirinto_Abismal",0);

        if(PlayerPrefs.HasKey("Margens_Turbulentas")){
            if(PlayerPrefs.GetInt("Margens_Turbulentas") == 1){
                foreach(GameObject x in margensSetas){
                    x.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                }
                cadeados[0].SetActive(false);
                cadeados[1].SetActive(false);
            }
        }else{
            PlayerPrefs.SetInt("Margens_Turbulentas",0);
        }
        //Tundra Amarela
        if(PlayerPrefs.HasKey("Tundra_Amarela")){
            if(PlayerPrefs.GetInt("Tundra_Amarela") == 1){
                foreach(GameObject x in tundraSetas){
                    x.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                }
                cadeados[3].SetActive(false);
                cadeados[4].SetActive(false);
            }
        }else{
            PlayerPrefs.SetInt("Tundra_Amarela",0);
        }
        //Jardim Sem Voz
        if(PlayerPrefs.HasKey("Jardim_Sem_Voz")){
            if(PlayerPrefs.GetInt("Jardim_Sem_Voz") == 1){
                foreach(GameObject x in jardimSetas){
                    x.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                }
                cadeados[2].SetActive(false);
                cadeados[3].SetActive(false);
            }
        }else{
            PlayerPrefs.SetInt("Jardim_Sem_Voz",0);
        }

        //Arvoredo Sagrado
        if(PlayerPrefs.HasKey("Arvoredo_Sagrado")){
            if(PlayerPrefs.GetInt("Arvoredo_Sagrado") == 1){      

                arvoredoSeta.GetComponent<Image>().color = new Color(255, 255, 255, 255);               
                cadeados[5].SetActive(false);

            }
        }else{
            PlayerPrefs.SetInt("Arvoredo_Sagrado",0);
        }
        //Labirinto Abismal
        if(PlayerPrefs.HasKey("Labirinto_Abismal")){
            if(PlayerPrefs.GetInt("Labirinto_Abismal") == 1){      

                labirintoSeta.GetComponent<Image>().color = new Color(255, 255, 255, 255);               
                cadeados[5].SetActive(false);
            }
        }else{
            PlayerPrefs.SetInt("Labirinto_Abismal",0);
        }
        //Rospea
        if(PlayerPrefs.HasKey("Rospea")){
            if(PlayerPrefs.GetInt("Rospea") == 1){      

                rospeaSeta.GetComponent<Image>().color = new Color(255, 255, 255, 255);               
                cadeados[5].SetActive(false);

            }
        }else{
            PlayerPrefs.SetInt("Rospea",0);
        }

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
