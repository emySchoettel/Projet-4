using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static string nomJoueur = "Le joueur"; 
    [SerializeField]

    private RuntimeAnimatorController[] animators; 
    public bool introduction = false; 

    [SerializeField]
    private bool movePlayer; 

    private List<Attribut> attributs = new List<Attribut>(); //inventaire des attributs

    public List<Attribut> GetAttributs()
    {
        return attributs; 
    }

    public void addAttribut(GameObject gameAtt)
    {
        if(gameAtt.GetComponent<Attribut>() != null && gameAtt.GetComponent<Attribut>().GetTypeAttribut() != Helper.typeAttribut.none)
        {
            Attribut att = gameAtt.GetComponent<Attribut>(); 
            attributs.Add(att);
            att.setTypeAttribut(Helper.typeAttribut.none);
        }
    }

    private void Awake() 
    {
        if(introduction)
        {
            GetComponent<Animator>().runtimeAnimatorController = animators[1]; 
        }
        else
        {
            if(GetComponent<MouvementJoueur>().enabled)
            {
                GetComponent<Animator>().runtimeAnimatorController = animators[0];
            }
        }
    }

    public void setAnimator(int i)
    {
        GetComponent<Animator>().runtimeAnimatorController = animators[i];
        if(i == 1)
        {
            introduction = false; 
            movePlayer = true; 
            GetComponent<MouvementJoueur>().enabled = true; 
        }
    }
}
