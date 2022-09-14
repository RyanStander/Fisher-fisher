using UnityEngine;

public class QuitGame : MonoBehaviour
{

    public void LeaveGame()
    {
        //exits the game
        Application.Quit();
        Debug.Log("Player has left the game!");
    }

    
}
