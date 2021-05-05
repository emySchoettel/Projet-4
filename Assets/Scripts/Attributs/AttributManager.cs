using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributManager : MonoBehaviour
{
    public GameObject listeJoueur; 

    private GameObject listePositionJoueur; 
    private GameObject listePositionObjet; 
    public GameObject listeObjet; 
    public Sprite[] type_sprites;

    private void Start() 
    {
        listePositionJoueur = listeJoueur.transform.GetChild(0).gameObject;
        listePositionObjet = listeObjet.transform.GetChild(0).gameObject;
    }

    public GameObject GetlistePositionJoueur()
    {
        return listePositionJoueur;
    }
    public GameObject GetlistePositionObjet()
    {
        return listePositionObjet;
    }
}
