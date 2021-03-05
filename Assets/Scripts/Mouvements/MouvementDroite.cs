using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementDroite : EtatMouvementJoueur, Observer
{
    public override void Enter(MouvementJoueur player)
    {
        Debug.Log("enter");
        player.AddObserver(this);
        //player.Notify();
        animator = player.GetAnimator();
        //player.GetAnimator().Play("IDLE right");
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

        canMove();
        Move(player);
        if(EtatMouvementJoueur.canMoveBool && !exitMouvement)
        {
            //player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed;
            player.getRigidBody().velocity = new Vector3(x, 0, z) * player.speed; 
        }
    }

    public override void Move(MouvementJoueur player)
    {
        if(x == 1f && EtatMouvementJoueur.canMoveBool && !canMoveOnZ)
        {
            exitMouvement = false; 
            animator.SetBool("WalkRight", true);
            animator.SetBool("IDLERight", false);
        }
        
        else if (x == 0 && !EtatMouvementJoueur.canMoveBool && !canMoveOnZ)
        {
            exitMouvement = true; 
            animator.SetBool("WalkRight", false);
            animator.SetBool("IDLERight", true);

        }

        if(canMoveOnX && canMoveOnZ)
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("IDLERight", true);
        }
        
        if(z == -1f && canMoveOnZ && !canMoveOnX)
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("IDLERight", false);
            animator.SetBool("WalkDown", true);
            exitMouvement = false; 
            player.StartState(player.etatbas);
        }
        
        if(x == -1f && !canMoveOnZ && canMoveOnX)
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("IDLERight", false);
            animator.SetBool("WalkLeft", true);
            exitMouvement = false; 
            player.StartState(player.etatgauche);
        } 

        if(z == 1f && canMoveOnZ && !canMoveOnX)
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("IDLERight", false);
            animator.SetBool("WalkUp", true);
            exitMouvement = false; 
            player.StartState(player.etathaut);
        }
    }

    public void Notify()
    {
        Debug.Log("Observer Etat droit");
    }

}
