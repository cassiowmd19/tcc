using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using static System.Console;
using System.Diagnostics;
using TMPro;
using System.IO;
using System.Threading.Tasks;

public class ScriptJogo : MonoBehaviour
{
    public System.Random ran = new System.Random();
    public DateTime date = DateTime.Today;
    public int rand, rand2;
    public int pontos;
    private string emocao, secEmocao;
    public GameObject felicidade, tristeza, medo, surpresa, raiva, nojo, neutra, jogada, cor, textSucesso, textFalha, sucesso, falha, jogar01, jogar02, jogar03, falha_jogar01, falha_jogar02, falha_jogar03, voltar, audios, botoes;
    public GameObject neutro_felicidade, neutro_tristeza, neutro_medo, neutro_surpresa, neutro_raiva, neutro_nojo, tela_interna;
    public GameObject felicidade_neutra, tristeza_neutra, medo_neutra, surpresa_neutra, raiva_neutra, nojo_neutra;
    private ScriptVideos Felicidade, Tristeza, Medo, Surpresa, Raiva, Nojo, Neutra, Sucesso, Falha;
    private ScriptVideos Neutro_Felicidade, Neutro_Tristeza, Neutro_Medo, Neutro_Surpresa, Neutro_Raiva, Neutro_Nojo;
    private ScriptVideos Felicidade_Neutra, Tristeza_Neutra, Medo_Neutra, Surpresa_Neutra, Raiva_Neutra, Nojo_Neutra;
    private DadosJogo Jogada;
    private ScriptNomesCenas Audios;
    private ScriptBotoes Botoes;
    private  MeshRenderer Tela_interna;
    private Cores Cor;
    private TextMeshProUGUI texto, erro;
    private int slepp = 800;
    private int tipo_jogo;
    
    
    
    void Start()
    {
        Felicidade = felicidade.GetComponent<ScriptVideos>();
        Tristeza = tristeza.GetComponent<ScriptVideos>();
        Medo = medo.GetComponent<ScriptVideos>();
        Surpresa = surpresa.GetComponent<ScriptVideos>();
        Raiva = raiva.GetComponent<ScriptVideos>();
        Nojo = nojo.GetComponent<ScriptVideos>();
        Felicidade_Neutra = felicidade_neutra.GetComponent<ScriptVideos>();
        Tristeza_Neutra = tristeza_neutra.GetComponent<ScriptVideos>();
        Medo_Neutra = medo_neutra.GetComponent<ScriptVideos>();
        Surpresa_Neutra = surpresa_neutra.GetComponent<ScriptVideos>();
        Raiva_Neutra = raiva_neutra.GetComponent<ScriptVideos>();
        Nojo_Neutra = nojo_neutra.GetComponent<ScriptVideos>();
        Neutro_Felicidade = neutro_felicidade.GetComponent<ScriptVideos>();
        Neutro_Tristeza = neutro_tristeza.GetComponent<ScriptVideos>();
        Neutro_Medo = neutro_medo.GetComponent<ScriptVideos>();
        Neutro_Surpresa = neutro_surpresa.GetComponent<ScriptVideos>();
        Neutro_Raiva = neutro_raiva.GetComponent<ScriptVideos>();
        Neutro_Nojo = neutro_nojo.GetComponent<ScriptVideos>();
        Neutra = neutra.GetComponent<ScriptVideos>();
        Cor = cor.GetComponent<Cores>();
        Sucesso = sucesso.GetComponent<ScriptVideos>(); 
        Falha = falha.GetComponent<ScriptVideos>();
        texto = textSucesso.GetComponent<TextMeshProUGUI>();
        erro = textFalha.GetComponent<TextMeshProUGUI>();
        Jogada = jogada.GetComponent<DadosJogo>();
        Audios = audios.GetComponent<ScriptNomesCenas>();
        Botoes = botoes.GetComponent<ScriptBotoes>();
        Tela_interna = tela_interna.GetComponent<MeshRenderer>();

    }

