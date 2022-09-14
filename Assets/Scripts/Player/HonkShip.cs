using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HonkShip : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceComponent = null;
    [SerializeField] AudioClip honkSound = null;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.RightShift))
        {
            HonkSound();
        }
    }
    public void HonkSound()
    {
        audioSourceComponent.PlayOneShot(honkSound);
    }
}
