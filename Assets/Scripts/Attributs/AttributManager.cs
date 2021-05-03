using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributManager : MonoBehaviour
{
    public GameObject listeJoueur; 
    public GameObject listeObjet; 

    public GameObject prefabAttribut; 

    private void Awake() 
    {
        listeJoueur = GameObject.Find("Liste_joueur") ? GameObject.Find("Liste_joueur") : null;
        listeObjet = GameObject.Find("Liste_objet") ? GameObject.Find("Liste_objet") : null;
    }
}
