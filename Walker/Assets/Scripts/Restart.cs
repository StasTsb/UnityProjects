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

    [SerializeField] private Text healthText;

    [SerializeField] private Transform respawnpoint1;
    [SerializeField] private Transform respawnpoint2;
    [SerializeField] private Transform respawnpoint3;
    [SerializeField] private Transform respawnpoint4;
    [SerializeField] private Transform respawnpoint5;
    [SerializeField] private Transform respawnpoint6;
    [SerializeField] private Transform respawnpoint7;
    [SerializeField] private Transform respawnpoint8;

    [SerializeField] private AudioSource backgroundmusic;
    [SerializeField] private AudioSource backgroundmusicloosepanel;
    [SerializeField] private AudioSource buttonsound;

    public void Start()
    {
       backgroundmusic.Play();
       backgroundmusicloosepanel.Pause();
    }
    
    public void RestartLevel()
    {   buttonsound.Play();
        backgroundmusicloosepanel.Pause();        
        SceneManager.LoadScene(1);
    }
    public void ToMenu()
    {
        buttonsound.Play();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Play()
    {        
        PausePanel.SetActive(false);
        SceneManager.GetActiveScene();
        Time.timeScale = 1;        
        backgroundmusic.Play();
        backgroundmusicloosepanel.Pause();
    }
    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        backgroundmusic.Pause();
        backgroundmusicloosepanel.Play();        
    }    
    public void Respawn()
    {
        buttonsound.Play();
        int health = PlayerPrefs.GetInt("healtH");
        if (health >= 1)
        {
            backgroundmusic.Play();
            backgroundmusicloosepanel.Pause();
            health--;

            LoosePanel.SetActive(false);
            SceneManager.GetActiveScene();
            Time.timeScale = 1;

            int respawncount = PlayerPrefs.GetInt("respawnplatform");
            if (respawncount == 1)
            {
                player.transform.position = respawnpoint1.transform.position;
            }
            if (respawncount == 2)
            {
                player.transform.position = respawnpoint2.transform.position;
            }
            if (respawncount == 3)
            {
                player.transform.position = respawnpoint3.transform.position;
            }
            if (respawncount == 4)
            {
                player.transform.position = respawnpoint4.transform.position;
            }
            if (respawncount == 5)
            {
                player.transform.position = respawnpoint5.transform.position;
            }
            if (respawncount == 6)
            {
                player.transform.position = respawnpoint6.transform.position;
            }
            if (respawncount == 7)
            {
                player.transform.position = respawnpoint7.transform.position;
            }
            if (respawncount >= 8)
            {
                player.transform.position = respawnpoint8.transform.position;
            }              
            Physics.SyncTransforms();
        }
        healthText.text = health.ToString();
        PlayerPrefs.SetInt("healtH", health);        
    }     
 
}


