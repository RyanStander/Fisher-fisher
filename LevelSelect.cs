using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    private int selectedLevel = 0;
    [SerializeField] string[] _level=null;
    [SerializeField] TextMeshProUGUI _levelText=null;
    private float currentSelection;
    public void Start()
    {
        _levelText.SetText("Level: " + _level[selectedLevel]);
    }
    public void PlayGame()
    {
        //Loads the selected level        
        StaticValues.LastMission = _level[selectedLevel];
        SceneManager.LoadScene(_level[selectedLevel]);
    }
    public void SelectLeft()
    {
        if (selectedLevel == 0)
            selectedLevel = _level.Length - 1;
        else
            selectedLevel--;
        _levelText.SetText("Level: " + _level[selectedLevel]);
    }
    public void SelectRight()
    {
        if (selectedLevel == _level.Length - 1)
            selectedLevel = 0;
        else
            selectedLevel++;
        _levelText.SetText("Level: " + _level[selectedLevel]);
    }

}
