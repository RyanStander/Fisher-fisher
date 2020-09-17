using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUnpauseGame : PauseMenu
{
    public void UnpauseGame()
    {
        base.ResumeGame();
    }
}
