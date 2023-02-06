using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Dijkstra : MonoBehaviour
{
    public string origem;
    public string destino;
    public Text txt;

    public GameObject locked;
    List<Fase> listaFases = new List<Fase>(){
        new Fase("afoiteza_vulcanica", 10, new string[]{}),
        new Fase("arvoredo_sagrado", 4, new string[]{"afoiteza_vulcanica"}),
        new Fase("labirinto_abismal", 7, new string[]{"afoiteza_vulcanica"}),
        new Fase("rospea", 5, new string[]{"afoiteza_vulcanica"}),
        new Fase("jardim_sem_voz", 3, new string[]{"rospea","labirinto_abismal"}),
        new Fase("tundra_amarela", 2, new string[]{"labirinto_abismal","arvoredo_sagrado"}),
        new Fase("margens_turbulentas", 1, new string[]{"jardim_sem_voz","tundra_amarela"})
    };

    private Fase getByName(string nome)
    {
        return this.listaFases.FirstOrDefault(z => z.getNome() == nome);
    }

    public void writeText()
    {
        string actual = destino;
        string a = "";
        while (true)
        {
            if (actual == origem)
            {
                break;
            }
            else
            {
                a = string.Concat("-", getByName(actual).getNome(), "\n", a);
                actual = getByName(actual).getNomePredecessor();
            }
        }
        a = "caminho mais facil:" + "\n" + a.Replace("_", " ");
        txt.text = a;

    }

    public void onSaida()
    {
        txt.text = "";
    }

    public void OnMouseEnter()
    {
        if (!locked.activeSelf)
        {
            Fase h = new Fase(" ", 0, new string[] { });
            foreach (Fase x in listaFases)
            {
                x.setAcumulado(1000);
                x.setMarcado(false);
                x.setPredecessor(h);
            }

            Fase atual = getByName(origem);
            atual.setAcumulado(0);

            List<Fase> listaChecar = new List<Fase>();

            foreach (string x in atual.getSucessores())
            {
                listaChecar.Add(getByName(x));
            }

            Fase suc, faf;

            while (listaChecar.Count >= 1)
            {
                atual.setMarcado(true);
                foreach (string x in atual.getSucessores())
                {
                    suc = getByName(x);
                    if (suc.getMarcado() != true)
                    {
                        if (atual.getAcumulado() + suc.getPeso() < suc.getAcumulado())
                        {
                            suc.setAcumulado(atual.getAcumulado() + suc.getPeso());
                            suc.setPredecessor(atual);
                        }
                    }
                }

                atual = lessAcumulate();
                listaChecar.Remove(atual);
                if (atual.getSucessores().Length >= 1)
                {
                    foreach (string x in atual.getSucessores())
                    {
                        faf = getByName(x);
                        if (faf.getMarcado() != true)
                        {
                            listaChecar.Add(faf);
                        }
                    }
                }

            }

            writeText();


            Fase lessAcumulate()
            {
                List<int> array = new List<int>();

                foreach (Fase x in listaChecar)
                {
                    array.Add(x.getAcumulado());
                }

                int menor = array.Min();
                return listaChecar.FirstOrDefault(z => z.getAcumulado() == menor);

            }
        }

    }

}



