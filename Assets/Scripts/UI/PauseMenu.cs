using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        //Key Input for bringing up the menu
        if(Input.GetKeyUp(KeyCode.P))
        {
            if(gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    //Resumes the game
    public virtual void ResumeGame()
    {
        //Lock the player mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //Make the pause menu invisible
        pauseMenu.SetActive(false);

        //Setting time scale like this "un-freezes" time on everything
        Time.timeScale = 1;

        //Tell game it is not paused
        gameIsPaused = false;
    }

    //Pauses the game
    public virtual void PauseGame()
    {
        //Unlock the player mouse
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //Make the pause menu visible
        pauseMenu.SetActive(true);

        //Setting time scale like this "freezes" time on everything
        Time.timeScale = 0;

        //Tell game it is paused
        gameIsPaused = true;
    }

}
