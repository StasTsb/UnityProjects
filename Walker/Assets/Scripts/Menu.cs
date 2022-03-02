using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //new
    [SerializeField] private Text coinsText;    
    private void Start()
    {
        int coins = PlayerPrefs.GetInt("coinN");
        coinsText.text = coins.ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }
    public void Exchanger()
    {
        SceneManager.LoadScene(2);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
