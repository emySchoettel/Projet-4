using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static Dictionary<string, bool> glossaireDialogues = new Dictionary<string, bool>(); 
    public static Dictionary<cinematiques_enum, bool> cinematiques = new Dictionary<cinematiques_enum, bool>(); 
    public enum cinematiques_enum
    {
        introduction, 
        monde1debut, 
        monde1Fin, 
        monde2Debut, 
        monde2Fin, 
        monde3Debut, 
        monde3Fin, 
        monde4Debut,
        monde4Fin, 
        conclusion
    }
    //public static string[] dialogues;

    public static List<Observer> observers = new List<Observer>();

    public Text dialogue_gm, speaker; 
    public GameObject canvas; 

    private void Awake() 
    {
        remplirDictionnaire();
    }
    private static void remplirDictionnaire()
    {
        //Glossaire
        glossaireDialogues.Add("Tonneaux", false); 

        //TODO ajouter les cinematiques au fur et a mesure
        //Cinematique
        cinematiques.Add(cinematiques_enum.introduction, false);
    }

    public static void lancerDiscussion(string emplacement, GameObject gm, bool etat)
    {
        if(glossaireDialogues.ContainsKey(emplacement))
        {
            glossaireDialogues[emplacement] = etat; 
            gm.GetComponent<DialogueTest>().enabled = etat; 
        }
    }

    public static bool lancerCinematique(cinematiques_enum cin)
    {
        bool res = false; 
        if(cinematiques.ContainsKey(cin))
        {
            if(!cinematiques[cin])
            {
                res = true; 
                cinematiques[cin] = res; 
            }
        }
        return res; 
    }

    public static void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public static void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }

    public static void Notify()
    {
        foreach(Observer obs in observers)
        {
            obs.Notify();
        }
    }
}
