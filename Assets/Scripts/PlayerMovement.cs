using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour

{
    //Speed (How Fast The Player Navigates On The Game
    public float moveSpeed;

    //Rigidbody (Handles Physics)
    public Rigidbody2D rigidBody;

    //Dictates where the player is moving
    private Vector3 movementInput;

    //To play animations
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            anim.SetTrigger("BackwardAnimation");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetTrigger("Backward_Pause");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("ForwardAnimation");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetTrigger("Forward_Pause");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("RightAnimation");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetTrigger("Right_Pause");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("LeftAnimation");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetTrigger("Left_Pause");
        }
    }
    //Fixed Update for physics calculations
    private void FixedUpdate()
    {
        //Makes the player move
        rigidBody.velocity = movementInput * moveSpeed;
    }
    // To get the Input System Clicks
    private void OnMove(InputValue inputValue)
    {
        //Converts WASD to vector 2 values
        movementInput = inputValue.Get<Vector2>();
    }
}
