using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [Header("Boat Attributes")]
    [Range(0.5f, 2f)]
    public float speedFrontStrength = 1;
    [Range(0.5f, 2f)]
    public float speedBackStrength = 0.75f;
    [Range(2f, 10f)]
    public int maximumSpeed = 5;
    [Range(0.05f, 0.1f)]
    public float turningStrength = 0.05f;
    [Range(0.5f, 0.99f)]
    public float playerSpeedSlowdown = 0.8f;
    [SerializeField] float[] enginePowerLevel = {0,0.05f,0.10f,0.15f,0.20f };
    private float playerSpeed;

    [Header("Accelaration Boost Attributes")]
    //Accelaration boost
    private float maximumAccelerationBoost = 5f;
    [Range(0.5f, 10f)]
    public float easyBoostStrength=3, mediumBoostStrength=6, hardBoostStrength=9;
    [Range(0.005f, 0.05f)]
    public float accelarationBoostRate = 0.05f;
    [Range(1f, 5f)]
    public float boostTime = 5;
    private float boostTimeRemaining;
    private float currentAccelarationBoost = 0;
    private bool isAccelarationBoosting = false;

    private Rigidbody rBody;

    void OnEnable()
    {
        EventManager.onSpeedBoost += enableAccelarationBoost;
    }
    void OnDisable()
    {
        EventManager.onSpeedBoost -= enableAccelarationBoost;
    }
    private void enableAccelarationBoost(int boost)
    {
        if(boost==1)
        {
            //If easy skill check
            maximumAccelerationBoost = easyBoostStrength;
        }
        else if(boost==2)
        {
            //If medium skill check
            maximumAccelerationBoost = mediumBoostStrength;
        }
        else if(boost==3)
        {
            //If hard skill check
            maximumAccelerationBoost = hardBoostStrength;
        }
        else
        {
            //If no boost strength is given
            maximumAccelerationBoost = 5;
        }

        isAccelarationBoosting = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        boostTimeRemaining = boostTime;
        rBody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //Boosting
        if (isAccelarationBoosting)
        {
            accelarationBoost();
        }
        playerMovement();
    }

    private void playerMovement()
    {
        //Turning
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-turningStrength * playerSpeed * Vector3.up);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(turningStrength * playerSpeed * Vector3.up);
        }

        //Forward/Backwards
        if (Input.GetKey(KeyCode.W) && playerSpeed <= maximumSpeed+currentAccelarationBoost)
        {
            playerSpeed += speedFrontStrength+enginePowerLevel[StaticValues.EnginePower]+ currentAccelarationBoost;
        }
        if (Input.GetKey(KeyCode.S) && playerSpeed >= -maximumSpeed + currentAccelarationBoost) //Speed up is weaker in reverse
        {
            playerSpeed -= speedBackStrength - enginePowerLevel[StaticValues.EnginePower]+ currentAccelarationBoost;
        }
        
        //Apply the speed to the player
        rBody.AddRelativeForce(Vector3.forward * playerSpeed);

        //Apply a slowdown to the player speed
        playerSpeed *= playerSpeedSlowdown;
    }

    private void accelarationBoost()
    {
        //Reduce time remaining on boost
        boostTimeRemaining -= Time.deltaTime;

        //Speed up until hitting maximum boost
        if (currentAccelarationBoost<maximumAccelerationBoost)
        {
            //Apply boost to current accelaration boost
            currentAccelarationBoost += accelarationBoostRate;
        }
        else if (boostTimeRemaining <= 0)
        {
            //Reset and end boost
            boostTimeRemaining = boostTime;
            currentAccelarationBoost = 0;
            isAccelarationBoosting = false;
            return;
        }
    }
}
