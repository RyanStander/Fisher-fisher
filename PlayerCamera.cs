using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed=20; //Rotation speed for camera
    public GameObject target;

    void Start()
    {
        //Mouse Locking
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Rotates the camera to constantly look at where the boat is
        CameraShift();
        transform.LookAt(target.transform);
        
        //KeyCameraShift();
    }

    //If rotating using mouse
    private void CameraShift()
    {
        //Gets the mouse axis using their reference axisName
        float horizontal = cameraSpeed * Input.GetAxis("Mouse X");

        //Rotates the camera based on the mouse position
        transform.Translate(Vector3.left * Time.deltaTime * horizontal);
    }

    //If rotating using keys
    private void KeyCameraShift()
    {
        //Right rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * cameraSpeed);
        }
        //Left rotation
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * cameraSpeed);
        }
    }
}
