using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockMouseTime : MonoBehaviour
{
    public void Unlock()
    {
        //Unlock the player mouse
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //Setting time scale like this "un-freezes" time on everything
        Time.timeScale = 1;
    }

}