    public void GerarRosto()
    {
        rand = Jogada.GeradorRosto(1).Result;
        Start();
        tipo_jogo = 1;

        switch (rand){
            case 1:
            emocao = "Felicidade";
            SetTransicaoEmocao(emocao);
            Cor.SetCoresFelicidade();
            break;

            case 2:
            emocao = "Tristeza";
            SetTransicaoEmocao(emocao);
            Cor.SetCoresTristeza();
            break;

            case 3:
            emocao = "Medo";
            SetTransicaoEmocao(emocao);
            Cor.SetCoresMedo();
            break;

            case 4:
            emocao = "Surpresa";
            SetTransicaoEmocao(emocao);
            Cor.SetCoresSurpresa();
            break;

            case 5:
            emocao = "Raiva";
            SetTransicaoEmocao(emocao);
            Cor.SetCoresRaiva();
            break;

            case 6:
            emocao = "Nojo";
            SetTransicaoEmocao(emocao);
            Cor.SetCoresNojo();
            break;
        }
    }    

    public void GerarRosto_02()
    {
        rand = Jogada.GeradorRosto(2).Result;
        Start();
        tipo_jogo = 2;

        switch (rand){
            case 1:
            emocao = "Felicidade";
            SetTransicaoEmocao(emocao);
            break;

            case 2:
            emocao = "Tristeza";
            SetTransicaoEmocao(emocao);
            break;

            case 3:
            emocao = "Medo";
            SetTransicaoEmocao(emocao);
            break;

            case 4:
            emocao = "Surpresa";
            SetTransicaoEmocao(emocao);
            break;

            case 5:
            emocao = "Raiva";
            SetTransicaoEmocao(emocao);
            break;

            case 6:
            emocao = "Nojo";
            SetTransicaoEmocao(emocao);
            break;
        }
    }

