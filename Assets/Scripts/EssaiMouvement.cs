using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssaiMouvement : MonoBehaviour
{
    public float moveSpeed = 2;
    private bool PlayerMoving = false; 
    private Rigidbody myRigidBody; 
    private bool wasMovingVertical = true; 
    private Vector3 lastMove;

    private void Start() 
    {
        myRigidBody = gameObject.GetComponent<Rigidbody>(); 
        lastMove = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    
    void Update()
    {

        float currentMoveSpeed = moveSpeed * Time.deltaTime;

        float horizontal = Input.GetAxisRaw("Horizontal");
        bool isMovingHorizontal = Mathf.Abs(horizontal) > 0.5f;

        float vertical = Input.GetAxisRaw("Vertical");
        bool isMovingVertical = Mathf.Abs(vertical) > 0.5f;

        PlayerMoving = true;
        Debug.Log("Horizontal : " + isMovingHorizontal);
        Debug.Log("Vertical : " + isMovingVertical);

        if (isMovingVertical || isMovingHorizontal)
        {
            //moving in both directions, prioritize later
            if (wasMovingVertical)
            {
                myRigidBody.velocity = new Vector2(horizontal * currentMoveSpeed, 0);
                lastMove = new Vector3(horizontal, transform.position.y, 0f);
            }
            else
            {
                myRigidBody.velocity = new Vector2(0, vertical * currentMoveSpeed);
                lastMove = new Vector3(0f, transform.position.y, vertical);
            }
        }
        else if (isMovingHorizontal)
        {
            myRigidBody.velocity = new Vector2(horizontal * currentMoveSpeed, 0);
            wasMovingVertical = false;
            lastMove = new Vector3(horizontal, transform.position.y, 0f);
        }
        else if (isMovingVertical)
        {
            myRigidBody.velocity = new Vector2(0, vertical * currentMoveSpeed);
            wasMovingVertical = true;
            lastMove = new Vector3(0f, transform.position.y, vertical);
        }
        else
        {
            PlayerMoving = false;
            myRigidBody.velocity = Vector3.zero;
        }
        Debug.Log(lastMove);

    }
}
