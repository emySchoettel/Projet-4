using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_Movement : MonoBehaviour
{

    private Rigidbody rb;
    public Animator animator; 

    public float speed; 

    private Vector3 movement; 

    private int stateDirection = 0;

    [SerializeField]
    private Sprite[] spriteArray; 

    private Sprite actualSprite; 

    private CharacterController controller;

    private void Start() {
        controller = GetComponent<CharacterController>();
    }
    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        if(Input.anyKey)
        {
            string currentInput = Input.inputString;

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
            Vector3 movement = new Vector3 (moveHorizontal, 0,moveVertical);
                    
            rb.velocity = movement * speed;
        }
        else
        {
            animator.SetInteger("Direction", 5);
           // GetComponent<SpriteRenderer>().sprite = changeSprite(stateDirection);
        }
    }

    // public Sprite changeSprite(int direction)
    // { 
    //     print(stateDirection);
    //     print(direction);
    //     Sprite newSprite = GetComponent<SpriteRenderer>().sprite;
    //     print(newSprite.name);
    //     switch(stateDirection)
    //     {
    //         case 1:
    //             newSprite = spriteArray[0];
    //             print(newSprite.name);
    //         break; 

    //         case 2 : 
    //             newSprite = spriteArray[1];
    //             print(newSprite.name);

    //         break;
    //         case 3:
    //             newSprite = spriteArray[3];
    //             print(newSprite.name);
    //         break; 
    //         case 4:
    //         newSprite = spriteArray[2];
    //             print(newSprite.name);
                
    //         break; 
            
    //     }
    //     return newSprite; 
    // }

    public int getDirection()
    {
        return stateDirection;
    }

}
