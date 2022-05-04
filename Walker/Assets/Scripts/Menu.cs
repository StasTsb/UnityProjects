using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{    
    [SerializeField] private Text coinsText;
    [SerializeField] private Text healthText;

    [SerializeField] private AudioSource changeaudio;
    [SerializeField] private AudioSource buttonsound;

    private void Start()
    {
        int coins = PlayerPrefs.GetInt("coinN");
        int health = PlayerPrefs.GetInt("healtH");
        coinsText.text = coins.ToString();        
        healthText.text = health.ToString();
      
    }
    public void PlayGame()
    {
        buttonsound.Play();       
        SceneManager.LoadScene(3);
              
    }
    public void QuiteGame()
    {
        buttonsound.Play();
        Application.Quit();
    }
    public void Exchanger()
    {
        buttonsound.Play();
        SceneManager.LoadScene(2);
    }
    public void BackMenu()
    {
        buttonsound.Play();
        SceneManager.LoadScene(0);
    }
        
    public void Change()
    {
        changeaudio.Play();

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
        buttonsound.Play();
        int coins = PlayerPrefs.GetInt("coinN");
        coins += 50;
        coinsText.text = coins.ToString();        
        PlayerPrefs.SetInt("coinN", coins);
    }
    public void Skip()
    {
        buttonsound.Play();
        SceneManager.LoadScene(1);        
    }
}
