using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UselessTips : MonoBehaviour
{
    [SerializeField] string[] uselessTips = { "Did you know: Pressing the space bar will launch a plunger harpoon?","Hitting skill checks correctly will increase your speed!",
        "Did you know, Captain TED can't actually swim.","If you're struggling with a mission, try getting some upgrades",
            "Did you know the tallest mountain from base to top is actually located in the ocean ?","Did you know seawater is salty?" };
    [SerializeField] TextMeshProUGUI _uselessTipText = null;
    void Start()
    {
        _uselessTipText.SetText(uselessTips[Random.Range(0, uselessTips.Length)]);        
    }
}
