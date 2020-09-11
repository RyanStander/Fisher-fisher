using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void TogglePlungerEventDelegate(bool setActive); //Define the method signature
    public static event TogglePlungerEventDelegate onTogglePlungerEvent; //Define the event 

    //Fire the event for any subscribed
    public static void TogglePlungerEvent(bool setActive)
    {
        if (onTogglePlungerEvent != null)
        {
            onTogglePlungerEvent(setActive);
        }
    }

    public delegate void StartSkillCheckEventDelegate(float speed, float treshold, int eventChance, bool plungerStrength); //Define the method signature
    public static event StartSkillCheckEventDelegate onStartSkillCheckEvent; //Define the event 

    //Fire the event for any subscribed
    public static void StartSkillCheckEvent(float speed, float treshold, int eventChance, bool plungerStrength)
    {
        if (onStartSkillCheckEvent != null)
        {
            onStartSkillCheckEvent(speed,treshold,eventChance,plungerStrength);
        }
    }

    public delegate void FailedSkillCheckDelegate(); //Define the method signature
    public static event FailedSkillCheckDelegate onFailedSkillCheck; //Define the event 

    //Fire the event for any subscribed
    public static void FailedSkillCheck()
    {
        if (onFailedSkillCheck != null)
        {
            onFailedSkillCheck();
        }
    }

    public delegate void SuccessfulSkillCheckDelegate(); //Define the method signature
    public static event SuccessfulSkillCheckDelegate onSuccessfulSkillCheck; //Define the event 

    //Fire the event for any subscribed
    public static void SuccessfulSkillCheck()
    {
        if (onSuccessfulSkillCheck != null)
        {
            onSuccessfulSkillCheck();
        }
    }

    public delegate void CriticalSkillCheckDelegate(); //Define the method signature
    public static event CriticalSkillCheckDelegate onCriticalSkillCheck; //Define the event 

    //Fire the event for any subscribed
    public static void CriticalSkillCheck()
    {
        if (onCriticalSkillCheck != null)
        {
            onCriticalSkillCheck();
        }
    }

    public delegate void PlungerSaveSkillCheckDelegate(bool plungerStrength); //Define the method signature
    public static event PlungerSaveSkillCheckDelegate onPlungerSaveSkillCheck; //Define the event 

    //Fire the event for any subscribed
    public static void PlungerSaveSkillCheck(bool plungerStrength)
    {
        if (onPlungerSaveSkillCheck != null)
        {
            onPlungerSaveSkillCheck(plungerStrength);
        }
    }

    public delegate void EarlyPlungerEndDelegate(); //Define the method signature
    public static event EarlyPlungerEndDelegate onEarlyPlungerEnd; //Define the event 

    //Fire the event for any subscribed
    public static void EarlyPlungerEnd()
    {
        if (onEarlyPlungerEnd != null)
        {
            onEarlyPlungerEnd();
        }
    }
}
