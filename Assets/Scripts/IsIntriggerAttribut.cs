using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsIntriggerAttribut : MonoBehaviour
{
    [SerializeField]
    private bool triggered = false; 
    private void OnTriggerEnter(Collider other) 
    {
        triggered = true; 
        if(other.transform.CompareTag("Player"))
        {
            Helper.addExpression(Helper.getPlayer(), Expression.nomsExpressions.Exclamation); 
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Helper.getCanvasScript().changeCanvas(CanvasManager.canvas.attributs);

            Attribut att = new Attribut("Emy", "Je suis Emy", Helper.mondes.monde1, Helper.typeAttribut.TOR);
            TypeTOR tor = new TypeTOR(true); 
            att.setTypeTOR(tor);
            Helper.addAttributPlayer(att);

            // foreach(Attribut attribut in GetComponents<Attribut>())
            // {
            //     Helper.addAttributPlayer(attribut); 
            // }
            Helper.manageAttributUIjoueur(gameObject);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        triggered = false;    
    }
}
