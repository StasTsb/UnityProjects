using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    
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

}

