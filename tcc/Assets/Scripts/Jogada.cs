using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using static System.Console;
using System.Diagnostics;

public class Jogada : MonoBehaviour
{
    public Jogada(){}
    public string emocao;
    public string data;
    public int pontos;
    public string emocaoEscolida;
    
    public Jogada(string emocao, string data, int pontos, string emocaoEscolida)
    {
    	this.emocao = emocao;
    	this.data = data;
    	this.pontos = pontos;
        this.emocaoEscolida = emocaoEscolida;
	    
    }
    
    
}
