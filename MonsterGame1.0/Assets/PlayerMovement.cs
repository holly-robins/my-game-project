using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed;
    public float rotationSpeed;

    // Current move speed and speed of the dash
    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength=0.5f, dashCooldown=1f;

    // How long dash has been active and inactive respectivley
    private float dashCounter;
    private float dashCoolCounter;

    
    
    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed=moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if user has pressed WASD
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Direction the user wants to go (vector with horizontal and vertical)
        Vector2 movementDirection = new Vector2 (horizontalInput, verticalInput);
        
        // Actually moves the player (time.deltatime means speed isn't affected by framerate as Update() is)
        transform.Translate(movementDirection * activeMoveSpeed * Time.deltaTime, Space.World);

        // If the player is moving:
        if (movementDirection != Vector2.zero)
        {
            // Rotates the player
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If the user is not on cooldown and isn't already dashing
            if(dashCoolCounter <=0 && dashCounter<=0)
            {
                activeMoveSpeed=dashSpeed;
                dashCounter=dashLength;
            }
        }

        // If the user is currently dashing, run down the counter
        if (dashCounter>0)
        {
            dashCounter-=Time.deltaTime;

            if(dashCounter <=0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter=dashCooldown;

            }
        }

        if (dashCoolCounter>0)
        {
            dashCoolCounter-=Time.deltaTime;
        }
    }

    void OnCollisionEnter()
    {
        Debug.Log("hello");
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}
