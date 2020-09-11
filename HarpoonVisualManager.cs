using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonVisualManager : MonoBehaviour
{
    public GameObject plunger, plungerUpgrade, plungerGun, plungerGunUpgrade;
    private GameObject currentPlunger=null, currentGun=null;
    void OnEnable()
    {
        EventManager.onTogglePlungerEvent += toggleHarpoonVisual;
    }
    void OnDisable()
    {
        EventManager.onTogglePlungerEvent -= toggleHarpoonVisual;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Swaps between plunger visuals based on strength
        switch (StaticValues.PlungerStrength)
        {
            case true:
                //Basic
                plunger.SetActive(false);
                plungerGun.SetActive(false);

                //Upgraded
                plungerUpgrade.SetActive(true);
                plungerGunUpgrade.SetActive(true);

                //Sets the current 
                currentPlunger = plungerUpgrade;
                currentGun = plungerGunUpgrade;
                break;

            case false:
                //Basic
                plunger.SetActive(true);
                plungerGun.SetActive(true);

                //Sets the current 
                currentPlunger =  plunger;
                currentGun = plungerGun;

                //Upgraded
                plungerUpgrade.SetActive(false);
                plungerGunUpgrade.SetActive(false);
                break;
        }
    }
    //Toggle visuals for the harpoon based on if it has been fired or not
    private void toggleHarpoonVisual(bool isActive)
    {
        currentPlunger.SetActive(isActive);
    }
}
