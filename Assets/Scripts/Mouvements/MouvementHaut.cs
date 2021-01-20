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
    }

    public override void Update(MouvementJoueur player)
    {
        Move(player);
        if(directionHaut)
        {
            x = Input.GetAxisRaw("Horizontal");
            z = Input.GetAxisRaw("Vertical");
            player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed;  
        }
    }
    public override void Move(MouvementJoueur player)
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        animator = player.GetAnimator();
      
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) && !directionHaut)
        {
            directionHaut = true;
            player.GetAnimator().SetBool("WalkUp", true);
            player.GetAnimator().SetBool("IDLEUp", false);
    
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Z) && directionHaut)
        {
            directionHaut = false;
            player.GetAnimator().SetBool("IDLEUp", true);
            player.GetAnimator().SetBool("WalkUp", false);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if(!directionHaut)
            {
                animator.SetBool("WalkDown", true);
                animator.SetBool("IDLEUp", false);
                animator.SetBool("WalkUp", false);
                MouvementBas.directionBas = true; 
                player.StartState(player.etatbas);
            }
        }

        else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q))
        {
            if(!directionHaut)
            {
                MouvementGauche.directionGauche = true; 
                animator.SetBool("WalkLeft", true);
                animator.SetBool("IDLEUp", false);
                animator.SetBool("WalkUp", false);
                player.StartState(player.etatgauche);
            }
        
        }

         else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if(!directionHaut)
            {
                animator.SetBool("IDLEUp", false);
                animator.SetBool("WalkUp", false);
                animator.SetBool("WalkRight", true);
                MouvementDroite.directionDroite = true; 
                player.StartState(player.etatdroite);
            }
        
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