using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using static System.Console;
using System.Diagnostics;
using TMPro;
using System.IO;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;


public class DadosJogo : MonoBehaviour
{
    public System.Random ran = new System.Random();
    public GameObject jogada;
    private Jogada Jogada;
    public List<Jogada> jogadas01;
    public List<Jogada> jogadas02;
    public List<Jogada> jogadas03;
    public List<Jogada> jogadas;
    string emocao, data;
    int pontos;
    private int felicidade, tristeza, medo, surpresa, raiva, nojo;
    public int jogado;
    private int cont_felicidade, cont_tristeza, cont_medo, cont_surpresa, cont_raiva, cont_nojo;
    private int acerto_felicidade, acerto_tristeza, acerto_medo, acerto_surpresa, acerto_raiva, acerto_nojo;
    private int erro_felicidade, erro_tristeza, erro_medo, erro_surpresa, erro_raiva, erro_nojo;
    private TextMeshProUGUI Ret_felicidade, Ret_tristeza, Ret_medo, Ret_surpresa, Ret_raiva, Ret_nojo;
    private TextMeshProUGUI Acerto_felicidade, Acerto_tristeza, Acerto_medo, Acerto_surpresa, Acerto_raiva, Acerto_nojo;
    private TextMeshProUGUI Erro_felicidade, Erro_tristeza, Erro_medo, Erro_surpresa, Erro_raiva, Erro_nojo;
    public GameObject ret_felicidade, ret_tristeza, ret_medo, ret_surpresa, ret_raiva, ret_nojo;
    public GameObject acert_felicidade, acert_tristeza, acert_medo, acert_surpresa, acert_raiva, acert_nojo;
    public GameObject err_felicidade, err_tristeza, err_medo, err_surpresa, err_raiva, err_nojo, cenas;
    private ScriptNomesCenas Cenas;
    public int[] geradorRosto, erros;
    private int percent = 120;
    string ArquivoJogo1 =  Path.Combine("jogo1.txt");
    string ArquivoJogo2 =  Path.Combine("jogo2.txt");
    string ArquivoJogo3 =  Path.Combine("jogo3.txt");
    public int total;
    private int peso = 10;


    void Start()
    {
        Ret_felicidade = ret_felicidade.GetComponent<TextMeshProUGUI>();
        Ret_tristeza = ret_tristeza.GetComponent<TextMeshProUGUI>();
        Ret_medo = ret_medo.GetComponent<TextMeshProUGUI>();
        Ret_surpresa = ret_surpresa.GetComponent<TextMeshProUGUI>();
        Ret_raiva = ret_raiva.GetComponent<TextMeshProUGUI>();
        Ret_nojo = ret_nojo.GetComponent<TextMeshProUGUI>();

        Acerto_felicidade = acert_felicidade.GetComponent<TextMeshProUGUI>();
        Acerto_tristeza = acert_tristeza.GetComponent<TextMeshProUGUI>();
        Acerto_medo = acert_medo.GetComponent<TextMeshProUGUI>();
        Acerto_surpresa = acert_surpresa.GetComponent<TextMeshProUGUI>();
        Acerto_raiva = acert_raiva.GetComponent<TextMeshProUGUI>();
        Acerto_nojo = acert_nojo.GetComponent<TextMeshProUGUI>();

        Erro_felicidade = err_felicidade.GetComponent<TextMeshProUGUI>();
        Erro_tristeza = err_tristeza.GetComponent<TextMeshProUGUI>();
        Erro_medo = err_medo.GetComponent<TextMeshProUGUI>();
        Erro_surpresa = err_surpresa.GetComponent<TextMeshProUGUI>();
        Erro_raiva = err_raiva.GetComponent<TextMeshProUGUI>();
        Erro_nojo = err_nojo.GetComponent<TextMeshProUGUI>();
        Cenas = cenas.GetComponent<ScriptNomesCenas>();
    }    
    
