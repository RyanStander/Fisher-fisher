using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //[SerializeField] GameObject toggleObj;
    private int count;
    public void PlayGame()
    {
        //Loads the next scene in the list        

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    public void QuitGame()
    {
        //exits the game
        Application.Quit();
        Debug.Log("Player has left the game!");
    }
    /*public void ToggleObj()
    {
        count++;
        if (count % 2 == 1)
        {
            toggleObj.SetActive(true);
        }
        else
        {
            toggleObj.SetActive(false);
        }
    }*/
}