    public void GerarRosto_03()
    {
        rand = Jogada.GeradorRosto(3).Result;
        rand2 = Jogada.GetSecEmocao(rand);

        Start();
        tipo_jogo = 3;

        switch (rand){
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

        SetTelaInterna(emocao);

         switch (rand2){
            case 1:
            secEmocao = "Felicidade";
            break;

            case 2:
            secEmocao = "Tristeza";
            break;

            case 3:
            secEmocao = "Medo";
            break;

            case 4:
            secEmocao = "Surpresa";
            break;

            case 5:
            secEmocao = "Raiva";
            break;

            case 6:
            secEmocao = "Nojo";
            break;
        }

        Botoes.GerarBotoesJogo3(emocao, secEmocao);
    }

    public void ContabilizarPontos(string retEmocao, int tempo)
    {   
        if(retEmocao == emocao)
        {       
            if(tempo <= 6000){
                pontos = 100;
            }
            else if(tempo > 6000 && tempo <= 7000){
                pontos = 95;
            }

            else if(tempo > 7000 && tempo <= 8000){
                pontos = 90;
            } 

            else  if(tempo > 8000 && tempo <= 9000){
                pontos = 85;
            }

            else if(tempo > 9000 && tempo <= 10000){
                pontos = 80;
            }

            else if(tempo > 10000 && tempo <= 11000){
                pontos = 75;
            }

            else if(tempo > 11000){
                pontos = 70;
            }                                    
    
        }else{
            pontos = 0;    
        }

        Jogada.SetJogada(emocao, date.ToString("dd/MM/yyyy"), pontos, tipo_jogo, retEmocao);
        SetResultado();

    }

    public void SetInativos()
    {
        Felicidade.SetInactive();
        Tristeza.SetInactive();
        Medo.SetInactive();
        Surpresa.SetInactive();
        Raiva.SetInactive();
        Nojo.SetInactive();
        Neutra.SetInactive();
        Neutro_Felicidade.SetInactive();
        Neutro_Tristeza.SetInactive();
        Neutro_Medo.SetInactive();
        Neutro_Surpresa.SetInactive();
        Neutro_Raiva.SetInactive();
        Neutro_Nojo.SetInactive();
        Felicidade_Neutra.SetInactive();
        Tristeza_Neutra.SetInactive();
        Medo_Neutra.SetInactive();
        Surpresa_Neutra.SetInactive();
        Raiva_Neutra.SetInactive();
        Nojo_Neutra.SetInactive();

    }

    public void Voltar(){
        Cor.SetCoresNeutro();
        SetTransicaoNeutro(emocao);
    }

    public void SetResultado(){
        Cor.SetCoresNeutro();
        
        if(tipo_jogo != 3){
            SetTransicaoNeutro(emocao);
        }

        if(pontos > 0)
        {
            Sucesso.SetActive();
            Audios.PlayAcerto();
            texto.text = pontos.ToString();
            
            if(tipo_jogo == 1)
            {
                jogar01.SetActive(true);
                jogar02.SetActive(false);
                jogar03.SetActive(false);
            }
            if(tipo_jogo == 2)
            {
                jogar02.SetActive(true);
                jogar01.SetActive(false);
                jogar03.SetActive(false);
            }
            if(tipo_jogo == 3)
            {
                jogar02.SetActive(false);
                jogar01.SetActive(false);
                jogar03.SetActive(true);
            }
        }
        else
        {
            Falha.SetActive();
            Audios.PlayErro(emocao);
            erro.text = emocao;

            SetEmocaoTelaErro(emocao, tipo_jogo);

        }
    }

    public async void SetEmocaoTelaErro(string emocao, int tipo_jogo)
    {
        falha_jogar01.SetActive(false);
        falha_jogar02.SetActive(false);
        falha_jogar03.SetActive(false);
        voltar.SetActive(false);

        await Task.Delay(3000);
        SetTransicaoEmocao(emocao);
        await Task.Delay(4000);
        SetTransicaoNeutro(emocao);

        if(tipo_jogo == 1)
            {
                falha_jogar01.SetActive(true);
                falha_jogar02.SetActive(false);
                falha_jogar03.SetActive(false); 
            }
        if(tipo_jogo == 2)
            {
                falha_jogar02.SetActive(true);
                falha_jogar01.SetActive(false);
                falha_jogar03.SetActive(false);
            }
        if(tipo_jogo == 3)
            {
                falha_jogar02.SetActive(false);
                falha_jogar01.SetActive(false);
                falha_jogar03.SetActive(true);
            }

         voltar.SetActive(true);    

    }

    public async void SetTransicaoEmocao(string emocao_transicao)
    {    
            if(emocao_transicao == "Felicidade"){
                SetInativos();
                Neutro_Felicidade.SetActive();
                await Task.Delay(slepp);
                SetInativos();
                Felicidade.SetActive();    
            }
            else if(emocao_transicao == "Tristeza"){
                SetInativos();
                Neutro_Tristeza.SetActive();
                await Task.Delay(slepp);
                SetInativos();
                Tristeza.SetActive();
            }

            else if(emocao_transicao == "Medo"){
                SetInativos();
                Neutro_Medo.SetActive();
                await Task.Delay(slepp);
                SetInativos();
                Medo.SetActive();
            } 

            else  if(emocao_transicao == "Surpresa"){
                SetInativos();
                Neutro_Surpresa.SetActive();
                await Task.Delay(slepp);
                SetInativos();
                Surpresa.SetActive();
            }

            else if(emocao_transicao == "Raiva"){
                SetInativos();
                Neutro_Raiva.SetActive();
                await Task.Delay(slepp);
                SetInativos();
                Raiva.SetActive();
            }

            else if(emocao_transicao == "Nojo"){
                SetInativos();
                Neutro_Nojo.SetActive();
                await Task.Delay(slepp);
                SetInativos();
                Nojo.SetActive();
            }
 
    }

    public async void SetTransicaoNeutro(string emocao_transicao)
    {    
            if(emocao_transicao == "Felicidade"){
                SetInativos();
                Felicidade_Neutra.SetActive();
                await Task.Delay(slepp);
                SetInativos();
                Neutra.SetActive();    
            }
            else if(emocao_transicao == "Tristeza"){
                SetInativos();
                Tristeza_Neutra.SetActive();
                await Task.Delay(slepp);
                SetInativos();
                Neutra.SetActive();
            }

            else if(emocao_transicao == "Medo"){
                SetInativos();
                Medo_Neutra.SetActive();
                await Task.Delay(slepp);
                SetInativos();
                Neutra.SetActive();
            } 

            else  if(emocao_transicao == "Surpresa"){
                SetInativos();
                Surpresa_Neutra.SetActive();
                await Task.Delay(slepp);
                SetInativos();
                Neutra.SetActive();
            }

            else if(emocao_transicao == "Raiva"){
                SetInativos();
                Raiva_Neutra.SetActive();
                await Task.Delay(slepp);
                SetInativos();
                Neutra.SetActive();
            }

            else if(emocao_transicao == "Nojo"){
                SetInativos();
                Nojo_Neutra.SetActive();
                await Task.Delay(slepp);
                SetInativos();
                Neutra.SetActive();;
            }
 
    }

    public void SetTelaInterna(string z){
        rand = ran.Next(1,20);
        
        string filePath = @$"C:\Users\Cassio\Documents\TCC\tcc\Emocoes\{z}\{z}_ ({rand}).png";
        byte[] imageData = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(imageData);
        Tela_interna.material.mainTexture =  texture;

    } 
}

