using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimHarpoon : MonoBehaviour
{
    public Transform harpoonFirePoint; //Used for firing points and raycasting
    public Transform harpoonContainer; //Used for rotation

    // Update is called once per frame
    void Update()
    {
        rotateToPoint();
        drawRayForward();
    }

    private void rotateToPoint()
    {
        //Relative positions
        Vector3 relativeBasePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - harpoonContainer.transform.position;

        //Rotate base to target point
        harpoonContainer.transform.rotation = Quaternion.Euler(0, Quaternion.LookRotation(relativeBasePosition).eulerAngles.y - 90, 0);
    }

    //Visualizes for the direction of the ray
    private void drawRayForward()
    {
        //Debug.DrawRay(harpoonFirePoint.transform.position, - harpoonFirePoint.transform.right * 10, Color.yellow);
    }
}