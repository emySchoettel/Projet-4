using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EtatMouvementJoueur  
{
    protected float x, z;
    protected Animator animator;
    public abstract void Enter(MouvementJoueur player);
    public abstract void Update(MouvementJoueur player);  
    public abstract void Move(MouvementJoueur player); 
}
