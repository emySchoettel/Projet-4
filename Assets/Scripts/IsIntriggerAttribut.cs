using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsIntriggerAttribut : MonoBehaviour
{
    [SerializeField]
    private bool triggered = false; 
    private static bool canOpenMenu = false; 
    private void OnTriggerEnter(Collider other) 
    {
        triggered = true; 
        if(other.transform.CompareTag("Player"))
        {
            Helper.addExpression(Helper.getPlayer(), Expression.nomsExpressions.Exclamation); 
            canOpenMenu = true; 
        }
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && canOpenMenu)
        {
            Helper.getCanvasScript().changeCanvas(CanvasManager.canvas.attributs);

           if(Helper.getPlayer().GetComponent<PlayerController>().GetAttributs().Count == 0)
           {    
                Attribut att = new Attribut("Emy", "Je suis Emy", Helper.mondes.monde1, Helper.typeAttribut.TOR);
                TypeTOR tor = new TypeTOR(true); 
                att.setTypeTOR(tor);
                Helper.addAttributPlayer(att);
           } 

            Helper.manageAttributUIjoueur(gameObject);
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        triggered = false;    
    }

    public static void setCanOpenMenu(bool choix)
    {
        canOpenMenu = choix;
    }
}
