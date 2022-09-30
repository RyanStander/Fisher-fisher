using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AimHarpoon : MonoBehaviour
{
    public Transform harpoonFirePoint; //Used for firing points and raycasting
    public Transform harpoonContainer; //Used for rotation
    [Range(0,180)]
    public float maximumAngle=90;

    // Update is called once per frame
    void FixedUpdate()
    {
        rotateToPoint();
    }

    private void rotateToPoint()
    {
        //Relative positions for camera and harpoon position
        Vector3 relativePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - harpoonContainer.transform.position;

        //Rotation to check
        Quaternion possibleRotation = Quaternion.Euler(0, Quaternion.LookRotation(relativePosition).eulerAngles.y - 90, 0);

        //Save last valid rotation
        Quaternion lastValidRotation = harpoonContainer.transform.rotation;

        //Rotate base to target point
        harpoonContainer.transform.rotation = possibleRotation;

        //Ensures the expected plunger rotation does not go over its limits
        if (harpoonContainer.localEulerAngles.y > maximumAngle && harpoonContainer.localEulerAngles.y < 360 - maximumAngle)
        {
            //Corrects to previous valid rotation
            harpoonContainer.transform.rotation = lastValidRotation;
        }
    }
}