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
        if(Input.GetKeyDown(KeyCode.Space) && canOpenMenu && triggered)
        {
            Helper.getCanvasScript().changeCanvas(CanvasManager.canvas.attributs);
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
