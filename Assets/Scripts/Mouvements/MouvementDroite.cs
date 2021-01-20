using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementDroite : EtatMouvementJoueur, Observer
{
    public static bool directionDroite = false; 
    public override void Enter(MouvementJoueur player)
    {
        player.AddObserver(this);
        player.Notify();
        animator = player.GetAnimator();
        //player.GetAnimator().Play("IDLE right");
    }

    public override void Update(MouvementJoueur player)
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Move(player);
        if(directionDroite)
        {
              player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed; 
        }
    }

    public override void Move(MouvementJoueur player)
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && !directionDroite)
        {
            directionDroite = true; 
            animator.SetBool("WalkRight", true);
            animator.SetBool("IDLERight", false);
            Debug.Log(directionDroite);
        }
        
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D) && directionDroite)
        {
            directionDroite = false; 
            animator.SetBool("WalkRight", false);
            animator.SetBool("IDLERight", true);
            Debug.Log(directionDroite);

        }

        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if(!directionDroite)
            {
                animator.SetBool("IDLERight", false);
                animator.SetBool("WalkRight", false);
                animator.SetBool("WalkDown", true);
                MouvementBas.directionBas = true; 
                player.StartState(player.etatbas);
            }
        }

        else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q) )
        {
            if(!directionDroite)
            {
                animator.SetBool("IDLERight", false);
                animator.SetBool("WalkRight", false);
                animator.SetBool("WalkLeft", true);
                MouvementGauche.directionGauche = true; 
                player.StartState(player.etatgauche);
            }
        }
        
        else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) )
        {
            if(!directionDroite)
            {
                animator.SetBool("IDLERight", false);
                animator.SetBool("WalkRight", false);
                animator.SetBool("WalkUp", true);
                MouvementHaut.directionHaut = true; 
                player.StartState(player.etathaut);
            }
        
        }         
    }

    public void Notify()
    {
        Debug.Log("Observer Etat droit");
    }

}
