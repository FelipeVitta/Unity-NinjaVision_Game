using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Card[] cards = new Card[7];
    public Transform[] slots;
    private Card[] randomCards = new Card[4];
    private int handCounter;
    public static GameManager instance;
    public GameObject potionImage;
    public GameObject sheidImage;
    public GameObject bootsImage;

    //EFEITO INIMIGO

    public GameObject defesaInimigo;
    public GameObject pocaoInimigo;
    public GameObject text;
    public Player player;
    public Enemy enemy;
    public Text textTurn;

    //o jogador morreu?
    private bool playerDie;

    void Start()
    {
        playerDie = false;
        DrawCard();

    }

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        handCounter = 0;
        for (int i = 0; i < randomCards.Length; i++)
        {
            if (!randomCards[i].getUsed())
            {
                handCounter++;
            }
        }
        if (handCounter == 0)
        {
            DrawCard();
        }

        if (enemy != null)
        {
            if (enemy.getPocaoAtaque())
            {
                pocaoInimigo.SetActive(true);
            }
            else
            {
                pocaoInimigo.SetActive(false);
            }

            if (enemy.getPocaoDefesa())
            {
                defesaInimigo.SetActive(true);
            }
            else
            {
                defesaInimigo.SetActive(false);
            }

        }
        if (player.getMagia())
        {
            potionImage.SetActive(true);
        }
        else
        {
            potionImage.SetActive(false);
        }

        if (player.getBotas())
        {
            bootsImage.SetActive(true);
        }
        else
        {
            bootsImage.SetActive(false);
        }

        if (player.getDefesa())
        {
            sheidImage.SetActive(true);
        }
        else
        {
            sheidImage.SetActive(false);
        }

        if (enemy == null && !text.activeSelf)
        {
            StartCoroutine(winText());
        }
        if (player.getVidaAtual() <= 0 && playerDie == false)
        {
            playerDie = true;
            StartCoroutine(youLose());
        }
    }

    IEnumerator youLose()
    {
        yield return new WaitForSeconds(3);
        text.SetActive(true);
        text.GetComponent<Text>().text = "you lose";
        StartCoroutine(backToMapLose());
    }

    IEnumerator backToMapLose()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator winText()
    {
        textTurn.text = "";
        yield return new WaitForSeconds(1);
        text.SetActive(true);
        StartCoroutine(backToMap());
    }

    IEnumerator backToMap()
    {
        if (SceneManager.GetActiveScene().name == "Margens_Turbulentas")
        {
            PlayerPrefs.SetInt("Margens_Turbulentas", 1);
        }
        else if (SceneManager.GetActiveScene().name == "Labirinto_Abismal")
        {
            PlayerPrefs.SetInt("Labirinto_Abismal", 1);
        }
        else if (SceneManager.GetActiveScene().name == "Rospea")
        {
            PlayerPrefs.SetInt("Rospea", 1);
        }
        else if (SceneManager.GetActiveScene().name == "Arvoredo_Sagrado")
        {
            PlayerPrefs.SetInt("Arvoredo_Sagrado", 1);
        }
        else if (SceneManager.GetActiveScene().name == "Jardim_Sem_Voz")
        {
            PlayerPrefs.SetInt("Jardim_Sem_Voz", 1);
        }
        else if (SceneManager.GetActiveScene().name == "Tundra_Amarela")
        {
            PlayerPrefs.SetInt("Tundra_Amarela", 1);
        }

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }



    private void DrawCard()
    {
        List<int> lista = new List<int>();
        int randomNumber;
        for (int i = 0; i < randomCards.Length; i++)
        {
            do
            {
                randomNumber = Random.Range(0, cards.Length);
            } while (lista.Contains(randomNumber));
            lista.Add(randomNumber);
            randomCards[i] = cards[randomNumber];
            randomCards[i].transform.position = slots[i].position;
            randomCards[i].setPosicao(slots[i].position);
            randomCards[i].gameObject.SetActive(true);
            randomCards[i].setUsed(false);
        }

    }


}
