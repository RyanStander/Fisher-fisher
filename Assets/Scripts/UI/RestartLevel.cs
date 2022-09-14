using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(StaticValues.LastMission);
        //GameObject.FindGameObjectWithTag("Persistent").GetComponent<MusicToggle>().SetGameMusic();
    }
}
