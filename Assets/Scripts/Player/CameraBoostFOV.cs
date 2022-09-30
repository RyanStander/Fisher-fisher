using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Applies an FOV change to the boat when boosting
public class CameraBoostFOV : MonoBehaviour
{
    public float easyBoostFOV = 80, mediumBoostFOV = 90, hardBoostFOV = 100;
    public float boostDurationFOV;

    [Range(0.1f, 1)]
    public float transitionTime = 0.25f;

    private float originalFOV, targetFOV;
    private float internalDurationClock;
    private bool isBoosting;
    private Camera thisCamera;

    void OnEnable()
    {
        EventManager.onSpeedBoost += toggleFOV;
    }
    void OnDisable()
    {
        EventManager.onSpeedBoost -= toggleFOV;
    }


    // Start is called before the first frame update
    void Start()
    {
        //Gets the attached camera
        thisCamera = GetComponentInChildren<Camera>();

        originalFOV = thisCamera.fieldOfView;
    }


    private void toggleFOV(int strengthOfFOV)
    {
        //Set the current target FOV based on the strength of the boost
        if(strengthOfFOV==1)
        {
            targetFOV = easyBoostFOV;
        }
        else if (strengthOfFOV == 2)
        {
            targetFOV = mediumBoostFOV;
        }
        else if (strengthOfFOV == 3)
        {
            targetFOV = hardBoostFOV;
        }

        //Start the boosting
        internalDurationClock = 0;
        isBoosting = true;
    }

    void FixedUpdate()
    {
        if(isBoosting)
        {
            //Toggle boost off when original FOV has been reached
            if(originalFOV == targetFOV && thisCamera.fieldOfView == originalFOV)
            {
                isBoosting = false;
                return;
            }

            //Allows for boosting towards target FOV and then back to original FOV
            if(boostDurationFOV <= internalDurationClock)
            {
                targetFOV = originalFOV;
            }

            //Lerp towards target FOV
            thisCamera.fieldOfView = Mathf.Lerp(thisCamera.fieldOfView, targetFOV, transitionTime);

            //Add to internal clock
            internalDurationClock += Time.deltaTime;
        }
    }
}

