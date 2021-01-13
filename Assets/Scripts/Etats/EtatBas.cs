using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatBas : EtatMouvementJoueur, Observer
{

    #region mouvement

    public override void Enter(MouvementJoueur player)
    {
        player.AddObserver(this);
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
      
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.GetAnimator().SetBool("WalkDown", true);
            player.GetAnimator().SetBool("IDLEDown", false);
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            player.GetAnimator().SetBool("IDLEDown", true);
            player.GetAnimator().SetBool("WalkDown", false);

        }

           
            if (Input.GetKey(KeyCode.RightArrow))
            {
                player.GetAnimator().SetBool("IDLEDown", false);
                player.GetAnimator().SetBool("WalkDown", false);
                animator.SetBool("WalkRight", true);
                player.StartState(player.etatdroite);
            }
                
            else if(Input.GetKey(KeyCode.UpArrow))
             {
                player.GetAnimator().SetBool("IDLEDown", false);
                player.GetAnimator().SetBool("WalkDown", false);
                animator.SetBool("WalkUp", true);
                player.StartState(player.etathaut);

             }

            else if(Input.GetKey(KeyCode.LeftArrow))
            {
                player.GetAnimator().SetBool("IDLEDown", false);
                player.GetAnimator().SetBool("WalkDown", false);
                animator.SetBool("WalkLeft", true);
                player.StartState(player.etatgauche);

            }

          player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed; 

    }

    // Fonction qui permet de set les parametres pour marcher ou IDLE
    public override void setBoolAnimation(MouvementJoueur player, bool walk, bool idle)
    {

    }


    #endregion

    #region Observer

    public void Notify()
    {
        Debug.Log("Observer bas");
    }

    #endregion

}