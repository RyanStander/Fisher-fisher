using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPositionFollow : MonoBehaviour
{
    public GameObject targetObject;

    [SerializeField]
    private float easingSpeed=0.9f;

    void Update()
    {
        transform.position = targetObject.transform.position;
        //easingTowards();
    }

    private void easingTowards()
    {
        //Calculate a step for the following object towards the target object
        float step = easingSpeed * Time.deltaTime;

        //Move towards the target using the step
        transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, step);
    }
}
