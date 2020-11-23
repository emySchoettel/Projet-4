using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_video : MonoBehaviour
{

    public Rigidbody theRB; 
    public float moveSpeed, jumpForce; 

    private Vector2 movement; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        movement.Normalize();

        theRB.velocity = new Vector3(movement.x * moveSpeed,theRB.velocity.y , movement.y * moveSpeed);
    }
}
