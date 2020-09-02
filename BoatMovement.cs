using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField]
    [Header("Boat Attributes")]
    public float moveSpeed=20; //Speed of the boat
    [Range(1,5)]
    public float turnStrength=3; //Multiplier at which the boat can turn when moving

    public float dragFactor = 0.9f; //Factor at which the velocity is reduced

    private float moveForce;

    private Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        axisInputMovement();
    }

    //Movement based on input of the axis controls
    private void axisInputMovement()
    {
        //Axis Input
        moveForce = Input.GetAxis("Vertical") * moveSpeed;

        //If input is negative (reversing), half force
        if (moveForce < 0)
        {
            moveForce *= 0.75f;
        }
        
        //Forward/Backwards movement based on axis input
        rBody.AddForce(transform.forward * moveForce);

        //Normalized for the inputs
        Vector2 horizontalInputVector = new Vector2(Input.GetAxis("Horizontal"),0);

        //Rotate based on input and current player movement forward
        transform.Rotate(Vector3.up * horizontalInputVector.normalized.x * turnStrength * moveForce * Time.deltaTime);
        //transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime);

        //Reduces the velocity over time to slow down the movement
        rBody.velocity *= dragFactor;
    }

}
