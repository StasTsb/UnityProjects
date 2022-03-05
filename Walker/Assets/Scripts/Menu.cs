using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //new
    [SerializeField] private Text coinsText;
    [SerializeField] private Text healthText;
    [SerializeField] private int coins;
    [SerializeField] private int health;

    private void Start()
    {
        int coins = PlayerPrefs.GetInt("coinN");
        coinsText.text = coins.ToString();        
        healthText.text = health.ToString();

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

    //NEWNEWNEWNENWE
    public void Change()
    {
        if (coins >= 10)
        {
            health++;
            coins =-10;
            //coinsText.text = coins.ToString();
            //healthText.text = coins.ToString();
        }
    }
    public void Video()
    {        
        int coins = PlayerPrefs.GetInt("coinN");
        coins += 100;
        coinsText.text = coins.ToString();        
    }
}
