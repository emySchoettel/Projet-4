using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static Dictionary<string, bool> glossaireDialogues = new Dictionary<string, bool>(); 
    //public static string[] dialogues;

    public static List<Observer> observers = new List<Observer>();

    private void Awake() 
    {
        remplirDictionnaire();

    }
    private static void remplirDictionnaire()
    {
        glossaireDialogues.Add("Tonneaux", false); 
    }

    public static void lancerDiscussion(string emplacement, GameObject gm)
    {
        if(glossaireDialogues.ContainsKey(emplacement))
        {
            glossaireDialogues[emplacement] = true; 
            gm.GetComponent<DialogueTest>().enabled = true; 
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
