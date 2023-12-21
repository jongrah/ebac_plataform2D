using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

public class ItemManager : Singleton<ItemManager> 
{
    public SOInt coins;
    public SOInt planets;
    public TextMeshProUGUI uiTextCoins;
    public TextMeshProUGUI uiTextPlanets;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        planets.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    public void AddPlanets(int amount = 1)
    {
        planets.value += amount;
        UpdateUI();
    }

    private void UpdateUI ()
    {
        //uiTextCoins.text = coins.ToString();
        //UIInGameManager.Instance.UpdateTextCoins(coins.value.ToString());
    }
}
