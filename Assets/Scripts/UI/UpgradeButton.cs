using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Sprite[] upgradeSprite = null;
    private int _currImg;
    [SerializeField] int[] upgradeCost=null;
    [SerializeField] string UpgradeType=null;
    public void Start()
    {
        switch (UpgradeType)
        {
            case "plunger":
                if (StaticValues.PlungerStrength == true)
                {
                    _currImg = 1;
                    gameObject.GetComponent<Image>().sprite = upgradeSprite[_currImg];
                }
                break;
            case "currency":
                _currImg=StaticValues.CurrencyUpgrade;
                gameObject.GetComponent<Image>().sprite = upgradeSprite[_currImg];
                break;
            case "engine":
                _currImg = StaticValues.EnginePower;
                gameObject.GetComponent<Image>().sprite = upgradeSprite[_currImg];
                break;
        }
    }
    public void UpgradeSprite()
    {        
        if (_currImg != upgradeSprite.Length-1&& StaticValues.Coins>=upgradeCost[_currImg])
        {
            StaticValues.Coins -= upgradeCost[_currImg];
            _currImg++;
            gameObject.GetComponent<Image>().sprite = upgradeSprite[_currImg];
            Debug.Log("Subtracted " + upgradeCost[_currImg-1] + " and " + StaticValues.Coins + " coins remaining");
            switch (UpgradeType)
            {
                case "plunger":
                    StaticValues.PlungerStrength = true;
                    //Debug.Log("Plunger Strength has been unlocked");
                    break;
                case "currency":
                    StaticValues.CurrencyUpgrade++;
                    //Debug.Log("Money Maker make more money magnitude: " + StaticValues.CurrencyUpgrade);
                    break;
                case "engine":
                    StaticValues.EnginePower++;
                    //Debug.Log("Enigmatic engine egnition escalated: " + StaticValues.EnginePower);
                    break;
            }
            EventManager.UpdatePlayerVisuals();
        }
    }
}
