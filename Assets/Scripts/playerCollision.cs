using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody rb;
    public Transform player;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        else if(collisionInfo.collider.tag == "Wall1")
        {
            rb.AddForce(1000 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if(collisionInfo.collider.tag == "Wall2")
        {
            rb.AddForce(-1000 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
