using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionPath : MonoBehaviour
{
    public IntroductionManager introManager; 
    public IntroductionJoueur introJoueur; 
    public int tour = 0;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))    
        {
            if(tour != 4)
            {
                tour++; 
                introJoueur.stop = true; 
                StartCoroutine(introManager.ShowText(introManager.GetDialogues(), tour));
                introJoueur.stop = false; 
            }
        }
    }

    private void FixedUpdate() 
    {
        if(tour == 4)    
        {
            introJoueur.stop = true; 
            Debug.Log("tours terminés");
            lancerCinematique();
        }
    }

    private void lancerCinematique()
    {

    }
}
