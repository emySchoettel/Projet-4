using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsIntrigger : MonoBehaviour, Observer
{
    public bool isTriggered = false; 

    private void Start() 
    {
        DialogueManager.AddObserver(this);
    }
    private void OnTriggerEnter(Collider other) 
    {
        
        if(!isTriggered)
        {
            
            if(other.transform.CompareTag("Player"))    
            {
                Notify();
                isTriggered = true; 
                DialogueManager.lancerDiscussion("Tonneaux", this.gameObject);

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
    public void Notify()
    {
        Debug.Log("IsIntrigger");
    }
}
