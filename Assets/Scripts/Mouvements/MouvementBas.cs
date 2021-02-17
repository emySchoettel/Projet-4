using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementBas : EtatMouvementJoueur, Observer
{
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

        Debug.Log(" x : " + x );
        Debug.Log(" z : " + z );

        canMove();
        Move(player);
        if(EtatMouvementJoueur.canMoveBool)
        {
            player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed;
            //player.getRigidBody().velocity = new Vector3(x, 0, z) * player.speed;
        }
    }
    public override void Move(MouvementJoueur player)
    {
        //TODO modification input pour la console 
        Debug.Log("Can move bool : " + EtatMouvementJoueur.canMoveBool);
        
        if(EtatMouvementJoueur.canMoveBool && z == -1f && !canMoveOnX)
        {
            animator.SetBool("WalkDown", true);
            animator.SetBool("IDLEDown", false);
        
        }
        else if(!EtatMouvementJoueur.canMoveBool && z == 0f && !canMoveOnX)
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("IDLEDown", true);
        }
 
        if(z == 1f && EtatMouvementJoueur.canMoveBool && !canMoveOnX)
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("IDLEDown", false);
            animator.SetBool("WalkUp", true);
            player.StartState(player.etathaut);
        }

        else if(x == -1f && EtatMouvementJoueur.canMoveBool && !canMoveOnZ)
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("IDLEDown", false);
            animator.SetBool("WalkLeft", true);
            player.StartState(player.etatgauche);
        }

        else if(x == 1f && EtatMouvementJoueur.canMoveBool && !canMoveOnZ)
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("IDLEDown", false);
            animator.SetBool("WalkRight", true);
            player.StartState(player.etatdroite);
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