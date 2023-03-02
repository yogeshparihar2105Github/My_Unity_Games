using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed = 2f;
    private Rigidbody2D rb;

    public Transform keyFollowPoint;
    public Key followingKey;

    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        movementJoystick = FindObjectOfType<MovementJoystick>();
        rb = GetComponent<Rigidbody2D>();
        keyFollowPoint = GetComponent<Transform>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        // //movement onScreen Joystick
        // if(movementJoystick.joyStickVector.y != 0)
        // {
        //     rb.velocity = new Vector2(movementJoystick.joyStickVector.x * playerSpeed, movementJoystick.joyStickVector.y * playerSpeed);
        //     Flip();
        //     myAnimator.SetBool("IsMoving", true);
        // }
        //movement keyboard
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontal, vertical);

            rb.AddForce(movement * playerSpeed * 60f);
            Flip();
            myAnimator.SetBool("IsMoving", true);
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = Vector2.zero;
            myAnimator.SetBool("IsMoving", false);
        }
    }

    private void Flip()
    {
        if (rb.velocity.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
