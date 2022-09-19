using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesManager : MonoBehaviour
{
    private int coins;
    [SerializeField] private UiController uiController;
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        uiController.UpdateCoins(coins);
    }
    public void AddCoins(int coin)
    {
        coins += coin;
        uiController.UpdateCoins(coins);
        PlayerPrefs.SetInt("coins", coins);
    }

    void Update()
    {
        
    }
}
