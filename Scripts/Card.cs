using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private bool alreadyUsed;
    private Vector3 tamanho = new Vector3(1.0f, 1.0f, 1.0f);
    private Vector3 posicao;
    public string cardType;
    public Enemy enemy;
    public GameObject person;
    public Player player;
    public Text turnText;

    //Audio
    public AudioClip turnoInimigo;
    public AudioSource sound;

    void Start()
    {
        
    }

    public void OnMouseEnter()
    {
        if (Time.timeScale != 0)
        {

            this.gameObject.transform.position += Vector3.up * 2;
            this.gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);

        }

    }


    public void onMouseExit()
    {

        if (Time.timeScale != 0)
        {

            this.gameObject.transform.position = posicao;
            this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }
    }

    public void OnMouseDown()
    {
        if (Time.timeScale != 0 && player.getPlayerTurn() == true && enemy != null)
        {

            this.gameObject.transform.position = posicao;
            this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            //ATAQUE
            if(cardType == "ataque"){
              person.GetComponent<Animator>().SetTrigger("atacou");
              //2 de dano
              if(this.gameObject.name == "Card1"){
                if(player.getMagia()){
                    enemy.takeDamage(18*2);
                    player.setMagia(false);
                }else{
                    enemy.takeDamage(18);
                }
                if(player.getDefesa()){
                    player.setDefesa(false);
                }
                if(player.getBotas()){
                    player.setBotas(false);
                }
              }else if(this.gameObject.name == "Card3"){
                //3 de dano
                 if(player.getMagia()){
                    enemy.takeDamage(22*2);
                    player.setMagia(false);
                }else{
                    enemy.takeDamage(22);
                }
                if(player.getDefesa()){
                     player.setDefesa(false);
                }
                if(player.getBotas()){
                    player.setBotas(false);
                }
              }else if(this.gameObject.name == "Card4"){
                //6 de dano
                if(player.getMagia()){
                    enemy.takeDamage(30*2);
                    player.setMagia(false);
                }else{
                    enemy.takeDamage(30);
                }
                if(player.getDefesa()){
                    player.setDefesa(false);
                }
                if(player.getBotas()){
                    player.setBotas(false);
                }
              }
            //MAGIA
            }else if(cardType == "magia"){
                person.GetComponent<Animator>().SetTrigger("buff");
                if(this.gameObject.name == "Card6"){
                    player.setMagia(true);
                }
                if(player.getDefesa()){
                    player.setDefesa(false);
                }
                if(player.getBotas()){
                    player.setBotas(false);
                }
            //DEFESA
            }else if(cardType == "defesa"){
                person.GetComponent<Animator>().SetTrigger("defesa");
                if(this.gameObject.name == "Card7"){
                    player.setBotas(true);
                    if(player.getDefesa()){
                        player.setDefesa(false);
                    }
                    if(player.getMagia()){
                        player.setMagia(false);
                    }
                }else if(this.gameObject.name == "Card5"){
                    player.setDefesa(true);
                    if(player.getBotas()){
                        player.setBotas(false);
                    }
                    if(player.getMagia()){
                        player.setMagia(false);
                    }
                }
            //ATAQUE2
            }else if(cardType == "ataque2"){
                person.GetComponent<Animator>().SetTrigger("atacou2");
                //2 de dano
                if(this.gameObject.name == "Card2"){
                if(player.getMagia()){
                    enemy.takeDamage(16*2);
                    player.setMagia(false);
                }else{
                    enemy.takeDamage(16);
                }
                if(player.getDefesa()){
                    player.setDefesa(false);
                }
                if(player.getBotas()){
                    player.setBotas(false);
                }
              }
            }
            setUsed(true);
            player.setPlayerTurn(false);
            enemy.setEnemyTurn(true);

            if(PlayerPrefs.GetInt("Blind") == 1){
            sound.PlayOneShot(turnoInimigo);
            }

            turnText.text = "Enemy's Turn";
            this.gameObject.SetActive(false);
        }
    }

    public bool getUsed()
    {
        return this.alreadyUsed;
    }

    public void setUsed(bool alreadyUsed)
    {
        this.alreadyUsed = alreadyUsed;
    }

    public void setType(string cardType)
    {
        this.cardType = cardType;
    }

    public string getType()
    {
        return this.cardType;
    }

    public void setPosicao(Vector3 posicao)
    {
        this.posicao = posicao;
    }

    public Vector3 getPosicao()
    {
        return this.posicao;
    }

}
