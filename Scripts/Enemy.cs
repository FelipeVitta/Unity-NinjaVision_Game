using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //DecisionTree
    DecisionTree dt = new DecisionTree(7, 4);

    public Text turnText;
    public Transform healthBar; //barra verde
    private Vector3 sizeBar; //tamanho da barra

    public GameObject barraDeVida;

    //ATRIBUTOS
    public int vidaTotal;
    public int ataqueMedio;
    public int ataqueForte;
    private int vidaAtual;
    private float percentualVida;
    public Animator animator;  

    //PLAYER INSTANCE
    public Player player;

    //STATUS ATUAL
    private static bool pocaoDefesa;
    private static bool pocaoAtaque;

    //TURNO
    private static bool enemyTurn;

    //audio
    public AudioClip suaVez;
    public AudioClip ataque;
    public AudioClip defesa;
    public AudioClip forca;

    void Start()
    {
        if(PlayerPrefs.GetInt("Blind") == 1){
            sound.PlayOneShot(suaVez);
        }
        setEnemyTurn(false);
        setPocaoAtaque(false);
        setPocaoDefesa(false);
        vidaAtual = vidaTotal;
        sizeBar = healthBar.localScale;
        percentualVida = sizeBar.x / vidaTotal;
        trainingEnemy(dt);
    }

    void updateHealthBar()
    {
        sizeBar.x = percentualVida * vidaAtual;
        healthBar.localScale = sizeBar;
        if(vidaAtual <= 0){
            barraDeVida.SetActive(false);
        }
    }

    public AudioClip damage;
    public AudioSource sound;

    public void takeDamage(int danoRecebido)
    {
        if(pocaoDefesa){
            vidaAtual = vidaAtual - danoRecebido/2;
            StartCoroutine(wait());
        }else{
            vidaAtual = vidaAtual - danoRecebido;
            StartCoroutine(wait());
        }
    }

     IEnumerator wait(){
        sound.PlayOneShot(damage);
        yield return new WaitForSeconds(2);
        animator.SetTrigger("hurt");
        updateHealthBar();
    }

    IEnumerator die(){
        animator.GetComponent<Animator>().SetTrigger("morto");
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaAtual <= 0){
            setEnemyTurn(false);
            StartCoroutine(die());           
        }else if(vidaAtual > 0 && getEnemyTurn() == true){
            setEnemyTurn(false);
            StartCoroutine(attack());
        } 
    }

    IEnumerator attack(){
        yield return new WaitForSeconds(3);
        double[] atributos = player.getAtributes();
         int predClass = dt.Predict(atributos, verbose: true);
         //ataque médio
         if(predClass == 0){
            if(PlayerPrefs.GetInt("Blind") == 1){
            sound.PlayOneShot(ataque);
            }
            animator.SetTrigger("enemyAttack");
            if(pocaoAtaque){
             player.takeDamage(ataqueMedio*2); 
             setPocaoAtaque(false);             
           }else{
            player.takeDamage(ataqueMedio); 
           } 
           if(pocaoDefesa){
            setPocaoDefesa(false);
           }                     
         //ataque forte
         }else if(predClass == 1){
            if(PlayerPrefs.GetInt("Blind") == 1){
            sound.PlayOneShot(ataque);
            }
            animator.SetTrigger("enemyAttack");
            if(pocaoAtaque){
             player.takeDamage(ataqueForte*2); 
             setPocaoAtaque(false); 
            }else{
            player.takeDamage(ataqueForte);
            } 
            if(pocaoDefesa){
                setPocaoDefesa(false);
            }       
         //poção defesa   
         }else if(predClass == 2){
            if(PlayerPrefs.GetInt("Blind") == 1){
            sound.PlayOneShot(defesa);
            }
            animator.SetTrigger("enemyDefense");
            setPocaoDefesa(true);
            if(pocaoAtaque){
                setPocaoAtaque(false);
            }
         //poção ataque
         }else if(predClass == 3){
            if(PlayerPrefs.GetInt("Blind") == 1){
            sound.PlayOneShot(forca);
            }
            animator.SetTrigger("enemyDefense");
            setPocaoAtaque(true);
            if(pocaoDefesa){
                setPocaoDefesa(false);
            }
         }
        
        StartCoroutine(changeTurn());

    }

    IEnumerator changeTurn(){
        yield return new WaitForSeconds(2);
        if(PlayerPrefs.GetInt("Blind") == 1){
            sound.PlayOneShot(suaVez);
        }
        turnText.text = "Your Turn";
        player.setPlayerTurn(true);
    }


    public int getVidaAtual(){
        return this.vidaAtual;
    }

    public void trainingEnemy(DecisionTree dt){

      double[][] dataX = new double[40][];
      //magia_inimigo(0sem, 1ataque, 2defesa),forca_player(0,1) defesa_player(0nenhuma, 1clone, 2bota), vida_player(0-3)

      dataX[0] = new double[] {0.0, 0.0, 2.0, 1.0 };  // 0 -> ataque médio
      dataX[1] = new double[] {1.0, 0.0, 1.0, 2.0 };
      dataX[2] = new double[] {2.0, 1.0, 0.0, 0.0 };
      dataX[3] = new double[] {0.0, 0.0, 2.0, 2.0 };
      dataX[4] = new double[] {0.0, 1.0, 0.0, 1.0 };
      dataX[5] = new double[] {2.0, 0.0, 1.0, 1.0 };
      dataX[6] = new double[] {1.0, 1.0, 0.0, 0.0 };
      dataX[7] = new double[] {0.0, 0.0, 1.0, 2.0 };
      dataX[8] = new double[] {0.0, 0.0, 0.0, 2.0 };
      dataX[9] = new double[] {2.0, 1.0, 1.0, 1.0 };

      dataX[10] = new double[] {0.0, 1.0, 0.0, 3.0 };  // 1 -> ataque forte
      dataX[11] = new double[] {2.0, 1.0, 0.0, 1.0 };
      dataX[12] = new double[] {0.0, 0.0, 0.0, 2.0 };
      dataX[13] = new double[] {1.0, 0.0, 0.0, 3.0 };
      dataX[14] = new double[] {1.0, 1.0, 0.0, 3.0 };
      dataX[15] = new double[] {0.0, 0.0, 2.0, 2.0 };
      dataX[16] = new double[] {1.0, 1.0, 0.0, 2.0 };
      dataX[17] = new double[] {0.0, 0.0, 1.0, 1.0 };
      dataX[18] = new double[] {0.0, 1.0, 0.0, 1.0 };
      dataX[19] = new double[] {1.0, 0.0, 0.0, 2.0 };

      dataX[20] = new double[] {0.0, 1.0, 0.0, 3.0 };   // 2 -> pocao defesa
      dataX[21] = new double[] {0.0, 1.0, 0.0, 3.0 };
      dataX[22] = new double[] {0.0, 1.0, 2.0, 2.0 };
      dataX[23] = new double[] {0.0, 1.0, 0.0, 3.0 };
      dataX[24] = new double[] {0.0, 1.0, 1.0, 1.0 };
      dataX[25] = new double[] {0.0, 1.0, 0.0, 0.0 };
      dataX[26] = new double[] {0.0, 1.0, 0.0, 2.0 };
      dataX[27] = new double[] {0.0, 1.0, 0.0, 1.0 };
      dataX[28] = new double[] {0.0, 1.0, 0.0, 0.0 };
      dataX[29] = new double[] {0.0, 1.0, 1.0, 3.0 };

      dataX[30] = new double[] {0.0, 0.0, 1.0, 3.0};   // 3 -> pocao ataque
      dataX[31] = new double[] {0.0, 1.0, 2.0, 2.0}; 
      dataX[32] = new double[] {0.0, 0.0, 0.0, 3.0};
      dataX[33] = new double[] {0.0, 1.0, 1.0, 2.0};
      dataX[34] = new double[] {0.0, 0.0, 0.0, 1.0};
      dataX[35] = new double[] {0.0, 0.0, 2.0, 3.0};
      dataX[36] = new double[] {0.0, 0.0, 1.0, 2.0};
      dataX[37] = new double[] {0.0, 0.0, 1.0, 2.0};
      dataX[38] = new double[] {0.0, 0.0, 0.0, 1.0};
      dataX[39] = new double[] {0.0, 1.0, 2.0, 3.0};


      int[] dataY = 
        new int[40] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                      1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                      2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 
                      3, 3, 3, 3, 3, 3, 3, 3, 3, 3,};
                      
      dt.BuildTree(dataX, dataY);

    }


    public void setEnemyTurn(bool tur){
        enemyTurn = tur;
    }
    public bool getEnemyTurn(){
        return enemyTurn;
    }

    public void setPocaoDefesa(bool def){
        pocaoDefesa = def;
    }

    public void setPocaoAtaque(bool atk){
        pocaoAtaque = atk;
    }

    public bool getPocaoDefesa(){
        return pocaoDefesa;
    }

    public bool getPocaoAtaque(){
        return pocaoAtaque;
    }

    public int getVidaTotal(){
        return this.vidaTotal;
    }


}
