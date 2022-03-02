using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    //NEWNEWNEWNEWNENWE
    [SerializeField] private GameObject LoosePanel;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    //nenwenenwnenwnewnenw

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
    //NEWNEWNEWNENWENWENWENWENWENENWENWEN
    public void Respawn()
    {
        LoosePanel.SetActive(false);
        SceneManager.GetActiveScene();
        Time.timeScale = 1;
        player.transform.position = respawnPoint.transform.position;
        Physics.SyncTransforms();
    }

}


