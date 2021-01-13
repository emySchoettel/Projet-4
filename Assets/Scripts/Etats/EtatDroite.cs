using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatDroite : EtatMouvementJoueur, Observer
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

          if(Input.GetKeyDown(KeyCode.RightArrow)){
               animator.SetBool("WalkRight", true);
                animator.SetBool("IDLERight", false);

          }
          
        else if (Input.GetKeyUp(KeyCode.RightArrow)){
             animator.SetBool("WalkRight", false);
                animator.SetBool("IDLERight", true);

        }
            
        player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed; 

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("IDLERight", false);
            animator.SetBool("WalkRight", false);
            animator.SetBool("WalkLeft", true);

            player.StartState(player.etatgauche);
        
        }
                
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("IDLERight", false);
            animator.SetBool("WalkRight", false);
            animator.SetBool("WalkUp", true);
            player.StartState(player.etathaut);
        }
            

        else if(Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("IDLERight", false);
            animator.SetBool("WalkRight", false);
            animator.SetBool("WalkDown", true);
            player.StartState(player.etatbas);
        }
       

    }

    // Fonction qui permet de set les parametres pour marcher ou IDLE
    public override void setBoolAnimation(MouvementJoueur player, bool walk, bool idle)
    {
    }


    public void Notify()
    {
        Debug.Log("Observer Etat droit");
    }

}
