using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatUpgradesManager : MonoBehaviour
{
    [Header("Harpoon Related Upgrades")] //Dealt as separate objects insetad of an array as these are dynamic and change mid-game
    //Plunger related
    public GameObject plunger;
    public GameObject plungerUpgrade;
    public GameObject plungerGun;
    public GameObject plungerGunUpgrade;
    
    [Header("Engine Related Upgrades")]
    public List<GameObject> engineUpgrades; //Uses a list as these are less complex than the plunger upgrades

    [Header("Currency Related Upgrades")]
    public List<GameObject> currencyUpgrades; //Uses a list as these are less complex than the plunger upgrades

    //Objects declared locally
    private GameObject currentPlunger = null;
    void OnEnable()
    {
        EventManager.onTogglePlungerEvent += toggleHarpoonVisual;
        EventManager.onUpdatePlayerVisuals += Start;
    }
    void OnDisable()
    {
        EventManager.onUpdatePlayerVisuals -= Start;
        EventManager.onTogglePlungerEvent -= toggleHarpoonVisual;
    }

    // Start is called before the first frame update
    void Start()
    {
        updateHarpoon();
        updateEngines();
        updateCurrency();
    }
    private void updateHarpoon()
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
                break;

            case false:
                //Basic
                plunger.SetActive(true);
                plungerGun.SetActive(true);

                //Sets the current 
                currentPlunger = plunger;

                //Upgraded
                plungerUpgrade.SetActive(false);
                plungerGunUpgrade.SetActive(false);
                break;
        }
    }
    private void updateEngines()
    {
        //Swaps between the engine types based on the current upgrade
        foreach (GameObject engine in engineUpgrades)
        {
            //If listed engine is not the current upgrade, disable the visual
            if (engineUpgrades.IndexOf(engine) != StaticValues.EnginePower)
            {
                engine.SetActive(false);
            }
            else
            {
                engine.SetActive(true);
            }
        }
    }
    private void updateCurrency()
    {
        //Swaps between the engine types based on the current upgrade
        foreach (GameObject currency in currencyUpgrades)
        {
            //If listed engine is not the current upgrade, disable the visual
            if (engineUpgrades.IndexOf(currency) != StaticValues.EnginePower)
            {
                currency.SetActive(false);
            }
            else
            {
                currency.SetActive(true);
            }
        }
    }
    //Toggle visuals for the harpoon based on if it has been fired or not
    private void toggleHarpoonVisual(bool isActive)
    {
        currentPlunger.SetActive(isActive);
    }

}
