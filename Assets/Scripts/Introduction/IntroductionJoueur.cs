using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionJoueur : MonoBehaviour
{

    private Animator anim; 
    public Helper.directions ladirection; 
    public Helper.directions[] directions; 
    private int current = 0, tour = 0; 

    public Transform[] target;

    [SerializeField]
    private bool nextOne = false;
    public bool stop = true; 
    [SerializeField]
    private float speed = 2;

    public IntroductionManager introductionManager;



    private void Start() 
    {
        anim = GetComponent<Animator>() ? GetComponent<Animator>() : null; 
        StartCoroutine(introductionManager.ShowText(introductionManager.GetDialogues(), 0));
        stop = false; 
    }

    private void FixedUpdate() 
    {

        if((transform.position != target[current].position || !nextOne) && !stop)
        {
            //traitement de la direction
            if(changeAnimation())
            {
                //traitement du déplacement 
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }   
        }
        else if (stop)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
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
        }
    }
     private bool changeAnimation()
    {   
        bool res = false; 
            if(anim != null)
            {
                switch(directions[current])
                {
                    case Helper.directions.droite:
                        anim.SetBool("WalkRight", true);
                        anim.SetBool("WalkDown", false);
                        anim.SetBool("WalkLeft", false);
                        anim.SetBool("WalkUp", false);
                        
                    break;
                    case Helper.directions.gauche:
                        anim.SetBool("WalkLeft", true);
                        anim.SetBool("WalkDown", false);
                        anim.SetBool("WalkRight", false);
                        anim.SetBool("WalkUp", false);
                        
                    break;
                    case Helper.directions.bas:
                        anim.SetBool("WalkDown", true);
                        anim.SetBool("WalkRight", false);
                        anim.SetBool("WalkLeft", false);
                        anim.SetBool("WalkUp", false);
                        
                    break;
                    case Helper.directions.haut:
                        anim.SetBool("WalkUp", true);
                        anim.SetBool("WalkDown", false);
                        anim.SetBool("WalkLeft", false);
                        anim.SetBool("WalkRight", false);
                        
                    break;
                }
                anim.SetBool("IDLERight", false);
                anim.SetBool("IDLELeft", false);
                anim.SetBool("IDLEDown", false);
                anim.SetBool("IDLEUp", false);
                res = true; 
            }
    return res; 
    }

    public int getTour()
    {
        return tour; 
    }
}
