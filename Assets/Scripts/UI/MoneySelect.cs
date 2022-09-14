using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneySelect : MonoBehaviour
{
    private int _selectedMoney = 0;
    [SerializeField] Sprite[] moneySprite = null;
    [SerializeField] string[] money= null;
    [SerializeField] string[] cost = { "0.99 cents > 30 coins", "2.99 cents > 100 coins", "4.99 cents > 200 coins" };
    [SerializeField] TextMeshProUGUI costText = null;
    [SerializeField] Image LeftPanel=null;
    [SerializeField] Image RightPanel=null;
    [SerializeField] Image MiddlePanel=null;
    public void Start()
    {
        MiddlePanel.sprite = moneySprite[_selectedMoney];
        RightPanel.sprite = moneySprite[_selectedMoney+1];
        LeftPanel.sprite = moneySprite[money.Length - 1];
        costText.SetText(cost[_selectedMoney]);
    }
    public void BuySelection()
    {
        //Loads the selected level        
        StaticValues.Coins += int.Parse(money[_selectedMoney]);
    }
    public void SelectLeft()
    {
        if (_selectedMoney == 0)
            _selectedMoney = money.Length - 1;
        else
            _selectedMoney--;
        costText.SetText(cost[_selectedMoney]);
        MiddlePanel.sprite = moneySprite[_selectedMoney];
        if (_selectedMoney == 0)
            LeftPanel.sprite = moneySprite[money.Length - 1];
        else
            LeftPanel.sprite = moneySprite[_selectedMoney - 1];
        if (_selectedMoney == money.Length - 1)
            RightPanel.sprite = moneySprite[0];
        else
            RightPanel.sprite = moneySprite[_selectedMoney + 1];
    }
    public void SelectRight()
    {
        if (_selectedMoney == money.Length - 1)
            _selectedMoney = 0;
        else
            _selectedMoney++;
        costText.SetText(cost[_selectedMoney]);
        MiddlePanel.sprite = moneySprite[_selectedMoney];
        if (_selectedMoney == 0)
            LeftPanel.sprite = moneySprite[money.Length - 1];
        else
            LeftPanel.sprite = moneySprite[_selectedMoney - 1];
        if (_selectedMoney == money.Length - 1)
            RightPanel.sprite = moneySprite[0];
        else
            RightPanel.sprite = moneySprite[_selectedMoney + 1];
    }

}
