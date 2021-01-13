using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EtatMouvementJoueur  
{
    protected float x, z;

    protected enum parametersNames{
        WalkLeft, 
        WalkRight,
        WalkDown,
        WalkUp,
        IDLELeft,
        IDLERight,
        IDLEDown,
        IDLEUp
    }

    protected Animator animator;
   public abstract void Enter(MouvementJoueur player);
    public abstract void Update(MouvementJoueur player);  
    public abstract void Move(MouvementJoueur player); 

    public abstract void setBoolAnimation(MouvementJoueur player, bool walk, bool idle);

}
