using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckMovement : MonoBehaviour
{
    //[Range (1,5)]
    private float skillBarSpeed;
    private float rightBound;

    // Start is called before the first frame update
    public void StartUp(float newSpeed)
    {
        //Sets new speed
        skillBarSpeed = newSpeed;

        //Autocalculates offset for the bar
        float borderOffset = GetComponent<RectTransform>().rect.width / 1.75f;

        //Calculated the right boundary of the containing parent object
        rightBound = transform.parent.GetComponent<RectTransform>().rect.width/2 - borderOffset;

        //Sets the starting x position based on the range of available space
        transform.localPosition = new Vector3(-rightBound, transform.localPosition.y, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the bar
        transform.Translate(Vector3.right * skillBarSpeed);

        //Checks that bar is within the boundaries
        if (transform.localPosition.x >= rightBound)
        {
            //Tells parent object that skill check failed
            endSkillCheck(false);
        }
    }

    //End Skill Check
    private void endSkillCheck(bool wasSuccess)
    {
        GetComponentInParent<SkillCheckEvent>().EndSkillCheckEvent(wasSuccess);
    }
}
