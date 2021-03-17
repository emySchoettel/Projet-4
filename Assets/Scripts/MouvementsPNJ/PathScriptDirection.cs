using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PathScriptDirection : MonoBehaviour
{

    public Helper.directions directionIDLE; 
    public Transform[] target; 
    public Helper.directions[] directions; 
    public float speed;

    private int current = 0; 
    private bool nextOne = false; 
    public bool stop = false; 
    [SerializeField]
    private bool animationBool = false; 

    private Animator anim; 

    private void Awake() 
    {
        anim = GetComponent<Animator>();    
    }

    private void FixedUpdate() 
    {
        if(transform.position != target[current].position || !nextOne || !stop)
        {
            //traitement de la direction
            if(changeAnimationWithBool())
            {
                //traitement du déplacement 
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }   
        }
        else if (stop)
        {
           GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
        else
        {
            nextOne = false;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Path") && other.gameObject.name == target[current].name)    
        {
            nextOne = true; 
            current = (current + 1) % target.Length;
            Debug.Log("nextone  : " + nextOne);
        }
        else if(other.CompareTag("Player"))
        {
            stop = true; 
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            if(!animationBool)
            {
                changeAnimation(GameObject.FindGameObjectWithTag("Player").GetComponent<MouvementJoueur>().direction, true);
                animationBool = true; 
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        Debug.Log("leave");
        if(other.CompareTag("Player"))
        {
            stop = false; 
            changeAnimation(GameObject.FindGameObjectWithTag("Player").GetComponent<MouvementJoueur>().direction, false);
            animationBool = false;
        }
    }

    //changer animation juste pour le pnj
    private bool changeAnimationWithBool()
    {
        bool res = false; 
        if(anim != null)
        {
             switch(directions[current])
            {
                case Helper.directions.droite:
                    anim.SetBool("right", true);
                    anim.SetBool("down", false);
                    anim.SetBool("left", false);
                    anim.SetBool("up", false);
                    anim.SetBool("idleright", false);
                break;
                case Helper.directions.gauche:
                    anim.SetBool("left", true);
                    anim.SetBool("down", false);
                    anim.SetBool("right", false);
                    anim.SetBool("up", false);
                    anim.SetBool("idleleft", false);
                break;
                case Helper.directions.bas:
                    anim.SetBool("down", true);
                    anim.SetBool("right", false);
                    anim.SetBool("left", false);
                    anim.SetBool("up", false);
                    anim.SetBool("idledown", false);
                break;
                case Helper.directions.haut:
                    anim.SetBool("up", true);
                    anim.SetBool("down", false);
                    anim.SetBool("left", false);
                    anim.SetBool("right", false);
                    anim.SetBool("idleup", false);
                break;
            }
            res = true; 
        }
        return res; 
    }

    //changer animation selon le player
    private void changeAnimation(Helper.directions unedirection, bool choix)
    {
        
        switch(unedirection)
        {
            case Helper.directions.droite:
                directionIDLE = Helper.directions.gauche; 
                anim.SetBool("idleleft", choix);
            break;
            case Helper.directions.gauche:
                directionIDLE = Helper.directions.droite;
                anim.SetBool("idleright", choix);
            break;
            case Helper.directions.bas:
                directionIDLE = Helper.directions.haut;
                anim.SetBool("idleup", choix);
            break;
            case Helper.directions.haut:
                directionIDLE = Helper.directions.bas;
                anim.SetBool("idledown", choix);
            break;
        
        }
        anim.SetBool("up", false);
        anim.SetBool("down", false);
        anim.SetBool("left", false);
        anim.SetBool("right", false);
    }
}
