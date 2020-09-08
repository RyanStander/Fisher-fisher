using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckEvent : MonoBehaviour
{
    [Header("SkillCheck Elements for Overlap Check")]
    public GameObject stationaryElement;
    public GameObject movingElement;

    void Start() //Delete when testing is done
    {
       // gameObject.SetActive(false);
        //stationaryElement.GetComponent<SkillCheckZonePosition>().StartUp(0.75f);
       // movingElement.GetComponent<SkillCheckMovement>().StartUp(0.75f);
    }

    //Resets the movement and skill zone when being activated
    public void StartEvent(float skillSpeed,float skillZonePositionThreshold)
    {
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
            EventManager.onFailedSkillCheck();
        }
        else
        {
            EventManager.onSuccessfulSkillCheck();
        }

        Debug.Log("Skill Check was a Success?: "+wasSuccess);
        gameObject.SetActive(false);
    }

    //When called, SkillCheckEvent will check if the interacting elements overlap when the player inputs
    private void activeSkillCheck()
    {
        //Gets the RectTransform of the objects
        RectTransform stationaryElementRectTransform = stationaryElement.GetComponent<RectTransform>();
        RectTransform movingElementRectTransform = movingElement.GetComponent<RectTransform>();

        //If the moving element overlaps the stationary element, then !!TO-DO:Implement event connection!!
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
}
