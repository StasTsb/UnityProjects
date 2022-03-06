using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{    
    [SerializeField] private Text coinsText;
    [SerializeField] private Text healthText;
    [SerializeField] private int coins = PlayerPrefs.GetInt("coinN");
    [SerializeField] private int health = PlayerPrefs.GetInt("healtH");
    //NEW
    
    private void Start()
    {
        int coins = PlayerPrefs.GetInt("coinN");
        int health = PlayerPrefs.GetInt("healtH");
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
        
    public void Change()
    {
        int coins = PlayerPrefs.GetInt("coinN");
        int health = PlayerPrefs.GetInt("healtH");
        if (coins>= 500)
        {
            health++;
            coins -= 500;
        }                    
            healthText.text = health.ToString();
            PlayerPrefs.SetInt("healtH", health);            
            
            coinsText.text = coins.ToString();
            PlayerPrefs.SetInt("coinN", coins);          
    }
    public void Video()
    {
        int coins = PlayerPrefs.GetInt("coinN");
        coins += 50;
        coinsText.text = coins.ToString();        
        PlayerPrefs.SetInt("coinN", coins);
    }
}
