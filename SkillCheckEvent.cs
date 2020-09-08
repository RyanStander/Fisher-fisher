using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckEvent : MonoBehaviour
{
    [Header("SkillCheck Elements for Overlap Check")]
    public GameObject stationaryElement;
    public GameObject movingElement;
    [Range(0,100)]
    public int criticalZoneThreshold;
    private bool isPlungerStrong;

    //Resets the movement and skill zone when being activated
    public void StartEvent(float skillSpeed,float skillZonePositionThreshold, bool plungerStrength)
    {
        isPlungerStrong = plungerStrength;

        //Retrieve UI elements
        stationaryElement.GetComponent<SkillCheckZonePosition>().StartUp(skillZonePositionThreshold);
        movingElement.GetComponent<SkillCheckMovement>().StartUp(skillSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //Checks for user input and overlaping elements
        activeSkillCheck();
    }

    //Stops the skill check
    public void EndSkillCheckEvent(bool wasSuccess)
    {
        //If skillcheck failed, un-grapple
        if(!wasSuccess)
        {
            if(isPlungerStrong)
            {
                isPlungerStrong = false;
                EventManager.onPlungerSaveSkillCheck(false);
            }
            else
            {
                EventManager.onFailedSkillCheck();
            }
        }
        else
        {
            //If critical success, fire off event for speed boost
            if (isCritical())
            {
                Debug.Log("Skill check was critical!");
                //EventManager.onCriticalSkillCheck();
            }
            EventManager.onSuccessfulSkillCheck();
        }

        gameObject.SetActive(false);
    }

    //When called, SkillCheckEvent will check if the interacting elements overlap when the player inputs
    private void activeSkillCheck()
    {
        //Gets the RectTransform of the objects
        RectTransform stationaryElementRectTransform = stationaryElement.GetComponent<RectTransform>();
        RectTransform movingElementRectTransform = movingElement.GetComponent<RectTransform>();

        //If the moving element overlaps the stationary element
        if (isOverlapping(stationaryElementRectTransform, movingElementRectTransform) && Input.GetKeyDown(KeyCode.Space))
        {
            EndSkillCheckEvent(true);
        }
        else if(!isOverlapping(stationaryElementRectTransform, movingElementRectTransform) && Input.GetKeyDown(KeyCode.Space))
        {
            EndSkillCheckEvent(false);
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

    bool isCritical()
    {
        //Gets the RectTransform of the objects
        RectTransform stationaryElementRectTransform = stationaryElement.GetComponent<RectTransform>();

        //Gets threshold width in measurable unitys for the game
        float criticalThreshold = (stationaryElementRectTransform.rect.width/2)*((float)criticalZoneThreshold/100);
        
        //The position of relevant parameters
        float movingPosition = movingElement.transform.localPosition.x;
        float stillPosition = stationaryElement.transform.localPosition.x;
        float rightBound = stillPosition + criticalThreshold;
        float leftBound = stillPosition - criticalThreshold;

        //Return if within bounds
        return (movingPosition <= rightBound && movingPosition >= leftBound);
    }
}
