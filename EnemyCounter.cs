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
    // Start is called before the first frame update
    void Start()
    {
        
        _enemiesLeft = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _gameObject = GameObject.FindGameObjectsWithTag("Enemy");
        _enemiesLeft.SetText(_gameObject.Length+" left");
        if (_gameObject.Length<1)
        {
            timer--;
            if (timer < 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
