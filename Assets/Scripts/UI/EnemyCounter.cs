using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    private TextMeshProUGUI _enemiesLeft;
    private GameObject[] _gameObject;
    private float timer=100;
    private GameObject[] _fishRemaining;
    [SerializeField] float[] moneyGain = { 0,0.01f, 0.025f, 0.05f, 0.075f };
    // Start is called before the first frame update
    void Start()
    {
        
        _enemiesLeft = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _gameObject = GameObject.FindGameObjectsWithTag("Enemy");
        _enemiesLeft.SetText(_gameObject.Length+" left");
        if (_gameObject.Length<1)
        {
            timer--;
            if (timer < 0)
            {
                _fishRemaining = GameObject.FindGameObjectsWithTag("FishingZone");
                StaticValues.CoinsGained = _fishRemaining.Length * 10 + (int)(_fishRemaining.Length * moneyGain[StaticValues.CurrencyUpgrade]);
                StaticValues.Coins += StaticValues.CoinsGained;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("WinScreen");
            }
        }
    }
}
