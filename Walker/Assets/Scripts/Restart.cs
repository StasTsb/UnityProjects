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
    [SerializeField] private AudioSource pausemus;
    [SerializeField] private AudioSource buttonsound;
    [SerializeField] private AudioSource rise;

    public GameObject Pausebutton;
    public GameObject Nitrobutton;

    public GameObject Nimb;

    public GameObject FingerUP;
    public GameObject FingerDown;
    public GameObject FingerLeft;
    public GameObject FingerRight;
    public GameObject FingerNitro;

    public void Start()
    {
        if (PlayerPrefs.GetInt("statusmus") == 0)
        {
            backgroundmusic.Play();
        }       
       pausemus.Stop();
       Pausebutton.SetActive(true);
       Nitrobutton.SetActive(true);
       rise.Stop();
       Nimb.SetActive(false);
    }
    
    public void RestartLevel()
    {   
        buttonsound.Play();
        pausemus.Pause();        
        SceneManager.LoadScene(1);
    }
    public void RestartLevelDistance()
    {
        buttonsound.Play();
        pausemus.Pause();
        SceneManager.LoadScene(4);
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
        Pausebutton.SetActive(true);
        Nitrobutton.SetActive(true);
        SceneManager.GetActiveScene();
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("statusmus") == 0)
        {
            backgroundmusic.Play();
        }       
        pausemus.Pause();
    }
    public void Pause()
    {
        PausePanel.SetActive(true);
        Pausebutton.SetActive(false);
        Nitrobutton.SetActive(false);
        Time.timeScale = 0;
        backgroundmusic.Pause();
        if (PlayerPrefs.GetInt("statusmus") == 0)
        {
            pausemus.Play();
        }

        FingerUP.SetActive(false);
        FingerDown.SetActive(false);
        FingerLeft.SetActive(false);
        FingerRight.SetActive(false);
        FingerNitro.SetActive(false);
    }    
    public void Respawn()
    {
        buttonsound.Play();
        int health = PlayerPrefs.GetInt("healtH");
        if (health >= 1)
        {
            LoosePanel.SetActive(false);
            Pausebutton.SetActive(true);
            Nitrobutton.SetActive(true);

            StartCoroutine(NitroCoroutine());
            IEnumerator NitroCoroutine()
            {
                Nimb.SetActive(true);
                yield return new WaitForSeconds(1);
                Nimb.SetActive(false);
            }
            rise.Play();

            if (PlayerPrefs.GetInt("statusmus") == 0)
            {
                backgroundmusic.Play();
            }            
            pausemus.Pause();
            health--;
            
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


