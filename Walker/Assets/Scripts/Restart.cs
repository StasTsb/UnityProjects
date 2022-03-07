using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;    
    [SerializeField] private GameObject LoosePanel;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    [SerializeField] private int health = PlayerPrefs.GetInt("healtH");
    [SerializeField] private Text healthText; 

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Play()
    {
        PausePanel.SetActive(false);
        SceneManager.GetActiveScene();
        Time.timeScale = 1;
    }
    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }    
    public void Respawn()
    {        
        int health = PlayerPrefs.GetInt("healtH");
        if (health >= 1)
        {
            health--;

            LoosePanel.SetActive(false);
            SceneManager.GetActiveScene();
            Time.timeScale = 1;

            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
        }
        healthText.text = health.ToString();
        PlayerPrefs.SetInt("healtH", health);        
    }
}


