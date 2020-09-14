using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Is what manages the skill check and toggles it on and off with specific attributes/parameters
public class SkillCheckEventManager : MonoBehaviour
{
    private bool startSkillChanceTimer=false;
    private float skillSpeed;
    private float zoneThreshold;
    private int skillCheckChance;
    private float timePassed;
    private bool isPlungerStrong;

    public GameObject skillCheckEventHolder;

    void OnEnable()
    {
        EventManager.onStartSkillCheckEvent += StartEvent;
        EventManager.onSuccessfulSkillCheck += ToggleTimerOn;
        EventManager.onPlungerSaveSkillCheck += PlungerState;
        EventManager.onFailedSkillCheck += ToggleTimerOff;
        EventManager.onEarlyPlungerEnd += DisableSkillCheck;
    }
    void OnDisable()
    {
        EventManager.onStartSkillCheckEvent -= StartEvent;
        EventManager.onSuccessfulSkillCheck -= ToggleTimerOn;
        EventManager.onPlungerSaveSkillCheck -= PlungerState;
        EventManager.onFailedSkillCheck -= ToggleTimerOff;
        EventManager.onEarlyPlungerEnd -= DisableSkillCheck;
    }
    public void StartEvent(float givenSkillSpeed, float givenZoneThreshold, int givenSkillCheckChance, bool plungerStrength)
    {
        skillSpeed = givenSkillSpeed;
        zoneThreshold= givenZoneThreshold;
        skillCheckChance= givenSkillCheckChance;
        isPlungerStrong = plungerStrength;

        //Start timer
        startSkillChanceTimer = true;
    }
    private void PlungerState(bool plungerStrength)
    {
        isPlungerStrong = plungerStrength;
        ToggleTimerOn();
    }
    private void ToggleTimerOn()
    {
        startSkillChanceTimer = true;
    }
    private void ToggleTimerOff()
    {
        startSkillChanceTimer = false;
    }
    //Disables the skill check if plunger is ended early
    private void DisableSkillCheck()
    {
        skillCheckEventHolder.SetActive(false);
        ToggleTimerOff();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(startSkillChanceTimer)
        {
            skillCheckFunction();
        }
    }
    void skillCheckFunction()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 1f)
        {
            //Reset second timer
            timePassed = 0;

            //If Skill Event exists, current skill check is not running and the chance of the event happening occurs
            if (Random.Range(0, 100) <= skillCheckChance)
            {
                skillCheckEventHolder.SetActive(true);
                skillCheckEventHolder.GetComponent<SkillCheckEvent>().StartEvent(skillSpeed,zoneThreshold,isPlungerStrong);
                startSkillChanceTimer = false;
            }
        }
    }


}