    public void SetJogada(string emocao, string data, int pontos, int jogo, string retEmocao)
    {
        if(jogo == 1)
        {
            string item = emocao+" "+data+" "+pontos+" "+retEmocao+"";
            using (StreamWriter writer = File.AppendText(ArquivoJogo1))
            {
                 writer.WriteLine(item);
            }
        }
         if(jogo == 2)
        {
            string item = emocao+" "+data+" "+pontos+" "+retEmocao+"";
            using (StreamWriter writer2 = File.AppendText(ArquivoJogo2))
            {
                 writer2.WriteLine(item);
            }
        }
        if(jogo == 3)
        {
            string item = emocao+" "+data+" "+pontos+" "+retEmocao+"";
            using (StreamWriter writer3 = File.AppendText(ArquivoJogo3))
            {
                 writer3.WriteLine(item);
            }
        }
    }

    public void setListas(){
        jogadas01.Clear();
        jogadas02.Clear();
        jogadas03.Clear();

        using (StreamReader sr = new StreamReader(ArquivoJogo1))
        {
            while(!sr.EndOfStream){
                string linha = sr.ReadLine();
                string emocao = linha.Split(" ")[0];
                string data = linha.Split(" ")[1];
                string pontos = linha.Split(" ")[2];
                string retEmocao = linha.Split(" ")[3];
                Jogada = jogada.GetComponent<Jogada>();
    	        jogadas01.Add(new Jogada(emocao, data, Convert.ToInt32(pontos), retEmocao));
            }
        }

        using (StreamReader sr = new StreamReader(ArquivoJogo2))
        {
            while(!sr.EndOfStream){
                string linha = sr.ReadLine();
                string emocao = linha.Split(" ")[0];
                string data = linha.Split(" ")[1];
                string pontos = linha.Split(" ")[2];
                string retEmocao = linha.Split(" ")[3];
                Jogada = jogada.GetComponent<Jogada>();
    	        jogadas02.Add(new Jogada(emocao, data, Convert.ToInt32(pontos),  retEmocao)); 
            }
        }

         using (StreamReader sr = new StreamReader(ArquivoJogo3))
        {
            while(!sr.EndOfStream){
                string linha = sr.ReadLine();
                string emocao = linha.Split(" ")[0];
                string data = linha.Split(" ")[1];
                string pontos = linha.Split(" ")[2];
                string retEmocao = linha.Split(" ")[3];
                Jogada = jogada.GetComponent<Jogada>();
    	        jogadas03.Add(new Jogada(emocao, data, Convert.ToInt32(pontos),  retEmocao)); 
            }
        }
    }

