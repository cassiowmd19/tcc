using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using static System.Console;
using System.Diagnostics;
using TMPro;
using System.Threading.Tasks;
using System.IO;

public class ScriptNomesCenas : MonoBehaviour
{
    public AudioSource tony, lala, luna, babu, tina, caio, ola, Nojo, Raiva, Medo, Tristeza, Felicidade, Surpresa, jogo01, jogo02, jogo03;
    public AudioSource correto, erro, Ensino_Nojo, Ensino_Raiva, Ensino_Medo, Ensino_Tristeza, Ensino_Felicidade, Ensino_Surpresa;
    private ScriptJogo Jogo;
    private Cores Cor;
    public GameObject ret_nome, tela_select_name, tela_ola, jogo, cor;
    public GameObject  btn_Nojo, btn_Raiva, btn_Medo, btn_Tristeza, btn_Felicidade, btn_Surpresa,  btn_Voltar;
    private ScriptVideos Tela_select_name, Tela_ola, Btn_Nojo, Btn_Raiva, Btn_Medo, Btn_Tristeza, Btn_Felicidade, Btn_Surpresa, Btn_Voltar;
    private TextMeshProUGUI Ret_nome;
    private string nome = "";
    string ArquivoNome =  Path.Combine("Nome.txt");

    public void RunNome(){
        Ret_nome = ret_nome.GetComponent<TextMeshProUGUI>();
        Tela_select_name = tela_select_name.GetComponent<ScriptVideos>();
        Tela_ola = tela_ola.GetComponent<ScriptVideos>();
    }

    public void PlayJogo01(){
        jogo01.Play();
    }

    public void PlayJogo02(){
        jogo02.Play();
    }

     public void PlayJogo03(){
        jogo03.Play();
    }

    public void PlayTony(){
        tony.Play();
        Ret_nome.text = "Tony";
    }

    public void PlayLala(){
        lala.Play();
        Ret_nome.text = "Lala";
    }

    public void PlayLuna(){
       luna.Play();
       Ret_nome.text = "Luna"; 
    }

    public void PlayBabu(){
       babu.Play();
       Ret_nome.text = "Babu"; 
    }

    public void PlayTina(){
       tina.Play();
       Ret_nome.text = "Tina"; 
    }

    public void PlayCaio(){
       caio.Play();
       Ret_nome.text = "Caio"; 
    }

    public void PlayAcerto(){
       correto.Play();
    
    }

    public async void PlayErro(string emocao){
       erro.Play();
       await Task.Delay(4000);
       ReturnEmocao(emocao);
    }

    public void SetNome(){
        nome = Ret_nome.text;
        File.Create(ArquivoNome).Dispose();
        using (StreamWriter writer = File.AppendText(ArquivoNome))
            {
                 writer.WriteLine(nome);
            }
    }

    public async void VerificaNome(){
        using (StreamReader sr = new StreamReader(ArquivoNome))
        {
            while(!sr.EndOfStream){
                nome = sr.ReadLine();
                Console.WriteLine(nome);
            }
        }

        Console.WriteLine(nome);

        if(nome != ""){
            Tela_ola.SetActive();
            Tela_select_name.SetInactive();
            ola.Play();
            await Task.Delay(3300);
            switch (nome){
                case "Tony":
                    tony.Play();
                    break;
                case "Lala":
                    lala.Play();
                    break;
                case "Tina":
                    tina.Play();
                    break;
                case "Babu":
                    babu.Play();
                    break;
                case "Luna":
                    luna.Play();
                    break;
                case "Caio":
                    caio.Play();
                    break;                        
            }
        }else{
            Tela_select_name.SetActive();
        }
    }

    public void ReturnBtn(TextMeshProUGUI select)
    { 
     if(select.text == "Nojo")
     {
          Nojo.Play();
     }
     else if(select.text == "Raiva")
     {
          Raiva.Play();
     }

     else if(select.text == "Medo")
     {
          Medo.Play();
     } 

     else if(select.text == "Tristeza")
     {
          Tristeza.Play();
     } 

     else if(select.text == "Felicidade")
     {
          Felicidade.Play();
     } 

     else if(select.text == "Surpresa")
     {
          Surpresa.Play();
     }                                                                                 
   }

