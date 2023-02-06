using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickPlay : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelMap;
    public Image imagem;
    private Color myColor;

    void Start()
    {
        myColor = imagem.color;
    }

    public void clickPlay()
    {
        panelMenu.SetActive(false);
        panelMap.SetActive(true);
    }

    public void clickX()
    {
        imagem.color = myColor;
        panelMenu.SetActive(true);
        panelMap.SetActive(false);
    }

}
