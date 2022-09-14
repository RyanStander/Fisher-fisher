using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishSpotCounter : MonoBehaviour
{
    private TextMeshProUGUI _fishZonesLeft;
    private GameObject[] _fishZones = null;
    // Start is called before the first frame update
    void Start()
    {
        _fishZonesLeft = GetComponent<TextMeshProUGUI>();
        _fishZones = GameObject.FindGameObjectsWithTag("FishingZone");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _fishZones = GameObject.FindGameObjectsWithTag("FishingZone");
        _fishZonesLeft.SetText("Fish Spots: "+_fishZones.Length);
    }
}
