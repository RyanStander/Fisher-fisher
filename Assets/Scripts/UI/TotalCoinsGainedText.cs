using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalCoinsGainedText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _totalText=null;
    public void Start()
    {
        _totalText.SetText("Total coins: " + StaticValues.Coins);
    }
}
