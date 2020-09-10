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
        //Relative positions
        Vector3 relativePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - harpoonContainer.transform.position;

        //Rotation to check
        Quaternion possibleRotation = Quaternion.Euler(0, Quaternion.LookRotation(relativePosition).eulerAngles.y - 90, 0);

        //Rotate base to target point
        Quaternion lastValidRotation = harpoonContainer.transform.rotation;
        harpoonContainer.transform.rotation = possibleRotation;

        //Gets the inspector rotation to check for rotation limits
        float containerRotation = TransformUtils.GetInspectorRotation(harpoonContainer).y;

        //Ensures the plunger rotation does not go over its limits
        if (containerRotation < - maximumAngle || containerRotation > maximumAngle)
        {
            //Corrects to previous valid rotation
            harpoonContainer.transform.rotation = lastValidRotation;
        }
    }
}