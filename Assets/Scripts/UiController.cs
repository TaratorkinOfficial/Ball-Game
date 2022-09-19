using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoinCount;
    [SerializeField] private GameObject finishPanel;

    void Start()
    {
        
    }
    public void UpdateCoins(int coins)
    {
        textCoinCount.text = coins.ToString();
    }
    public void Finish()
    {
        finishPanel.SetActive(true);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        
    }
}
