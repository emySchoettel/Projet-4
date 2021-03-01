using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static Dictionary<string, bool> glossaireDialogues = new Dictionary<string, bool>(); 
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
        glossaireDialogues.Add("Tonneaux", false); 
    }

    public static void lancerDiscussion(string emplacement, GameObject gm, bool etat)
    {
        if(glossaireDialogues.ContainsKey(emplacement))
        {
            glossaireDialogues[emplacement] = etat; 
            gm.GetComponent<DialogueTest>().enabled = etat; 
        }
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
