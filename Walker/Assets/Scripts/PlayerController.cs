using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private Vector3 dir;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] public float flipForce;
    [SerializeField] private float gravity;
    [SerializeField] private int coins;
    [SerializeField] private int health;

    [SerializeField] private GameObject losePanel;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text healthText;

    [SerializeField] private AudioSource backgroundmusic;
    [SerializeField] private AudioSource backgroundmusicloosepanel;
    
    private AudioSource audioSource;
    public AudioSource countsound;

    private int lineToMove = 1;
    public float lineDistance = 100;

    public int respawnplatform;      

    public GameObject Firstimgcount;
    public GameObject Secondimgcount;
    public GameObject Thirdimgcount;
    public GameObject Fourimgcount;

    public GameObject Pausebutton;

    void Start()
    {
        Time.timeScale = 1;

        anim = GetComponentInChildren<Animator>();
        anim.GetComponent<Animator>().enabled = false;

        coins = PlayerPrefs.GetInt("coinN");
        coinsText.text = coins.ToString();

        health = PlayerPrefs.GetInt("healtH");
        healthText.text = health.ToString();

        respawnplatform = 1;
        PlayerPrefs.SetInt("respawnplatform", respawnplatform);

        audioSource = GetComponent<AudioSource>();
        backgroundmusicloosepanel.Stop();
        backgroundmusic.Play();

        losePanel.SetActive(false);

        Firstimgcount.SetActive(false);
        Secondimgcount.SetActive(false);
        Thirdimgcount.SetActive(false);
        Fourimgcount.SetActive(false);

        Pausebutton.SetActive(false);

        StartCoroutine(CountCoroutine());
    }
    IEnumerator CountCoroutine()
    {
        countsound.Play();
        
        yield return new WaitForSeconds(0.20f);
        Firstimgcount.SetActive(true);
        yield return new WaitForSeconds(0.70f);
        Destroy(Firstimgcount);
        yield return new WaitForSeconds(0.20f);
        Secondimgcount.SetActive(true);
        yield return new WaitForSeconds(0.70f);
        Destroy(Secondimgcount);
        yield return new WaitForSeconds(0.20f);
        Thirdimgcount.SetActive(true);
        yield return new WaitForSeconds(0.70f);
        Destroy(Thirdimgcount);
        yield return new WaitForSeconds(0.20f);      
        Fourimgcount.SetActive(true);
        yield return new WaitForSeconds(0.70f);
        Destroy(Fourimgcount);

        countsound.Stop();
        Pausebutton.SetActive(true);

        anim.GetComponent<Animator>().enabled = true;        
        controller = GetComponent<CharacterController>();            
    }
    private void Update()
    {        
        if (SwipeController.swipeRight)
        {
            if (lineToMove <= 5)
                lineToMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove >= -3)
                lineToMove--;
        }

        if (SwipeController.swipeUp)
        {
            if (controller.isGrounded)
                Jump();
        }

        if (SwipeController.swipeDown)
        {
            if (controller.isGrounded)
                Flip();
        }

        if (controller.isGrounded)
            anim.SetTrigger("isRunning");

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(lineToMove <= 0)
            targetPosition += Vector3.left * lineDistance;
        if (lineToMove <= -1)
            targetPosition += Vector3.left * lineDistance;
        if (lineToMove <= -2)
            targetPosition += Vector3.left * lineDistance;
        if (lineToMove <= -3)
            targetPosition += Vector3.left * lineDistance;
        if (lineToMove <= -5)
            targetPosition += Vector3.left * lineDistance;
        if (lineToMove <= -6)
            targetPosition += Vector3.left * lineDistance;
        if(lineToMove <= -7)
            targetPosition += Vector3.left * lineDistance;
        if (lineToMove >= 2)
            targetPosition += Vector3.right * lineDistance;
        if (lineToMove >= 3)
            targetPosition += Vector3.right * lineDistance;
        if (lineToMove >= 4)
            targetPosition += Vector3.right * lineDistance;
        if (lineToMove >= 5)
            targetPosition += Vector3.right * lineDistance;
        if(lineToMove >= 6)
            targetPosition += Vector3.right * lineDistance;
        if(lineToMove >= 7)
            targetPosition += Vector3.right * lineDistance;
        if(lineToMove >= 8)
            targetPosition += Vector3.right * lineDistance;

        if (transform.position == targetPosition)
            return;

        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 75 * Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);

        speed += 0.1f * Time.deltaTime;                  
    }
    private void Jump()
    {
        dir.y = jumpForce;
        anim.SetTrigger("isJumping");
    }
    private void Flip()
    {
        dir.y = flipForce;
        anim.SetTrigger("isFlipping");
    }
    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
            backgroundmusic.Pause();
            backgroundmusicloosepanel.Play();
        } 

        if (other.gameObject.tag == "coins")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);            
            PlayerPrefs.SetInt("coinN", coins);
            audioSource.Play();
        }

        if (other.gameObject.tag == "respawngem1")
        {
            lineToMove = 1;
        }
        if (other.gameObject.tag == "respawngem2")
        {
            lineToMove = 5;
        }
        if (other.gameObject.tag == "respawngem3")
        {
            lineToMove = 1;
        }
        if (other.gameObject.tag == "respawngem4")
        {
            lineToMove = -1;
        }
        if (other.gameObject.tag == "respawngem5")
        {
            lineToMove = -1;
        }
        if (other.gameObject.tag == "respawngem6")
        {
            lineToMove = -1;
        }
        if (other.gameObject.tag == "respawngem7")
        {
            lineToMove = -1;
        }
        if (other.gameObject.tag == "respawngem8")
        {
            lineToMove = 2;
        }
        if (other.gameObject.tag == "RPPL")
        {
            respawnplatform++;
            PlayerPrefs.SetInt("respawnplatform", respawnplatform);
        }
    }    
}