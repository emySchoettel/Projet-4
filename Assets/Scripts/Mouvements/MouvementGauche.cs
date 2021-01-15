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

    public override void Update(MouvementJoueur player)
    {

        Move(player);
    }
    public override void Move(MouvementJoueur player)
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("WalkLeft", true);
            animator.SetBool("IDLELeft", false);
        }
            
        else if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.Q))
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("IDLELeft", true);
        }
            

        player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed; 


        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("IDLELeft", false);
            animator.SetBool("WalkRight", true);
            player.StartState(player.etatdroite);
        }
        
        else if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z)) 
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("IDLELeft", false);
            animator.SetBool("WalkUp", true);
            player.StartState(player.etathaut);
        }
            

        else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
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
