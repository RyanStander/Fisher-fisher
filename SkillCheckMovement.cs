using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckMovement : MonoBehaviour
{
    [Range (1,5)]
    public int skillBarSpeed = 2;
    private float rightBound;

    // Start is called before the first frame update
    void Start()
    {
        //Autocalculates offset for the bar
        float borderOffset = GetComponent<RectTransform>().rect.width/1.75f;

        //Calculated the right boundary of the containing parent object
        rightBound = transform.parent.GetComponent<RectTransform>().rect.width / 2 - borderOffset;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the bar
        transform.Translate(Vector3.right * skillBarSpeed);

        //Checks that bar is within the boundaries
        if (transform.localPosition.x <= -rightBound || transform.localPosition.x >= rightBound)
        {
            //Reverses the speed
            skillBarSpeed *= -1;
        }
    }
}
