using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraMotion : MonoBehaviour
{
    public GameObject followTarget=null;
    public GameObject oceanFloor = null; //Planes are 10x the scale
    private Camera thisCamera;

    private float cameraWidthHalved;
    private float xPlaneWidthHalved;
    private float zPlaneWidthHalved;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the player by default if not given
        if(followTarget==null)
        {
            followTarget = GameObject.FindGameObjectWithTag("Player");
        }
        //Gets the ocean by default if not given
        if (oceanFloor == null)
        {
            oceanFloor = GameObject.FindGameObjectWithTag("Ocean");
        }

        //Gets the attached camera
        thisCamera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        getDimensions();
        calculateNewPosition();
    }
    private void getDimensions() //Each position unit is equal to half of 1 scale
    {
        //Get dimensions of the camera view
        cameraWidthHalved = thisCamera.orthographicSize * thisCamera.aspect;

        //Get dimensions of the ocean plane (10 times the scale of the inspector)
        xPlaneWidthHalved = oceanFloor.GetComponent<MeshRenderer>().bounds.extents.x;
        zPlaneWidthHalved = oceanFloor.GetComponent<MeshRenderer>().bounds.extents.z;
    }
    private void calculateNewPosition()
    {
        float upperEdgeZ = zPlaneWidthHalved - cameraWidthHalved;
        float lowerEdgeZ = -zPlaneWidthHalved + cameraWidthHalved;
        float rightEdgeX = xPlaneWidthHalved - cameraWidthHalved;
        float leftEdgeX = -xPlaneWidthHalved + cameraWidthHalved;

        float newPositionZ = transform.position.z;
        float newPositionX = transform.position.x;

        //If target within bounds of minimap and plane for the Z-Axis, continue to follow on the Z-Axis
        if (followTarget.transform.position.z <= upperEdgeZ && followTarget.transform.position.z >= lowerEdgeZ)
        {
            //Set the new position Z
            newPositionZ = followTarget.transform.position.z;
        }

        //If target within bounds of minimap and plane for the X-Axis, continue to follow on the X-Axis
        if (followTarget.transform.position.x <= rightEdgeX && followTarget.transform.position.x >= leftEdgeX)
        {
            //Set the new position X
            newPositionX = followTarget.transform.position.x;
        }

        //Set the new position
        transform.position = new Vector3(newPositionX, transform.position.y, newPositionZ);
    }
}