   public void ReturnEmocao(string select)
    { 
     if(select == "Nojo")
     {
          Nojo.Play();
     }
     else if(select == "Raiva")
     {
          Raiva.Play();
     }

     else if(select == "Medo")
     {
          Medo.Play();
     } 

     else if(select == "Tristeza")
     {
          Tristeza.Play();
     } 

     else if(select == "Felicidade")
     {
          Felicidade.Play();
     } 

     else if(select == "Surpresa")
     {
          Surpresa.Play();
     }      
                                                                                
   }

    public async void SetEnsinoEmocao(string emocao_transicao)
    {
        Jogo = jogo.GetComponent<ScriptJogo>();
        Cor = cor.GetComponent<Cores>();
        Btn_Nojo =  btn_Nojo.GetComponent<ScriptVideos>(); 
        Btn_Raiva =  btn_Raiva.GetComponent<ScriptVideos>();
        Btn_Medo =  btn_Medo.GetComponent<ScriptVideos>();
        Btn_Tristeza =  btn_Tristeza.GetComponent<ScriptVideos>();
        Btn_Felicidade = btn_Felicidade.GetComponent<ScriptVideos>();
        Btn_Surpresa = btn_Surpresa .GetComponent<ScriptVideos>();
        Btn_Voltar = btn_Voltar .GetComponent<ScriptVideos>();

        Btn_Nojo.SetInactive();
        Btn_Raiva.SetInactive();
        Btn_Medo.SetInactive();
        Btn_Tristeza.SetInactive();
        Btn_Felicidade.SetInactive();
        Btn_Surpresa.SetInactive();
        Btn_Voltar.SetInactive();

        if(emocao_transicao == "Felicidade"){
                Ensino_Felicidade.Play();
                Jogo.SetTransicaoEmocao(emocao_transicao);
                await Task.Delay(7000);
                Jogo.SetTransicaoNeutro(emocao_transicao);   
            }
            else if(emocao_transicao == "Tristeza"){
                Ensino_Tristeza.Play();
                Jogo.SetTransicaoEmocao(emocao_transicao);
                await Task.Delay(6600);
                Jogo.SetTransicaoNeutro(emocao_transicao);
            }
            else if(emocao_transicao == "Medo"){
                Ensino_Medo.Play();
                Jogo.SetTransicaoEmocao(emocao_transicao);
                await Task.Delay(6600);
                Jogo.SetTransicaoNeutro(emocao_transicao);
            } 
            else  if(emocao_transicao == "Surpresa"){
                Ensino_Surpresa.Play();
                Jogo.SetTransicaoEmocao(emocao_transicao);
                await Task.Delay(7600);
                Jogo.SetTransicaoNeutro(emocao_transicao);
            }
            else if(emocao_transicao == "Raiva"){
                Ensino_Raiva.Play();
                Jogo.SetTransicaoEmocao(emocao_transicao);
                await Task.Delay(7000);
                Jogo.SetTransicaoNeutro(emocao_transicao);
            }
            else if(emocao_transicao == "Nojo"){
                Ensino_Nojo.Play();
                Jogo.SetTransicaoEmocao(emocao_transicao);
                await Task.Delay(7200);
                Jogo.SetTransicaoNeutro(emocao_transicao);
            }
            
        Cor.SetCoresNeutro();
        Btn_Nojo.SetActive();
        Btn_Raiva.SetActive();
        Btn_Medo.SetActive();
        Btn_Tristeza.SetActive();
        Btn_Felicidade.SetActive();
        Btn_Surpresa.SetActive();
        Btn_Voltar.SetActive();
    }  

    public void StopAudio(){
        tony.Stop();
        lala.Stop();
        luna.Stop(); 
        babu.Stop(); 
        tina.Stop(); 
        caio.Stop(); 
        ola.Stop(); 
        Nojo.Stop(); 
        Raiva.Stop(); 
        Medo.Stop(); 
        Tristeza.Stop(); 
        Felicidade.Stop(); 
        Surpresa.Stop(); 
        jogo01.Stop(); 
        jogo02.Stop();
        jogo03.Stop();
        correto.Stop(); 
        erro.Stop(); 
        Ensino_Nojo.Stop(); 
        Ensino_Raiva.Stop(); 
        Ensino_Medo.Stop(); 
        Ensino_Tristeza.Stop(); 
        Ensino_Felicidade.Stop(); 
        Ensino_Surpresa.Stop();
    }  
    
}
