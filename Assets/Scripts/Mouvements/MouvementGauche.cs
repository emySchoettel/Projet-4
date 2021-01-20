using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementGauche : EtatMouvementJoueur, Observer
{
    public static bool directionGauche = false; 

    #region mouvement

    public override void Enter(MouvementJoueur player)
    {
        player.AddObserver(this);
        animator = player.GetAnimator();
    }

    public override void Update(MouvementJoueur player)
    {
        Move(player);
        if(directionGauche)
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

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q) && !directionGauche)
        {
            directionGauche = true;
            animator.SetBool("WalkLeft", true);
            animator.SetBool("IDLELeft", false);
        }
            
        else if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.Q) && directionGauche)
        {
            directionGauche = false; 
            animator.SetBool("WalkLeft", false);
            animator.SetBool("IDLELeft", true);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if(!directionGauche)
            {
                animator.SetBool("WalkLeft", false);
                animator.SetBool("IDLELeft", false);
                animator.SetBool("WalkRight", true);
                MouvementDroite.directionDroite = false;
                player.StartState(player.etatdroite);    
            }
        }
        
        else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z)) 
        {
            if(!directionGauche)
            {
                animator.SetBool("WalkLeft", false);
                animator.SetBool("IDLELeft", false);
                animator.SetBool("WalkUp", true);
                MouvementHaut.directionHaut = true; 
                player.StartState(player.etathaut);
            }
        }
            

        else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if(!directionGauche)
            {
                animator.SetBool("WalkLeft", false);
                animator.SetBool("IDLELeft", false);   
                animator.SetBool("WalkDown", true);
                MouvementBas.directionBas = true;
                player.StartState(player.etatbas);
            }
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
