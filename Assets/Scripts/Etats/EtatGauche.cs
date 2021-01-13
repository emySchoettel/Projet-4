using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatGauche : EtatMouvementJoueur, Observer
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

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
             animator.SetBool("WalkLeft", true);
            animator.SetBool("IDLELeft", false);
        }
            
        else if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
             animator.SetBool("WalkLeft", false);
            animator.SetBool("IDLELeft", true);
        }
            

        player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed; 


        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("IDLELeft", false);
            animator.SetBool("WalkRight", true);
            player.StartState(player.etatdroite);
        }
        
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("IDLELeft", false);
            animator.SetBool("WalkUp", true);
            player.StartState(player.etathaut);
        }
            

        else if(Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("IDLELeft", false);   
            animator.SetBool("WalkDown", true);
            player.StartState(player.etatbas);
        }
        

    }

    // Fonction qui permet de set les parametres pour marcher ou IDLE
    public override void setBoolAnimation(MouvementJoueur player, bool walk, bool idle)
    {
        Animator anim = player.GetAnimator();
        anim.SetBool(parametersNames.WalkLeft.ToString(), walk);
        anim.SetBool(parametersNames.IDLELeft.ToString(), idle);
    }


    #endregion

    #region Observer

    public void Notify()
    {
        Debug.Log("Observer Etat gauche");
    }

    #endregion

}
