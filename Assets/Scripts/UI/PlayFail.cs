using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFail : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Persistent").GetComponent<MusicToggle>().SetLoseMusic();
    }
}
