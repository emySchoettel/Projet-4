using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementDroite : EtatMouvementJoueur, Observer
{
    public override void Enter(MouvementJoueur player)
    {
        player.AddObserver(this);
        player.Notify();
        animator = player.GetAnimator();
        //player.GetAnimator().Play("IDLE right");
    }

    public override void Update(MouvementJoueur player)
    {
        Move(player);
    }

    public override void Move(MouvementJoueur player)
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

       
            if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                animator.SetBool("WalkRight", true);
                animator.SetBool("IDLERight", false);
            }
          
            else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("WalkRight", false);
                animator.SetBool("IDLERight", true);

            }

            if (Input.GetKey(KeyCode.LeftArrow) ||Input.GetKey(KeyCode.Q))
            {
                animator.SetBool("IDLERight", false);
                animator.SetBool("WalkRight", false);
                animator.SetBool("WalkLeft", true);

                player.StartState(player.etatgauche);
            }
                    
            else if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z))
            {
                animator.SetBool("IDLERight", false);
                animator.SetBool("WalkRight", false);
                animator.SetBool("WalkUp", true);

                player.StartState(player.etathaut);
            }
                

            else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                animator.SetBool("IDLERight", false);
                animator.SetBool("WalkRight", false);
                animator.SetBool("WalkDown", true);

                player.StartState(player.etatbas);
            }

            player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed; 
    }


    public void Notify()
    {
        Debug.Log("Observer Etat droit");
    }

}
