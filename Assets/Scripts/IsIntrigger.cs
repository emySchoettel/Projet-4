using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(DialogueTest))]
public class IsIntrigger : MonoBehaviour, Observer
{
    [SerializeField]
    private bool multipleTrigger = false, automatique_trigger = false,  isTriggered = false;

    [SerializeField]
    private bool onEntrer = false; 

    private DialogueTest dialogueTest; 

    private void Start() 
    {
        DialogueManager.AddObserver(this);
        dialogueTest = gameObject.GetComponent<DialogueTest>();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E) && !automatique_trigger && onEntrer)
        {
            DialogueManager.lancerDiscussion("Tonneaux", this.gameObject, true);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(!isTriggered)
        {
            if(other.transform.CompareTag("Player"))    
            {
                while(!Helper.bulle_bool)
                {
                    Helper.addExpression(Helper.getPlayer(), Expression.nomsExpressions.Exclamation);
                }
                onEntrer = true; 
                Notify();
                //s'il n'y a pas de multiple trigger alors autoriser le dialogue à ne pas se relancer 
                if(!multipleTrigger)
                {
                    isTriggered = true; 
                }               
                //S'il automatique trigger
                if(automatique_trigger)
                {   
                    DialogueManager.lancerDiscussion("Tonneaux", this.gameObject, true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        
        if(other.transform.CompareTag("Player"))
        {
            onEntrer = false; 
            //Si il n'y a pas de multipletrigger et que le dialogue est terminé
            if(multipleTrigger && dialogueTest.getFinished())
            {
                DialogueManager.lancerDiscussion("Tonneaux", gameObject, false);
                dialogueTest.stopFinished(); 
            }
        }
    }
    public void Notify()
    {
        Debug.Log("IsIntrigger");
    }

    
    public bool getMultipleTrigger()
    {
        return multipleTrigger;
    }

    public bool getOnEnter()
    {
        return onEntrer;
    }
}
