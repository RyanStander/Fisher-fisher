using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float moveSpeed; //Speed of the boat
    public float turnSpeed; //Speed at which the boat can turn
    public float dragFactor; //Factor at which the velocity is reduced

    Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        //Forward movement
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rBody.AddRelativeForce(Vector3.forward * moveSpeed);
        }
        //Backward movement
        else if (Input.GetKey(KeyCode.DownArrow))
        {
             rBody.AddRelativeForce(-Vector3.forward/2* moveSpeed);
        }

        //Right rotation
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }
        //Left rotation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up * turnSpeed * Time.deltaTime);
        }

        //Reduces the velocity over time to slow down the movement
        rBody.velocity *= dragFactor;
    }
}
