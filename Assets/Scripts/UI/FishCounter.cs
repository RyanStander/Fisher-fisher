using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class FishCounter : MonoBehaviour
{
    private TextMeshProUGUI _fishLeft;
    private List<FishZones> _fishZones=new List<FishZones>();
    private float _maxFish;
    private float timer = 100;
    private float _curFish;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("FishingZone");
        foreach (GameObject gameObject in go)
        {
            _fishZones.Add(gameObject.GetComponent<FishZones>());
        }
        _fishLeft = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _maxFish = 0;
        _curFish = 0;
        foreach (FishZones fishZone in _fishZones)
        {
            _maxFish+=fishZone.GetMaxFishStock();
            _curFish+=fishZone.GetCurFishStock();
        }
        _fishLeft.SetText(_curFish+"/"+_maxFish);

        if (_curFish < 1)
        {
            timer--;
            if (timer < 0)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("Failure Screen");
            }
        }
    }
}
