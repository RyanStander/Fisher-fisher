using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckZonePosition : MonoBehaviour
{
    private float rightBound;
    [Range(0,1f)]
    private float extraZoneCoverage; //Extra potential zone for random position (starting from mid point backwards)

    // Start is called before the first frame update
   public void StartUp(float newCoverage)
    {
        extraZoneCoverage = newCoverage;
        //Autocalculates offset for the bar
        float borderOffset = GetComponent<RectTransform>().rect.width / 1.75f;

        //Calculated the right boundary of the containing parent object
        rightBound = transform.parent.GetComponent<RectTransform>().rect.width/2 - borderOffset;

        //Sets the random x position based on the range of available space
        transform.localPosition = new Vector3(Random.Range(-rightBound * extraZoneCoverage, rightBound), transform.localPosition.y, transform.localPosition.z);
    }
}
