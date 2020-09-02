using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPositionFollow : MonoBehaviour
{
    public GameObject targetObject;

    void Update()
    {
        transform.position = targetObject.transform.position;
    }
}
