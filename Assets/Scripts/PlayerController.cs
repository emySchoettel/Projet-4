﻿using System.Collections;
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
}
