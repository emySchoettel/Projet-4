using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementBas : EtatMouvementJoueur, Observer
{

    public static bool directionBas = false; 
    #region mouvement

    public override void Enter(MouvementJoueur player)
    {
        player.AddObserver(this);
        player.Notify();
    }

    public override void Update(MouvementJoueur player)
    {
        Move(player);
        if(directionBas)
        {
            x = Input.GetAxisRaw("Horizontal");
            z = Input.GetAxisRaw("Vertical");
            player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed;
        }
    }
    public override void Move(MouvementJoueur player)
    {
       
        animator = player.GetAnimator();

        //TODO modification input pour la console 
        
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && !directionBas)
        {
            directionBas = true; 
            player.GetAnimator().SetBool("WalkDown", true);
            player.GetAnimator().SetBool("IDLEDown", false);
        
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S) && directionBas)
        {
            directionBas = false; 
            player.GetAnimator().SetBool("WalkDown", false);
            player.GetAnimator().SetBool("IDLEDown", true);
        }
 
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z))
        {
            if(!directionBas)
            {
                animator.SetBool("WalkDown", false);
                animator.SetBool("IDLEDown", false);
                animator.SetBool("WalkUp", true);
                MouvementHaut.directionHaut = true; 
                player.StartState(player.etathaut);
            }
        }

        else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q))
        {
             if(!directionBas)
            {
                animator.SetBool("WalkDown", false);
                animator.SetBool("IDLEDown", false);
                animator.SetBool("WalkLeft", true);
                MouvementGauche.directionGauche = true; 
                player.StartState(player.etatgauche);
            }
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
             if(!directionBas)
            {
                animator.SetBool("WalkDown", false);
                animator.SetBool("IDLEDown", false);
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
        Debug.Log("Observer bas");
    }

    #endregion

}