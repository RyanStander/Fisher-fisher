using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [Header("Boat Attributes")]
    [Range(0.5f, 2f)]
    public float speedFrontStrength = 1;
    [Range(0.5f, 2f)]
    public float speedBackStrength = 0.75f;
    [Range(2f, 10f)]
    public int maximumSpeed = 5;
    [Range(0.05f, 0.1f)]
    public float turningStrength = 0.05f;
    [Range(0.5f, 0.99f)]
    public float playerSpeedSlowdown = 0.8f;

    private Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        playerMovement();
    }
 
    private float playerSpeed;
    private void playerMovement()
    {
        //Turning
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-turningStrength * playerSpeed * Vector3.up);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(turningStrength * playerSpeed * Vector3.up);
        }

        //Forward/Backwards
        if (Input.GetKey(KeyCode.W) && playerSpeed <= maximumSpeed)
        {
            playerSpeed += speedFrontStrength;
        }
        if (Input.GetKey(KeyCode.S) && playerSpeed >= -maximumSpeed)
        {
            playerSpeed -= speedBackStrength; //Speed up is weaker in reverse
        }
        
        //Apply the speed to the player
        rBody.AddRelativeForce(Vector3.forward * playerSpeed);

        //Apply a slowdown to the player speed
        playerSpeed *= playerSpeedSlowdown;
    }
}
