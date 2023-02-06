using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform healthBar; //barra verde
    private Vector3 sizeBar; //tamanho da barra
    public GameObject barraDeVida;
    public int vidaTotal;
    private float percentualVida;

    //ATRIBUTOS 
    private int vidaAtual;
    private static bool magia;
    private static bool defesa;
    private static bool botas;

    //É OU NÃO O TURNO DO JOGADOR
    private static bool playerTurn;
    //DAMAGE SOUND
    public AudioClip damage;
    public AudioSource sound;

    //Enemy
    public Enemy enemy;

    void Start()
    {
        setBotas(false);
        setMagia(false);
        setDefesa(false);
        setPlayerTurn(true);

        vidaAtual = vidaTotal;
        sizeBar = healthBar.localScale;
        percentualVida = sizeBar.x / vidaTotal;
    }

    void updateHealthBar()
    {
        sizeBar.x = percentualVida * vidaAtual;
        healthBar.localScale = sizeBar;
        if(vidaAtual <= 0){
            barraDeVida.SetActive(false);
        }
    }
    //sombra = chance de evitar proximo ataque
    //botas = limita a quantidade de dano do adversário
    public void takeDamage(int danoRecebido)
    {
        if (botas)
        {
            vidaAtual = vidaAtual - (danoRecebido/2) + 5;
        }
        else if (defesa)
        {
            int random = Random.Range(0, 10);
            if (random > 4)
            {
                vidaAtual = vidaAtual - danoRecebido;
            }
        }else{

            vidaAtual = vidaAtual - danoRecebido;

        }
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        sound.PlayOneShot(damage);
        yield return new WaitForSeconds(2);
        updateHealthBar();
    }

    void Update()
    {

    }

    public void setPlayerTurn(bool turn)
    {
        playerTurn = turn;
    }

    public void setMagia(bool mag)
    {
        magia = mag;
    }

    public void setBotas(bool bot)
    {
        botas = bot;
    }

    public void setDefesa(bool def)
    {
        defesa = def;
    }

    public bool getMagia()
    {
        return magia;
    }

    public bool getBotas()
    {
        return botas;
    }

    public bool getDefesa()
    {
        return defesa;
    }

    public int getVidaAtual()
    {
        return this.vidaAtual;
    }

    public bool getPlayerTurn()
    {
        return playerTurn;
    }

    public double[] getAtributes()
    {

        double magia_enemy = 0.0;
        double defesa_player = 0.0;
        double forca_player = 0.0;
        double vida = 0.0;

        //VIDA PLAYER
        if (vidaAtual >= 1 && vidaAtual < 100)
        {
            vida = 0.0;
        }
        else if (vidaAtual >= 100 && vidaAtual < 170)
        {
            vida = 1.0;
        }
        else if (vidaAtual >= 170 && vidaAtual < 250)
        {
            vida = 2.0;
        }
        else if (vidaAtual >= 250)
        {
            vida = 3.0;
        }

        //MAGIA ATUAL DO INIMIGO
        if (enemy.getPocaoAtaque() == true)
        {
            magia_enemy = 1.0;
        }
        else if (enemy.getPocaoDefesa() == true)
        {
            magia_enemy = 2.0;
        }

        //POÇÃO DE FORÇA PLAYER
        if (getMagia() == true)
        {
            forca_player = 1.0;
        }

        //TIPO DE DEFESA PLAYER
        if (getDefesa() == true)
        {
            defesa_player = 1.0;
        }
        else if (getBotas() == true)
        {
            defesa_player = 2.0;
        }

        double[] atributos = new double[] { magia_enemy, forca_player, defesa_player, vida };
        return atributos;
    }


}
