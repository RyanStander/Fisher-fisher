using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceComponent=null;
    [SerializeField] AudioClip buttonClickSound=null;
    [SerializeField] AudioClip buttonHoverSound=null;
    // Start is called before the first frame update
    public void HoverSound()
    {
        audioSourceComponent.PlayOneShot(buttonHoverSound);
    }
    public void ClickSound()
    {
        audioSourceComponent.PlayOneShot(buttonClickSound);
    }
}
