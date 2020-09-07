using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCheckEvent : MonoBehaviour
{
    [Header("SkillCheck Elements for Overlap Check")]
    public RectTransform stationaryElement;
    public RectTransform movingElement;
    public int secondsToComplete=10;
    private float timePassed;

    // Update is called once per frame
    void Update()
    {
        //Checks for user input and overlaping elements
        activeSkillCheck();

        //Checks if time has run out and updates time passed
        updateTime();
    }
    //When called, SkillCheckEvent will check if the interacting elements overlap when the player inputs
    private void activeSkillCheck()
    {
        //If the moving element overlaps the stationary element, then !!TO-DO:Implement event connection!!
        if (isOverlapping(stationaryElement, movingElement) && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Skill Check Success!");
            //Tell Game about Success
        }
        else if(!isOverlapping(stationaryElement, movingElement) && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Skill Check Fail!");
            //Tell Game about Fail
            //gameObject.SetActive(false);
        }
    }
    //Time checking
    private void updateTime()
    {
        //Add time passed
        timePassed += Time.deltaTime;

        //If time passed the time given to complete
        if (timePassed>=secondsToComplete)
        {
            Debug.Log("Skill Check Fail, No Time!");
            //gameObject.SetActive(false);
        }
    }

    //Returns if rectangular UI elements overlap by looking at local positions
    bool isOverlapping(RectTransform firstRectTransform, RectTransform secondRectangle)
    {
        //Defines local rectangle to check if rectangle transforms are overlapping
        Rect firstRect = new Rect(firstRectTransform.localPosition.x, firstRectTransform.localPosition.y, firstRectTransform.rect.width, firstRectTransform.rect.height);
        Rect secondRect = new Rect(secondRectangle.localPosition.x, secondRectangle.localPosition.y, secondRectangle.rect.width, secondRectangle.rect.height);

        //Rerturns true if overlapping
        return firstRect.Overlaps(secondRect);
    }

}
