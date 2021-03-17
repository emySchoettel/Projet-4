using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementBas : EtatMouvementJoueur, Observer
{
    #region mouvement

    public override void Enter(MouvementJoueur player)
    {
        player.AddObserver(this);
        player.direction = Helper.directions.bas;
        //player.Notify();
        animator = player.GetAnimator();
    }

    public override void canMove()
    {
        canMoveOnX = Mathf.Abs(x) > 0.5f; 
        canMoveOnZ = Mathf.Abs(z) > 0.5f;

        if(canMoveOnX && !canMoveOnZ || !canMoveOnX && canMoveOnZ)
            canMoveBool = true; 
        else
            canMoveBool = false; 
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
        //TODO modification input pour la console 
        if(canMoveBool && z == -1f && !canMoveOnX)
        {
            exitMouvement = false; 
            animator.SetBool("WalkDown", true);
            animator.SetBool("IDLEDown", false);
        
        }
        else if(!canMoveBool && z == 0f && !canMoveOnX)
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("IDLEDown", true);
            exitMouvement = true; 
        }

        if(canMoveOnX && canMoveOnZ)
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("IDLEDown", true);
        }

        if(x == -1f && !canMoveOnZ && canMoveOnX && canMoveBool)
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("IDLEDown", false);
            animator.SetBool("WalkLeft", true);
            exitMouvement = false; 
            player.StartState(player.etatgauche);
        }
        if(x == 1f && !canMoveOnZ && canMoveOnX && canMoveBool)
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("IDLEDown", false);
            animator.SetBool("WalkRight", true);
            exitMouvement = false; 
            player.StartState(player.etatdroite);
        } 
        if(z == 1f && canMoveOnZ && !canMoveOnX && canMoveBool)
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("IDLEDown", false);
            animator.SetBool("WalkUp", true);
            exitMouvement = false; 
            player.StartState(player.etathaut);
        }
    }

    #endregion

    #region Observer

    public void Notify()
    {
        Debug.Log("Observer bas");
    }

    #endregion

}