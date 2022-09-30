using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatScript : MonoBehaviour
{
    void Update()
    {
        //Add money
        if(Input.GetKey(KeyCode.F) && Input.GetKeyDown(KeyCode.G))
        {
            AddMoney();
        }

        //Boost
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            EventManager.SpeedBoost(1);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            EventManager.SpeedBoost(2);
        }
        if (Input.GetKey(KeyCode.LeftShift) & Input.GetKeyDown(KeyCode.Alpha3))
        {
            EventManager.SpeedBoost(3);
        }
    }
    private void AddMoney()
    {
        StaticValues.Coins += 500;
    }
    private void SpeedBoost()
    {
        EventManager.SpeedBoost(1);
    }
}
