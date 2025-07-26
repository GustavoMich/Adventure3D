using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody myRigidbody;
    bool left, forward, backward, right;
    bool grounded, jump;
    public float speed, maxSpeed, drag;
    public float jumpForce;
    public LayerMask ground;
     

    public bool canMove = false;
    public bool cantJump = true;


    private void Update()
    {
        
        HandleInput();
        LimitVelocity();
        HandleDrag();
        CheckGrounded();
    }

    private void LimitVelocity()
    {
        Vector3 horizontalVelocity = new Vector3(myRigidbody.velocity.x, 0, myRigidbody.velocity.z);
        if(horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = horizontalVelocity.normalized * maxSpeed;
            myRigidbody.velocity = new Vector3(limitedVelocity.x, myRigidbody.velocity.y, limitedVelocity.z);
        }
    }

    private void HandleDrag()
    {
        myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, 0, myRigidbody.velocity.z) / (1 + drag / 100) + new Vector3(0, myRigidbody.velocity.y, 0);
    }

    private void CheckGrounded()
    {
        grounded = Physics.Raycast(transform.position + Vector3.up * .1f, Vector3.down, .2f, ground);
    }

    private void FixedUpdate()
    {
        if (!canMove) return;
        {

          if (left)
          {
            myRigidbody.AddForce(Vector3.left * speed);
            {
                left = false;
            }
          }

          if (right)
          {
            myRigidbody.AddForce(Vector3.right * speed);
            {
                right = false;
            }
          }

          if (forward)
          {
            myRigidbody.AddForce(Vector3.forward * speed);
            {
                forward = false;
            }
          }

          if (backward)
          {
            myRigidbody.AddForce(Vector3.back * speed);
            {
                backward = false;
            }
          }


            if (!cantJump)
          if(jump)
          {
            transform.position += Vector3.up * .1f;
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, 0, myRigidbody.velocity.y);
            myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
          }
        }
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            forward = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            backward = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
    }
}
