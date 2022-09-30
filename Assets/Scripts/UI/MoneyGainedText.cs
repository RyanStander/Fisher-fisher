using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyGainedText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _MoneyText=null;
    public void Start()
    {
        _MoneyText.SetText("Coins gained: " +StaticValues.CoinsGained);
    }
}
