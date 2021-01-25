using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssaiMouvement : MonoBehaviour
{
    public float moveSpeed = 1;
    private bool PlayerMoving = false; 
    private Rigidbody myRigidBody; 
    private bool wasMovingVertical = true; 
    private Vector3 lastMove;

    private void Start() 
    {
        myRigidBody = gameObject.GetComponent<Rigidbody>(); 
    }

    
    void Update()
    {

        float currentMoveSpeed = moveSpeed * Time.deltaTime;

        float horizontal = Input.GetAxisRaw("Horizontal");
        bool isMovingHorizontal = Mathf.Abs(horizontal) > 0.5f;

        Debug.Log("Horizontal : " + Input.GetAxisRaw("Horizontal") );
        Debug.Log("Bool Horizontal : " + isMovingHorizontal);

        float vertical = Input.GetAxisRaw("Vertical");
        bool isMovingVertical = Mathf.Abs(vertical) > 0.5f;

        Debug.Log("vertical : " + Input.GetAxisRaw("Vertical") );
        Debug.Log("Bool vertical : " + isMovingVertical);

        PlayerMoving = true;

        if (isMovingVertical && !isMovingHorizontal || !isMovingVertical && isMovingHorizontal)
        {
            myRigidBody.velocity = new Vector3(horizontal, myRigidBody.velocity.y, vertical) * moveSpeed;
        }
    }
}
