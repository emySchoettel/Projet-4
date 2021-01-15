using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementHaut : EtatMouvementJoueur, Observer
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
      
      //Input principal
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z))
        {
            player.GetAnimator().SetBool("WalkUp", true);
            player.GetAnimator().SetBool("IDLEUp", false);
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Z))
        {
            player.GetAnimator().SetBool("IDLEUp", true);
            player.GetAnimator().SetBool("WalkUp", false);

        }

        //Input secondaires
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            player.GetAnimator().SetBool("IDLEUp", false);
            player.GetAnimator().SetBool("WalkUp", false);
            animator.SetBool("WalkRight", true);
            player.StartState(player.etatdroite);
        }
            
        else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
            player.GetAnimator().SetBool("IDLEUp", false);
            player.GetAnimator().SetBool("WalkUp", false);
            animator.SetBool("WalkDown", true);
            player.StartState(player.etatbas);

            }

        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            player.GetAnimator().SetBool("IDLEUp", false);
            player.GetAnimator().SetBool("WalkUp", false);
            animator.SetBool("WalkLeft", true);
            player.StartState(player.etatgauche);

        }

        player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed; 
    }

    #endregion

    #region Observer

    public void Notify()
    {
        Debug.Log("Observer ENTER Haut");
    }

    #endregion

}