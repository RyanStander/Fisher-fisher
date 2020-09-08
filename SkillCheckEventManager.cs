using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckEventManager : MonoBehaviour
{
    private bool startSkillChanceTimer=false;
    private float skillSpeed;
    private float zoneThreshold;
    private int skillCheckChance;
    private float timePassed;

    public GameObject skillCheckEventHolder;

    void OnEnable()
    {
        EventManager.onStartSkillCheckEvent += StartEvent;
        EventManager.onSuccessfulSkillCheck += ToggleTimerOn;
    }
    void OnDisable()
    {
        EventManager.onStartSkillCheckEvent -= StartEvent;
        EventManager.onSuccessfulSkillCheck -= ToggleTimerOn;
    }
    public void StartEvent(float givenSkillSpeed, float givenZoneThreshold, int givenSkillCheckChance)
    {
        skillSpeed = givenSkillSpeed;
        zoneThreshold= givenZoneThreshold;
        skillCheckChance= givenSkillCheckChance;

        //Start timer
        startSkillChanceTimer = true;
    }
    private void ToggleTimerOn()
    {
        startSkillChanceTimer = true;
    }

    // Update is called once per frame
    void Update()
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
                skillCheckEventHolder.GetComponent<SkillCheckEvent>().StartEvent(skillSpeed,zoneThreshold);
                startSkillChanceTimer = false;
            }
        }
    }


}
