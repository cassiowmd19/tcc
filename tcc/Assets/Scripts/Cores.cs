using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Drawing.Color;

public class Cores : MonoBehaviour
{
    [SerializeField]private Material myMaterial;

    public void SetCoresRaiva(){
        myMaterial.color = new Color32(255,84,62,255);
    }

    public void SetCoresNojo(){
        myMaterial.color = new Color32(162,132,195,255);
    }

    public void SetCoresMedo(){
        myMaterial.color = new Color32(0,152,63,255);
    }

    public void SetCoresTristeza(){
        myMaterial.color = new Color32(93,154,219,255);
    }

    public void SetCoresFelicidade(){
        myMaterial.color = new Color32(255,215,88,255);
    }

    public void SetCoresSurpresa(){
        myMaterial.color = new Color32(175,214,244,255);
    }

    public void SetCoresNeutro(){
        myMaterial.color = new Color32(255,255,255,255);
    }
    
}
