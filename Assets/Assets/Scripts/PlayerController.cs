using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpSpeed = 5;

    bool canJump = false;

    InputData inputData;
    Rigidbody2D rb;
    public AudioClip jumpSFX;
    public AudioSource audioSource;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        audioSource = GameObject.FindObjectOfType<AudioSource>();
    }

    void Update()
    {
        inputData = InputPoller.reference.GetInput(0);
        if (inputData.buttonWest)
            MovePlayer(-1);
        else if (inputData.buttonEast)
            MovePlayer(1);
        else
            MovePlayer(0);

        if (inputData.buttonNorth && canJump)
            Jump();
    }

    void MovePlayer(float value)
    {
        rb.velocity = new Vector2(moveSpeed * value, rb.velocity.y) ;
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        audioSource.PlayOneShot(jumpSFX);
    }

    // checking if player is touching the ground to jump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ground check to prevent jumping in-air
        if (collision.gameObject.tag == "Platform")
            canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            canJump = false;
    }
}
