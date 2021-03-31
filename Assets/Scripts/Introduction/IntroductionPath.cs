using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionPath : MonoBehaviour
{
    public IntroductionManager introManager; 
    public IntroductionJoueur introJoueur; 

    public GameObject Canvas;
    public int tour = 0;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))    
        {
            if(tour != 4)
            {
                StartCoroutine(introManager.ShowTextIntro(introManager.GetDialoguesIntroJoueur(), tour));
                tour ++; 
            }
        }
    }

    private void FixedUpdate() 
    {
        if(tour == 4 && !Canvas.activeSelf)    
        {
            introJoueur.stop = true; 
            Destroy(GameObject.FindGameObjectWithTag("Player").GetComponent<IntroductionJoueur>());
            introManager.CinematiqueSolabis(); 
            this.enabled = false; 
        }
    }
}
