using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartCurrentLevel : MonoBehaviour
{
    public void RestartLevel()
    {
        //Loads the selected level        
        Debug.Log("Restarting Current Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
