using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEssai : MonoBehaviour
{
    private void Start() 
    {
        if(Helper.getPlayer().GetComponent<PlayerController>().GetAttributs().Count == 0)
        {    
            Attribut att = new Attribut("Emy", "Je suis Emy", Helper.mondes.monde1, Helper.typeAttribut.TOR);
            TypeTOR tor = new TypeTOR(true); 
            att.setTypeTOR(tor);
            Helper.addAttributPlayer(att);
        } 
    }
}
