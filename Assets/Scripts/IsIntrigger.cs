using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(DialogueTest))]
public class IsIntrigger : MonoBehaviour, Observer
{
    public bool isTriggered = false; 
    [SerializeField]
    private bool multipleTrigger = false; //savoir si le dialogue peut se relancer ou pas 

    private DialogueTest dialogueTest; 

    private void Start() 
    {
        DialogueManager.AddObserver(this);
        dialogueTest = gameObject.GetComponent<DialogueTest>();
            
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(!isTriggered)
        {
            if(other.transform.CompareTag("Player"))    
            {
                Notify();
                //s'il n'y a pas de multiple trigger alors autoriser le dialogue à ne pas se relancer 
                if(!multipleTrigger)
                {
                    isTriggered = true; 
                }
                DialogueManager.lancerDiscussion("Tonneaux", this.gameObject, true);

                //S'il faut appuyer sur la touche espace et que le dialogue ne se lance pas automatiquement
                if(!gameObject.GetComponent<DialogueTest>().automatique_trigger && Input.GetKeyDown(KeyCode.Space))
                {   
                   
                }
                else
                {

                }
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.transform.CompareTag("Player"))
        {
            Debug.Log(dialogueTest.getFinished());
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
}
