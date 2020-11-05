using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class Player_Movement : MonoBehaviour
{

    private Rigidbody rb;
    public Animator animator; 

    public float speed; 

    private Vector3 movement; 

    private int stateDirection;

    private void Start() {

    }
    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        stateDirection = 0; 
    }

    private void Update() 
    {
        if(Input.anyKey)
        {
            string currentInput = Input.inputString;
            print(currentInput);
            switch(currentInput)
            {
                case "s" : 
                stateDirection = 1;
                animator.SetInteger("Direction", stateDirection);
                break; 

                case "z":
                stateDirection = 2;
                animator.SetInteger("Direction", stateDirection);
                break; 

                case "q":
                stateDirection = 3; 
                animator.SetInteger("Direction", stateDirection);
               
                break;

                case "d":
                stateDirection = 4;
                animator.SetInteger("Direction", stateDirection);
                break;

                default:
                animator.SetInteger("Direction", 0);
                break;
            }
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
                    
            rb.velocity = movement * speed;
           //rb.MovePosition( movement * speed);
        }
        else
        {
            animator.SetInteger("Direction", 5);
        
        }
    }

}
