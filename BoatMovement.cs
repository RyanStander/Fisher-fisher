using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField]
    [Header("Boat Attributes")]
    public float moveSpeed; //Speed of the boat
    public float turnSpeed; //Speed at which the boat can turn
    public float dragFactor; //Factor at which the velocity is reduced

    private Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //Forward movement
        if(Input.GetKey(KeyCode.W))
        {
            rBody.AddRelativeForce(Vector3.forward * moveSpeed);
        }
        //Backward movement
        else if (Input.GetKey(KeyCode.S))
        {
            rBody.AddRelativeForce(-Vector3.forward/2* moveSpeed);
        }

        //Right rotation
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }
        //Left rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * turnSpeed * Time.deltaTime);
        }

        //Reduces the velocity over time to slow down the movement
        rBody.velocity *= dragFactor;
    }
}
