using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotatingCamera : MonoBehaviour
{
    public float cameraSpeed = 75; //Rotation speed for camera
    public GameObject targetObject;

    void Start()
    {
        //Finds the player object for the camera to lock onto automatically
        targetObject = GameObject.FindGameObjectWithTag("Player");

        //Mouse Locking and visibility toggling
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    //Update is called once per frame
    void Update()
    {
        //Makes the rotating camera holder stick to the target object and avoids errors
        if(targetObject) transform.position = targetObject.transform.position;
    }

    void LateUpdate()
    {
        CameraShift();
    }
    
    //Rotates the camera to constantly look at where the boat is
    private void CameraShift()
    {
        //Rotates the camera holder based on the (Horizontal) mouse position/movement
        transform.Rotate(Vector3.up * Time.deltaTime * cameraSpeed * Input.GetAxis("Mouse X"));
    }
}
