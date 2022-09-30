using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void UpdatePlayerVisualsDelegate(); //Define the method signature
    public static event UpdatePlayerVisualsDelegate onUpdatePlayerVisuals; //Define the event 

    //Fire the event for any subscribed
    public static void UpdatePlayerVisuals()
    {
        onUpdatePlayerVisuals?.Invoke();
    }

    public delegate void TogglePlungerEventDelegate(bool setActive); //Define the method signature
    public static event TogglePlungerEventDelegate onTogglePlungerEvent; //Define the event 

    //Fire the event for any subscribed
    public static void TogglePlungerEvent(bool setActive)
    {
        onTogglePlungerEvent?.Invoke(setActive);
    }

    public delegate void StartSkillCheckEventDelegate(float speed, float treshold, int eventChance, bool plungerStrength); //Define the method signature
    public static event StartSkillCheckEventDelegate onStartSkillCheckEvent; //Define the event 

    //Fire the event for any subscribed
    public static void StartSkillCheckEvent(float speed, float treshold, int eventChance, bool plungerStrength)
    {
        onStartSkillCheckEvent?.Invoke(speed, treshold, eventChance, plungerStrength);
    }

    public delegate void FailedSkillCheckDelegate(); //Define the method signature
    public static event FailedSkillCheckDelegate onFailedSkillCheck; //Define the event 

    //Fire the event for any subscribed
    public static void FailedSkillCheck()
    {
        onFailedSkillCheck?.Invoke();
    }

    public delegate void SuccessfulSkillCheckDelegate(); //Define the method signature
    public static event SuccessfulSkillCheckDelegate onSuccessfulSkillCheck; //Define the event 

    //Fire the event for any subscribed
    public static void SuccessfulSkillCheck()
    {
        onSuccessfulSkillCheck?.Invoke();
    }

    public delegate void SpeedBoostDelegate(int boost); //Define the method signature
    public static event SpeedBoostDelegate onSpeedBoost; //Define the event 

    //Fire the event for any subscribed
    public static void SpeedBoost(int boost)
    {
        onSpeedBoost?.Invoke(boost);
    }

    public delegate void PlungerSaveSkillCheckDelegate(bool plungerStrength); //Define the method signature
    public static event PlungerSaveSkillCheckDelegate onPlungerSaveSkillCheck; //Define the event 

    //Fire the event for any subscribed
    public static void PlungerSaveSkillCheck(bool plungerStrength)
    {
        onPlungerSaveSkillCheck?.Invoke(plungerStrength);
    }

    public delegate void EarlyPlungerEndDelegate(); //Define the method signature
    public static event EarlyPlungerEndDelegate onEarlyPlungerEnd; //Define the event 

    //Fire the event for any subscribed
    public static void EarlyPlungerEnd()
    {
        onEarlyPlungerEnd?.Invoke();
    }

    public delegate void TutorialSkillCheckStartDelegate(); //Define the method signature
    public static event TutorialSkillCheckStartDelegate onTutorialSkillCheckStart; //Define the event 

    //Fire the event for any subscribed
    public static void TutorialSkillCheckStart()
    {
        onTutorialSkillCheckStart?.Invoke();
    }

    public delegate void UpdateUpgradesDelegate(); //Define the method signature
    public static event UpdateUpgradesDelegate onUpdateUpgradesDelegate; //Define the event 

    //Fire the event for any subscribed
    public static void UpdateUpgrades()
    {
        onUpdateUpgradesDelegate?.Invoke();
    }
}
