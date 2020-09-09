using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void SomeDelegate(); //Define the method signature
    public static SomeDelegate onMyEvent; //Define the event 

    //Fire the event for any subscribed
    public static void MyEvent()
    {
        onMyEvent?.Invoke();
    }

    public delegate void StartSkillCheckEventDelegate(float speed, float treshold, int eventChance, bool plungerStrength); //Define the method signature
    public static StartSkillCheckEventDelegate onStartSkillCheckEvent; //Define the event 

    //Fire the event for any subscribed
    public static void StartSkillCheckEvent(float speed, float treshold, int eventChance, bool plungerStrength)
    {
        if (onStartSkillCheckEvent != null)
        {
            onStartSkillCheckEvent(speed,treshold,eventChance,plungerStrength);
        }
    }

    public delegate void FailedSkillCheckDelegate(); //Define the method signature
    public static FailedSkillCheckDelegate onFailedSkillCheck; //Define the event 

    //Fire the event for any subscribed
    public static void FailedSkillCheck()
    {
        if (onFailedSkillCheck != null)
        {
            onFailedSkillCheck();
        }
    }

    public delegate void SuccessfulSkillCheckDelegate(); //Define the method signature
    public static SuccessfulSkillCheckDelegate onSuccessfulSkillCheck; //Define the event 

    //Fire the event for any subscribed
    public static void SuccessfulSkillCheck()
    {
        if (onSuccessfulSkillCheck != null)
        {
            onSuccessfulSkillCheck();
        }
    }

    public delegate void CriticalSkillCheckDelegate(); //Define the method signature
    public static CriticalSkillCheckDelegate onCriticalSkillCheck; //Define the event 

    //Fire the event for any subscribed
    public static void CriticalSkillCheck()
    {
        if (onCriticalSkillCheck != null)
        {
            onCriticalSkillCheck();
        }
    }

    public delegate void PlungerSaveSkillCheckDelegate(bool plungerStrength); //Define the method signature
    public static PlungerSaveSkillCheckDelegate onPlungerSaveSkillCheck; //Define the event 

    //Fire the event for any subscribed
    public static void PlungerSaveSkillCheck(bool plungerStrength)
    {
        if (onPlungerSaveSkillCheck != null)
        {
            onPlungerSaveSkillCheck(plungerStrength);
        }
    }

    public delegate void EarlyPlungerEndDelegate(); //Define the method signature
    public static EarlyPlungerEndDelegate onEarlyPlungerEnd; //Define the event 

    //Fire the event for any subscribed
    public static void EarlyPlungerEnd()
    {
        if (onEarlyPlungerEnd != null)
        {
            onEarlyPlungerEnd();
        }
    }
}
