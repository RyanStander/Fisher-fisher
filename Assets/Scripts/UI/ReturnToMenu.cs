using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToMenu()
    {
        //Loads the selected level        
        Debug.Log("Returning");
        //GameObject.FindGameObjectWithTag("Persistent").GetComponent<MusicToggle>().SetGameMusic();

        SceneManager.LoadScene("StartScene");
    }
}
