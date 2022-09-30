using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    private TextMeshProUGUI _money;
    void Start()
    {
        _money = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _money.SetText(StaticValues.Coins.ToString());
    }
}
