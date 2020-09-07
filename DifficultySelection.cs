using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelection : MonoBehaviour
{
    [SerializeField] GameObject mainButton=null;
    [SerializeField] GameObject[] otherButtons= new GameObject[2];
    public void ChooseButton()
    {
        mainButton.transform.localScale = new Vector3(1,1);
        for (int i = 0; i < otherButtons.Length; i++)
        {
            otherButtons[i].transform.localScale = new Vector3(0.75f, 0.75f);
        }
    }
}
