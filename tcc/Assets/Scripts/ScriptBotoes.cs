using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using static System.Console;
using System.Diagnostics;
using TMPro;
using System.Linq;


public class ScriptBotoes : MonoBehaviour
{
   public GameObject jogo01;
   private ScriptJogo Jogo01; 
   private Stopwatch stopwatch;
   public int tempo;
   public System.Random ran = new System.Random();
   public GameObject btn_01, btn_02, btn_03, btn_04, btn_05, btn_06, btn_07, btn_08, ret;
   private TextMeshProUGUI Btn_01, Btn_02, Btn_03, Btn_04, Btn_05, Btn_06, Btn_07, Btn_08, Ret;
   public GameObject Cor_Btn_01, Cor_Btn_02, Cor_Btn_03, Cor_Btn_04, Cor_Btn_05, Cor_Btn_06;
   private List<TextMeshProUGUI> list2,list4;
   private List<GameObject> list3;

   public void jogar()
   {
        stopwatch = new Stopwatch();
        stopwatch.Start();
        Jogo01 = jogo01.GetComponent<ScriptJogo>();
        Btn_01 = btn_01.GetComponent<TextMeshProUGUI>();
        Btn_02 = btn_02.GetComponent<TextMeshProUGUI>();
        Btn_03 = btn_03.GetComponent<TextMeshProUGUI>();
        Btn_04 = btn_04.GetComponent<TextMeshProUGUI>();
        Btn_05 = btn_05.GetComponent<TextMeshProUGUI>();
        Btn_06 = btn_06.GetComponent<TextMeshProUGUI>();
        Btn_07 = btn_07.GetComponent<TextMeshProUGUI>();
        Btn_08 = btn_08.GetComponent<TextMeshProUGUI>();
        Ret = ret.GetComponent<TextMeshProUGUI>();

        list2 = new List<TextMeshProUGUI>() {Btn_01, Btn_02, Btn_03, Btn_04, Btn_05, Btn_06};
        list3 = new List<GameObject>() {Cor_Btn_01, Cor_Btn_02, Cor_Btn_03, Cor_Btn_04, Cor_Btn_05, Cor_Btn_06};
        list4 = new List<TextMeshProUGUI>() {Btn_07, Btn_08};

        GerarBotoes();

   }

   public void GerarBotoes()
   {
         List<string> list1 = new List<string>() {"Nojo", "Raiva", "Medo", "Tristeza", "Felicidade", "Surpresa"};
          var randomized = list1.OrderBy(item => ran.Next());
          int x = 0;
          foreach (var value in randomized)
          {
               list2[x].text = value;
               x++;
          }
   }

   public void GerarBotoesJogo3(string valor01, string valor02)
   {
     List<string> list1 = new List<string>() {valor01, valor02};
     var randomized = list1.OrderBy(item => ran.Next());
     int x = 0;
     foreach (var value in randomized)
     {
          list4[x].text = value;
          x++;
     }
     //list4[0].text = randomized[0];
     //list4[1].text = randomized[1];        
   }

   public void ColorirBtn()
   {
     int x = 0;
     foreach(var value in list2)
     {
          SetColor(value, list3[x]);
          x++;
     }
   }

   public void SetColor(TextMeshProUGUI texto, GameObject btn)
   { 
      if(texto.text == "Nojo")
     {
          btn.GetComponent<Image>().color = new Color32(162,132,195,255);
          texto.enabled = false;

     }
     else if(texto.text == "Raiva")
     {
          btn.GetComponent<Image>().color = new Color32(255,84,62,255);
          texto.enabled = false;
     }

     else if(texto.text == "Medo")
     {
          btn.GetComponent<Image>().color = new Color32(0,152,63,255);
          texto.enabled = false;
     } 

     else if(texto.text == "Tristeza")
     {
          btn.GetComponent<Image>().color = new Color32(93,154,219,255);
          texto.enabled = false;
     } 

     else if(texto.text == "Felicidade")
     {
          btn.GetComponent<Image>().color = new Color32(255,215,88,255);
          texto.enabled = false;
     } 

     else if(texto.text == "Surpresa")
     {
          btn.GetComponent<Image>().color = new Color32(175,214,244,255);
          texto.enabled = false;
     }      

   }

   public void SetRet(TextMeshProUGUI select){
     Ret.text = select.text;
   }

   public void ClearRet(TextMeshProUGUI select){
     Ret.text = "";
   }

   public void ReturnBtn(TextMeshProUGUI select)
   { 
     if(select.text == "Nojo")
     {
          SetNojo();
     }
     else if(select.text == "Raiva")
     {
          SetRaiva();
     }

     else if(select.text == "Medo")
     {
          SetMedo();
     } 

     else if(select.text == "Tristeza")
     {
          SetTristeza();
     } 

     else if(select.text == "Felicidade")
     {
          SetFelicidade();
     } 

     else if(select.text == "Surpresa")
     {
          SetSurpresa();
     }      

   }

   public void SetNojo()
   {
        stopwatch.Stop();
        tempo = Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds);
        Jogo01.ContabilizarPontos("Nojo", tempo);
   }

    public void SetRaiva()
   {
        stopwatch.Stop();
        tempo = Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds);
        Jogo01.ContabilizarPontos("Raiva", tempo);
   }

    public void SetMedo()
   {
        stopwatch.Stop();
        tempo = Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds);
        Jogo01.ContabilizarPontos("Medo", tempo);
   }

    public void SetTristeza()
   {
        stopwatch.Stop();
        tempo = Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds);
        Jogo01.ContabilizarPontos("Tristeza", tempo);
   }

    public void SetFelicidade()
   {
        stopwatch.Stop();
        tempo = Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds);
        Jogo01.ContabilizarPontos("Felicidade", tempo);
   }

    public void SetSurpresa()
   {
        stopwatch.Stop();
        tempo = Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds);
        Jogo01.ContabilizarPontos("Surpresa", tempo);
   }

   public void SairJogo()
   {

   } 
}

