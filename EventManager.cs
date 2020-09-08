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
        if(onMyEvent !=null)
        {
            onMyEvent();
        }
    }

    public delegate void StartSkillCheckEventDelegate(float speed, float treshold, int eventChance); //Define the method signature
    public static StartSkillCheckEventDelegate onStartSkillCheckEvent; //Define the event 

    //Fire the event for any subscribed
    public static void StartSkillCheckEvent(float speed, float treshold, int eventChance)
    {
        if (onStartSkillCheckEvent != null)
        {
            onStartSkillCheckEvent(speed,treshold,eventChance);
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
}
