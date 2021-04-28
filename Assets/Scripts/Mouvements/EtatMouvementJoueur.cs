using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EtatMouvementJoueur  
{
    protected static float x, z;
    protected Helper.sol sol; 

    protected int audioIndex; 

    protected static bool canMoveBool, canMoveOnX, canMoveOnZ, exitMouvement = false; 
    protected Animator animator;
    public abstract void Enter(MouvementJoueur player);
    public abstract void Update(MouvementJoueur player);  
    public abstract void Move(MouvementJoueur player); 

    public abstract void setSol(Helper.sol sol, MouvementJoueur player, int audioIndex);

    public abstract void canMove();
}
