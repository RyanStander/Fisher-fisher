using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFinderSize : MonoBehaviour
{
    //Changes the scale and position based on the given range
    public void UpdateSize(float scaleUp)
    {
        transform.localPosition = new Vector3(scaleUp*-1, transform.localPosition.y, transform.localPosition.z);
        transform.localScale = new Vector3(transform.localScale.x, scaleUp, transform.localScale.z);
    }
}
