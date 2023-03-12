using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Drawing.Color;

public class Cores : MonoBehaviour
{
    [SerializeField]private Material myMaterial;

    public void SetCoresRaiva(){
        myMaterial.color = new Color32(222,6,131,255);
    }

    public void SetCoresNojo(){
        myMaterial.color = new Color32(147,44,155,255);
    }

    public void SetCoresMedo(){
        myMaterial.color = new Color32(149,209,38,255);
    }

    public void SetCoresTristeza(){
        myMaterial.color = new Color32(94,194,239,255);
    }

    public void SetCoresFelicidade(){
        myMaterial.color = new Color32(236,237,20,255);
    }

    public void SetCoresSurpresa(){
        myMaterial.color = new Color32(95,198,120,255);
    }

    public void SetCoresNeutro(){
        myMaterial.color = new Color32(255,255,255,255);
    }
    
}
