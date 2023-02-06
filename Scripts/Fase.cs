using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase 
{
    private string nome;
    private int peso;
    private string[] sucessores;
    private Fase predecessor;
    private bool marcado;
    private int acumulado;

    public Fase(string nome, int peso, string[] sucessores)
    {
        this.nome = nome;
        this.peso = peso;
        this.sucessores = sucessores;
    }

     public string getNomePredecessor(){
        return predecessor.getNome();
    }
    public void setPredecessor(Fase predecessor){
        this.predecessor = predecessor;
    }

    public void setMarcado(bool marcado){
        this.marcado = marcado;
    }

    public void setAcumulado(int acumulado){
        this.acumulado = acumulado;
    }

    public void setNome(string nome){
        this.nome = nome;
    }

    public void setPeso(int peso){
        this.peso = peso;
    }

    public void setSucessores(string[] sucessores){
        this.sucessores = sucessores;
    } 

    public Fase getPredecessor(){
        return this.predecessor;
    }

    public bool getMarcado(){
        return this.marcado;
    }

    public int getAcumulado(){
        return this.acumulado;
    }

    public string getNome(){
        return this.nome;
    }

    public int getPeso(){
        return this.peso;
    }

    public string[] getSucessores(){
        return this.sucessores;
    }


}
