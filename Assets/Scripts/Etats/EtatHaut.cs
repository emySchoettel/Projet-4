using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatHaut : EtatMouvementJoueur, Observer
{

    #region mouvement

    public override void Enter(MouvementJoueur player)
    {
        player.AddObserver(this);
        player.Notify();
    }

    public override void Update(MouvementJoueur player)
    {

        Move(player);
    }
    public override void Move(MouvementJoueur player)
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        animator = player.GetAnimator();
      
      //I,put principal
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.GetAnimator().SetBool("WalkUp", true);
            player.GetAnimator().SetBool("IDLEUp", false);
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            player.GetAnimator().SetBool("IDLEUp", true);
            player.GetAnimator().SetBool("WalkUp", false);

        }

        //Input secondaires
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.GetAnimator().SetBool("IDLEUp", false);
            player.GetAnimator().SetBool("WalkUp", false);
            animator.SetBool("WalkRight", true);
            player.StartState(player.etatdroite);
        }
            
        else if(Input.GetKey(KeyCode.DownArrow))
            {
            player.GetAnimator().SetBool("IDLEUp", false);
            player.GetAnimator().SetBool("WalkUp", false);
            animator.SetBool("WalkDown", true);
            player.StartState(player.etatbas);

            }

        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            player.GetAnimator().SetBool("IDLEUp", false);
            player.GetAnimator().SetBool("WalkUp", false);
            animator.SetBool("WalkLeft", true);
            player.StartState(player.etatgauche);

        }

        player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed; 
    }

    // Fonction qui permet de set les parametres pour marcher ou IDLE
    public override void setBoolAnimation(MouvementJoueur player, bool walk, bool idle)
    {
        Animator anim = player.GetAnimator();
        anim.SetBool(parametersNames.WalkUp.ToString(), walk);
        anim.SetBool(parametersNames.IDLEUp.ToString(), idle);
    }

    #endregion

    #region Observer

    public void Notify()
    {
        Debug.Log("Observer ENTER Haut");
    }

    #endregion

}