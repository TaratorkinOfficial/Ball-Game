using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    private TextMeshProUGUI textCoinCount;
    private Animation textAnim;
    [SerializeField] private GameObject gtextCoinCount;
    [SerializeField] private GameObject finishPanel;

    void Awake()
    {
        textCoinCount = gtextCoinCount.GetComponent<TextMeshProUGUI>();
        textAnim= gtextCoinCount.GetComponent<Animation>();
    }
    public void UpdateCoins(int coins)
    {
        textCoinCount.text = coins.ToString();
        textAnim.Play();
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
