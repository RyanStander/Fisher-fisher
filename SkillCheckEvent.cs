using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Is the skill check event itself
public class SkillCheckEvent : MonoBehaviour
{
    [Header("SkillCheck Elements for Overlap Check")]
    public GameObject easySkillZone;
    public GameObject mediumSkillZone;
    public GameObject hardSkillZone;

    public GameObject movingElement;

    private bool isPlungerStrong;

    //Resets the movement and skill zone when being activated
    public void StartEvent(float skillSpeed,float skillZonePositionThreshold, bool plungerStrength)
    {
        //If the plunger has a second try on a failed skill check, purchased in the store
        isPlungerStrong = plungerStrength;

        //Retrieve UI elements and tell them to have a random position based on their containing object
        easySkillZone.GetComponent<SkillCheckZonePosition>().StartUp(skillZonePositionThreshold);
        mediumSkillZone.GetComponent<SkillCheckZonePosition>().StartUp(skillZonePositionThreshold);
        hardSkillZone.GetComponent<SkillCheckZonePosition>().StartUp(skillZonePositionThreshold);

        //Start up the moving bar
        movingElement.GetComponent<SkillCheckMovement>().StartUp(skillSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //Checks for user input and overlaping elements
        activeSkillCheck();
    }

    //Stops the skill check
    public void EndSkillCheckEvent(bool wasSuccess,int boost)
    {
        //If skillcheck failed, un-grapple
        if(!wasSuccess)
        {
            if(isPlungerStrong)
            {
                //Calls the start of the skill check event but without a strong plunger
                EventManager.PlungerSaveSkillCheck(false);
            }
            else
            {
                EventManager.FailedSkillCheck();
            }
        }
        else
        {
            EventManager.SpeedBoost(boost);
            EventManager.SuccessfulSkillCheck();
        }

        //Set self to false and wait to be activated by the next skill check event
        gameObject.SetActive(false);
    }

    //When called, SkillCheckEvent will check if the interacting elements overlap when the player inputs
    private void activeSkillCheck()
    {
        //Gets the RectTransform of the objects
        RectTransform easyZoneRectTransform = easySkillZone.GetComponent<RectTransform>();
        RectTransform mediumZoneRectTransform = mediumSkillZone.GetComponent<RectTransform>();
        RectTransform hardZoneRectTransform = hardSkillZone.GetComponent<RectTransform>();
        RectTransform movingElementRectTransform = movingElement.GetComponent<RectTransform>();

        //If the moving element overlaps the stationary element, boost and end the current skill check event
        if (isOverlapping(easyZoneRectTransform, movingElementRectTransform) && Input.GetKeyDown(KeyCode.Space))
        {
            EndSkillCheckEvent(true,1);
        }
        else if (isOverlapping(mediumZoneRectTransform, movingElementRectTransform) && Input.GetKeyDown(KeyCode.Space))
        {
            EndSkillCheckEvent(true,2);
        }
        else if (isOverlapping(hardZoneRectTransform, movingElementRectTransform) && Input.GetKeyDown(KeyCode.Space))
        {
            EndSkillCheckEvent(true,3);
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            EndSkillCheckEvent(false,0);
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
