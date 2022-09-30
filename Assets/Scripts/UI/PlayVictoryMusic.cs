using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVictoryMusic : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Persistent").GetComponent<MusicToggle>().SetWinMusic();
    }
}
