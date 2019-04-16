using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public bool onGround = true;
    public float forwardForce = 1000f;
    public float sidewaysForce = 2000f;
    public float Delay = 2f;
    public Transform player;
    public bool cooldown = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Add a forward force.
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // If statements for player input. Allows the player to move left and right.
        if(Input.GetKey("d") )
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); 
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown("s"))
        {
            rb.AddForce(0, -2, 0, ForceMode.VelocityChange);
        }

        if(Input.GetKeyDown("space"))
        {
            if(cooldown == false)
            {
                rb.AddForce(0, 8, 0, ForceMode.VelocityChange);
                cooldown = true;
                Invoke("ResetCooldown", 2f);
            }
            
        }

        if(player.position.y < -2)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }

}