    public void ClearList(){
        if(jogado == 1)
        {
            if (File.Exists(ArquivoJogo1))
            {
                File.Create(ArquivoJogo1).Dispose();
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
            
        }
        if(jogado == 2)
        {
            if (File.Exists(ArquivoJogo2))
            {
                File.Create(ArquivoJogo2).Dispose();
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
        }
         if(jogado == 3)
        {
            if (File.Exists(ArquivoJogo3))
            {
                File.Create(ArquivoJogo3).Dispose();
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
        }

        GetMediaGeral(jogado);
    }
      
    public void GetMediaGeral(int jogo)
    {
        setListas();

        if(jogo == 1)
        {
            jogadas = jogadas01;
        }
        if(jogo == 2)
        {
            jogadas = jogadas02;
        }
        if(jogo == 3)
        {
            jogadas = jogadas03;
        }

        jogado = jogo;
        
        cont_felicidade = 0;
        cont_tristeza = 0;
        cont_medo = 0;
        cont_surpresa = 0; 
        cont_raiva = 0;
        cont_nojo = 0;

        acerto_felicidade = 0;
        acerto_tristeza = 0;
        acerto_medo = 0;
        acerto_surpresa = 0; 
        acerto_raiva = 0;
        acerto_nojo = 0;

        erro_felicidade = 0;
        erro_tristeza = 0;
        erro_medo = 0;
        erro_surpresa = 0; 
        erro_raiva = 0;
        erro_nojo = 0;

        felicidade = 0;
        tristeza = 0;
        medo = 0;
        surpresa = 0; 
        raiva = 0;
        nojo = 0;
        
        Start();

        foreach(var item in jogadas)
        {
             if(item.emocao == "Felicidade"){
                felicidade = felicidade + item.pontos;
                cont_felicidade++;
                if(item.pontos > 0){
                    acerto_felicidade++;
                }else{
                    erro_felicidade++;
                }
            }
            else if(item.emocao == "Tristeza"){
                tristeza = tristeza + item.pontos;
                cont_tristeza++;
                 if(item.pontos > 0){
                    acerto_tristeza++;
                }else{
                    erro_tristeza++;
                }
            }

            else if(item.emocao == "Medo"){
                medo = medo + item.pontos;
                cont_medo++;
                 if(item.pontos > 0){
                    acerto_medo++;
                }else{
                    erro_medo++;
                }
            } 

            else  if(item.emocao == "Surpresa"){
                surpresa = surpresa + item.pontos;
                cont_surpresa++;
                 if(item.pontos > 0){
                    acerto_surpresa++;
                }else{
                    erro_surpresa++;
                }
            }

            else if(item.emocao == "Raiva"){
                raiva = raiva + item.pontos;
                cont_raiva++;
                 if(item.pontos > 0){
                    acerto_raiva++;
                }else{
                    erro_raiva++;
                }
            }

            else if(item.emocao == "Nojo"){
                nojo = nojo + item.pontos;
                cont_nojo++;
                 if(item.pontos > 0){
                    acerto_nojo++;
                }else{
                    erro_nojo++;
                }
            }
        }
        if(felicidade == 0)
        {
            Ret_felicidade.text = "0";
        }else{
            Ret_felicidade.text = (felicidade/cont_felicidade).ToString();
        }
        if(tristeza == 0)
        {
            Ret_tristeza.text = "0";
        }else{
            Ret_tristeza.text = (tristeza/cont_tristeza).ToString();
        }
        if(medo == 0)
        {
            Ret_medo.text = "0";
        }else{
            Ret_medo.text = (medo/cont_medo).ToString();
        }
        if(surpresa == 0)
        {
             Ret_surpresa.text = "0";
        }else{
            Ret_surpresa.text = (surpresa/cont_surpresa).ToString();
        }
        if(raiva == 0)
        {
            Ret_raiva.text = "0";
        }else{
            Ret_raiva.text = (raiva/cont_raiva).ToString();
        }
        if(nojo == 0)
        {
            Ret_nojo.text = "0";
        }else{
            Ret_nojo.text = (nojo/cont_nojo).ToString();
        }

        Acerto_felicidade.text = (acerto_felicidade).ToString();
        Acerto_tristeza.text = (acerto_tristeza).ToString();
        Acerto_medo.text = (acerto_medo).ToString();
        Acerto_surpresa.text = (acerto_surpresa).ToString();
        Acerto_raiva.text = (acerto_raiva).ToString();
        Acerto_nojo.text = (acerto_nojo).ToString();

        Erro_felicidade.text = (erro_felicidade).ToString();
        Erro_tristeza.text = (erro_tristeza).ToString();
        Erro_medo.text = (erro_medo).ToString();
        Erro_surpresa.text = (erro_surpresa).ToString();
        Erro_raiva.text = (erro_raiva).ToString();
        Erro_nojo.text = (erro_nojo).ToString();

    }

        
    public async Task<int> GeradorRosto(int jogo)
    {
        setListas();

        if(jogo == 1)
        {
            jogadas = jogadas01;
        }
        if(jogo == 2)
        {
            jogadas = jogadas02;
        }
        if(jogo == 3)
        {
            jogadas = jogadas03;
        }

        cont_felicidade = 0;
        cont_tristeza = 0;
        cont_medo = 0;
        cont_surpresa = 0; 
        cont_raiva = 0;
        cont_nojo = 0;

        felicidade = 0;
        tristeza = 0;
        medo = 0;
        surpresa = 0; 
        raiva = 0;
        nojo = 0;

        int med_felicidade, med_tristeza, med_medo, med_surpresa, med_raiva, med_nojo, rand;

        foreach(var item in jogadas)
        {
             if(item.emocao == "Felicidade"){
                felicidade = felicidade + item.pontos;
                cont_felicidade++;
            }

            else if(item.emocao == "Tristeza"){
                tristeza = tristeza + item.pontos;
                cont_tristeza++;
            }

            else if(item.emocao == "Medo"){
                medo = medo + item.pontos;
                cont_medo++;
            } 

            else  if(item.emocao == "Surpresa"){
                surpresa = surpresa + item.pontos;
                cont_surpresa++;
            }

            else if(item.emocao == "Raiva"){
                raiva = raiva + item.pontos;
                cont_raiva++;
            }

            else if(item.emocao == "Nojo"){
                nojo = nojo + item.pontos;
                cont_nojo++;
            }
            
        } 

        if(felicidade == 0){
                med_felicidade = percent;
            }else{
                med_felicidade = percent-(felicidade/cont_felicidade);
            }

        if(tristeza == 0){
                med_tristeza = percent;
            }else{
                med_tristeza = percent-(tristeza/cont_tristeza);
            } 
        if(medo == 0){
                med_medo = percent;
            }else{
                med_medo = percent-(medo/cont_medo);
            }
        if(surpresa == 0){
                med_surpresa = percent;
            }else{
                med_surpresa = percent-(surpresa/cont_surpresa);
            }
        if(raiva == 0){
                med_raiva = percent;
            }else{
                med_raiva = percent-(raiva/cont_raiva);
            }
        if(nojo == 0){
                med_nojo = percent;
            }else{
                med_nojo = percent-(nojo/cont_nojo);
            }  

        int totalPontos = med_felicidade + med_tristeza + med_medo + med_surpresa + med_raiva + med_nojo;
        geradorRosto = new int[6]{med_felicidade, med_tristeza, med_medo, med_surpresa, med_raiva, med_nojo};
        int aux = 1;
        int soma = 0;
        rand = ran.Next(0,totalPontos);

        for(int i = 0; i < geradorRosto.Length; i++){
            soma += geradorRosto[i];
            if(soma >= rand){
                break;
            }
            aux++;
        }
        return aux;    
    }

    public int GetSecEmocao(int busca)
    {
        setListas();

        switch (busca){
            case 1:
            emocao = "Felicidade";
            break;

            case 2:
            emocao = "Tristeza";
            break;

            case 3:
            emocao = "Medo";
            break;

            case 4:
            emocao = "Surpresa";
            break;

            case 5:
            emocao = "Raiva";
            break;

            case 6:
            emocao = "Nojo";
            break;
        }

        erros = new int[6]{1,1,1,1,1,1};
        total = 6;
        
        using (StreamReader sr = new StreamReader(ArquivoJogo3))

        foreach(var item in jogadas03)
        {
            if(item.emocao == emocao){
                 switch (item.emocaoEscolida){
                    case "Felicidade":
                    if(emocao != item.emocaoEscolida)
                    {
                        erros[0] = erros[0] + peso;
                        total = total + peso;
                    }
                    break;

                    case "Tristeza":
                    if(emocao != item.emocaoEscolida)
                    {
                        erros[1] = erros[1] + peso;
                        total = total + peso;
                    }
                    break;

                    case "Medo":
                    if(emocao != item.emocaoEscolida)
                    {
                        erros[2] = erros[2] + peso;
                        total = total + peso;
                    }
                    break;

                    case "Surpresa":
                    if(emocao != item.emocaoEscolida)
                    {
                        erros[3] = erros[3] + peso;
                        total = total + peso;
                    }
                    break;

                    case "Raiva":
                    if(emocao != item.emocaoEscolida)
                    {
                        erros[4] = erros[4] + peso;
                        total = total + peso;
                    }
                    break;

                    case "Nojo":
                    if(emocao != item.emocaoEscolida)
                    {
                        erros[5] = erros[5] + peso;
                        total = total + peso;
                    }
                    break;
                }
            }
        }

        int rand = ran.Next(0,total);
        int aux = 1;
        int soma = 0;

        for(int i = 0; i < erros.Length; i++){
            soma += erros[i];
            if(soma >= rand && busca != aux){
                break;
            }
            aux++;
        }

        return aux; 
    }

}
