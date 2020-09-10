using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    private int selectedLevel = 0;
    [SerializeField] Sprite[] upgradeSprite = null;
    [SerializeField] string[] _level=null;
    [SerializeField] TextMeshProUGUI _levelText=null;
    [SerializeField] Image LeftPanel=null;
    [SerializeField] Image RightPanel=null;
    [SerializeField] Image MiddlePanel=null;
    public void Start()
    {
        _levelText.SetText("Level: " + _level[selectedLevel]);
        MiddlePanel.sprite = upgradeSprite[selectedLevel];
        RightPanel.sprite = upgradeSprite[selectedLevel+1];
        LeftPanel.sprite = upgradeSprite[_level.Length - 1];
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
        MiddlePanel.sprite = upgradeSprite[selectedLevel];
        if (selectedLevel == 0)
            LeftPanel.sprite = upgradeSprite[_level.Length - 1];
        else
            LeftPanel.sprite = upgradeSprite[selectedLevel - 1];
        if (selectedLevel == _level.Length - 1)
            RightPanel.sprite = upgradeSprite[0];
        else
            RightPanel.sprite = upgradeSprite[selectedLevel + 1];
    }
    public void SelectRight()
    {
        if (selectedLevel == _level.Length - 1)
            selectedLevel = 0;
        else
            selectedLevel++;
        _levelText.SetText("Level: " + _level[selectedLevel]);
        MiddlePanel.sprite = upgradeSprite[selectedLevel];
        if (selectedLevel == 0)
            LeftPanel.sprite = upgradeSprite[_level.Length - 1];
        else
            LeftPanel.sprite = upgradeSprite[selectedLevel - 1];
        if (selectedLevel == _level.Length - 1)
            RightPanel.sprite = upgradeSprite[0];
        else
            RightPanel.sprite = upgradeSprite[selectedLevel + 1];
    }

}
