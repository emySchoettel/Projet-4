using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementHaut : EtatMouvementJoueur, Observer
{

    public static bool directionHaut = false; 
    #region mouvement

    public override void Enter(MouvementJoueur player)
    {
        player.AddObserver(this);
        player.Notify();
        animator = player.GetAnimator();
    }

    public override void canMove()
    {
        canMoveOnX = Mathf.Abs(x) > 0.5f; 
        canMoveOnZ = Mathf.Abs(z) > 0.5f;

        if(canMoveOnX && !canMoveOnZ || !canMoveOnX && canMoveOnZ)
            EtatMouvementJoueur.canMoveBool = true; 
        else
            EtatMouvementJoueur.canMoveBool = false; 
    }


    public override void Update(MouvementJoueur player)
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Move(player);
        canMove();

        if(EtatMouvementJoueur.canMoveBool)
        {
            player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed;  
        }
    }
    public override void Move(MouvementJoueur player)
    {  
        if(z == 1f && EtatMouvementJoueur.canMoveBool)
        {
            player.GetAnimator().SetBool("WalkUp", true);
            player.GetAnimator().SetBool("IDLEUp", false);
    
        }
        else if(EtatMouvementJoueur.canMoveBool && z == 0)
        {
            player.GetAnimator().SetBool("IDLEUp", true);
            player.GetAnimator().SetBool("WalkUp", false);
        }

        if(z == -1f && EtatMouvementJoueur.canMoveBool && !canMoveOnX)
        {
            animator.SetBool("WalkDown", true);
            animator.SetBool("IDLEUp", false);
            animator.SetBool("WalkUp", false);
            player.StartState(player.etatbas);
        }

        else if(x == -1f && EtatMouvementJoueur.canMoveBool && !canMoveOnZ)
        {
            animator.SetBool("WalkLeft", true);
            animator.SetBool("IDLEUp", false);
            animator.SetBool("WalkUp", false);
            player.StartState(player.etatgauche);

        }

         else if(x == 1f && EtatMouvementJoueur.canMoveBool && !canMoveOnZ)
        {
            animator.SetBool("IDLEUp", false);
            animator.SetBool("WalkUp", false);
            animator.SetBool("WalkRight", true);
            player.StartState(player.etatdroite);
        
        }

    }

    #endregion

    #region Observer

    public void Notify()
    {
        Debug.Log("Observer ENTER Haut");
    }

    #endregion

}