using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementDroite : EtatMouvementJoueur, Observer
{
    public override void Enter(MouvementJoueur player)
    {
        player.AddObserver(this);
        player.direction = Helper.directions.droite; 
        //player.Notify();
        animator = player.GetAnimator();
        //player.GetAnimator().Play("IDLE right");
    }

    public override void canMove()
    {
        canMoveOnX = Mathf.Abs(x) > 0.5f; 
        canMoveOnZ = Mathf.Abs(z) > 0.5f;

        if(canMoveOnX && !canMoveOnZ || !canMoveOnX && canMoveOnZ)
            EtatMouvementJoueur.canMoveBool = true; 
        else
            EtatMouvementJoueur.canMoveBool = false; 
    }

    public override void Update(MouvementJoueur player)
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        canMove();
        Move(player);
        if(EtatMouvementJoueur.canMoveBool && !exitMouvement)
        {
            //player.getRigidBody().velocity = new Vector3(x, player.getRigidBody().velocity.y, z) * player.speed;
            player.getRigidBody().velocity = new Vector3(x, 0, z) * player.speed; 
        }else
        {
            player.GetAudioManager().muteAudio(true, audioIndex);
        }
    }

    public override void Move(MouvementJoueur player)
    {
        player.GetAudioManager().muteAudio(false, audioIndex);
        if (x == 1f && EtatMouvementJoueur.canMoveBool && !canMoveOnZ)
        {
            exitMouvement = false; 
            animator.SetBool("WalkRight", true);
            animator.SetBool("IDLERight", false);
        }
        
        else if (x == 0 && !EtatMouvementJoueur.canMoveBool && !canMoveOnZ)
        {
            exitMouvement = true; 
            animator.SetBool("WalkRight", false);
            animator.SetBool("IDLERight", true);

        }

        if(canMoveOnX && canMoveOnZ)
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("IDLERight", true);
        }
        
        if(z == -1f && canMoveOnZ && !canMoveOnX)
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("IDLERight", false);
            animator.SetBool("WalkDown", true);
            exitMouvement = false; 
            player.StartState(player.etatbas);
        }
        
        if(x == -1f && !canMoveOnZ && canMoveOnX)
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("IDLERight", false);
            animator.SetBool("WalkLeft", true);
            exitMouvement = false; 
            player.StartState(player.etatgauche);
        } 

        if(z == 1f && canMoveOnZ && !canMoveOnX)
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("IDLERight", false);
            animator.SetBool("WalkUp", true);
            exitMouvement = false; 
            player.StartState(player.etathaut);
        }
    }

    
       public override void setSol(Helper.sol sol, MouvementJoueur player, int audioIndex)
    {
        this.sol = sol;
        this.audioIndex = audioIndex;
        switch(sol)
        {
            case Helper.sol.terre: 
                AudioClip audioclip = player.GetAudioManager().GetAudioClip(1);
                if(audioclip != null)
                {
                    player.GetAudioManager().setAudio(audioclip, audioIndex);
                    player.GetAudioManager().setAudioVolume(audioIndex, 0.01f);
                    player.GetAudioManager().playAudio(audioIndex);
                }
            break; 
        }
    }
    public void Notify()
    {
        Debug.Log("Observer Etat droit");
    }

}
