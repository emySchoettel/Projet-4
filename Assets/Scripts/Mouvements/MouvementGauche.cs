using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementGauche : EtatMouvementJoueur, Observer
{
    #region mouvement

    public override void Enter(MouvementJoueur player)
    {
        player.AddObserver(this);
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

        canMove();
        Move(player);   
        if(EtatMouvementJoueur.canMoveBool)
        {  
            //player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed;
            player.getRigidBody().velocity = new Vector3(x, 0, z) * player.speed;  
        }
    }
    public override void Move(MouvementJoueur player)
    {
        if(x == -1f && EtatMouvementJoueur.canMoveBool && !canMoveOnZ)
        {
            animator.SetBool("WalkLeft", true);
            animator.SetBool("IDLELeft", false);
        }
            
        else if(x == 0 && !EtatMouvementJoueur.canMoveBool && !canMoveOnZ)
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("IDLELeft", true);
        }
        
        if (x == 1f && EtatMouvementJoueur.canMoveBool && !canMoveOnZ)
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("IDLELeft", false);
            animator.SetBool("WalkRight", true);
            player.StartState(player.etatdroite);    
        }
        
        else if(z == 1f && EtatMouvementJoueur.canMoveBool && !canMoveOnX) 
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("IDLELeft", false);
            animator.SetBool("WalkUp", true);
            player.StartState(player.etathaut); 
        }
        else if(z == -1f && EtatMouvementJoueur.canMoveBool && !canMoveOnX)
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("IDLELeft", false);
            animator.SetBool("WalkDown", true);
            player.StartState(player.etatbas); 
        } 
    }
   
    #endregion

    #region Observer

    public void Notify()
    {
        Debug.Log("Observer Etat gauche");
    }

    #endregion

}
