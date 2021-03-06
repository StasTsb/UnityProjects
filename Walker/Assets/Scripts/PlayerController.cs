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
    [SerializeField] private AudioSource rocketsound;

    private AudioSource audioSource;
    public AudioSource countsound;

    private int lineToMove = 1;
    public float lineDistance = 100;

    private int respawnplatform;

    public GameObject Firstimgcount;
    public GameObject Secondimgcount;
    public GameObject Thirdimgcount;
    public GameObject Fourimgcount;

    public GameObject Pausebutton;
    public GameObject Nitrobutton;

    public GameObject NTR;

    [SerializeField] private float timeStart;
    [SerializeField] public Text textTimeStart;

    [SerializeField] private float timeRecord;
    [SerializeField] public Text textTimeRecord;

    public GameObject PlusMinusCoinNitro;

    private int preview;
    private int swipeup;
    private int swipedown;
    private int swipeleft;
    private int swiperight;

    public GameObject FingerUP;
    public GameObject FingerDown;
    public GameObject FingerLeft;
    public GameObject FingerRight;
    public GameObject FingerNitro;

    void Start()
    {
        preview = PlayerPrefs.GetInt("prevw");

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
        backgroundmusicloosepanel.Pause();

        int musicstatus = PlayerPrefs.GetInt("statusmus");
        if (PlayerPrefs.GetInt("statusmus") == 0)
        {
            backgroundmusic.Play();
        }        

        losePanel.SetActive(false);       

        Firstimgcount.SetActive(false);
        Secondimgcount.SetActive(false);
        Thirdimgcount.SetActive(false);
        Fourimgcount.SetActive(false);

        Pausebutton.SetActive(false);
        Nitrobutton.SetActive(false);

        NTR.SetActive(false);

        PlusMinusCoinNitro.SetActive(false);
        
        FingerUP.SetActive(false);
        FingerDown.SetActive(false);
        FingerLeft.SetActive(false);
        FingerRight.SetActive(false);
        FingerNitro.SetActive(false);

        swipeup = 1;
        swipedown = 1;
        swipeleft = 1;
        swiperight = 1;

        textTimeStart.text = timeStart.ToString("F2");
        timeRecord = PlayerPrefs.GetFloat("timerec");

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
        if (preview < 0)
        { 
            Nitrobutton.SetActive(false);        
        }        

        anim.GetComponent<Animator>().enabled = true;        
        controller = GetComponent<CharacterController>();   
        
    }   
    private void Update()
    {
        if(preview <= 0)
        {
            if (SwipeController.swipeUp & swipeup ==2)
            {
                if (controller.isGrounded)
                    Jump();               
                
                    Time.timeScale = 1;
                    FingerUP.SetActive(false);
                    swipeup = 1;                
            }
            if (SwipeController.swipeDown & swipedown == 2)
            {
                if (controller.isGrounded)
                    Flip();                
                
                    Time.timeScale = 1;
                    FingerDown.SetActive(false);
                    swipedown = 1;                
            }
            if (SwipeController.swipeLeft & swipeleft == 2)
            {
                if (lineToMove >= -3)
                    lineToMove--;
               
                    Time.timeScale = 1;
                    FingerLeft.SetActive(false);
                    swipeleft = 1;               
            }
            if (SwipeController.swipeRight & swiperight == 2)
            {
                if (lineToMove <= 5)
                    lineToMove++;
                
                    Time.timeScale = 1;
                    FingerRight.SetActive(false);
                    swiperight = 1;                
            }            
        }
        if (preview > 0)
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

        timeStart += Time.deltaTime;
        textTimeStart.text = timeStart.ToString("F2");

        if (coins < 10)
        {
            Nitrobutton.SetActive(false);
        }
        else if (coins >= 10)
        {
            Nitrobutton.SetActive(true);
        }

    }

    public void Nitro()
    {
        coins = PlayerPrefs.GetInt("coinN");
        if (coins >= 10) 
        {
            coins -= 10;
            coinsText.text = coins.ToString();
            PlayerPrefs.SetInt("coinN", coins);
            rocketsound.Play();
            StartCoroutine(NitroCoroutine());
            IEnumerator NitroCoroutine()
            {
                NTR.SetActive(true);
                speed += 100;
                PlusMinusCoinNitro.SetActive(true);
                yield return new WaitForSeconds(0.50f);
                speed -= 100;
                yield return new WaitForSeconds(0.50f);
                NTR.SetActive(false);
                PlusMinusCoinNitro.SetActive(false);               
                yield return new WaitForSeconds(0.50f);
            }
            if (preview <= 0)
            {
                FingerNitro.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            losePanel.SetActive(true);
            Pausebutton.SetActive(false);
            Nitrobutton.SetActive(false);
            Time.timeScale = 0;
            backgroundmusic.Pause();          
            backgroundmusicloosepanel.Play();            
        }

        if (other.gameObject.tag == "EndGameTime")
        {
            PlayerPrefs.SetFloat("timest", timeStart);
            PlayerPrefs.GetFloat("timerec");

            if (timeRecord >= timeStart)
            {
                timeRecord = timeStart;
                PlayerPrefs.SetFloat("timerec", timeRecord);
                SceneManager.LoadScene(3);
            }
            else
            {
                SceneManager.LoadScene(4);
            }
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

        if (other.gameObject.tag == "study1" & preview <= 0)
        {
            swipeup = 2;
            Time.timeScale = 0;
            FingerUP.SetActive(true);
        }
        if (other.gameObject.tag == "studydown" & preview <= 0)
        {
            swipedown = 2;
            Time.timeScale = 0;
            FingerDown.SetActive(true);
        }
        if (other.gameObject.tag == "studyleft" & preview <= 0)
        {
            swipeleft = 2;
            Time.timeScale = 0;
            FingerLeft.SetActive(true);
        }
        if (other.gameObject.tag == "studyright" & preview <= 0)
        {
            swiperight = 2;
            Time.timeScale = 0;
            FingerRight.SetActive(true);
                     
        }
        if (other.gameObject.tag == "studyNitro" & preview <= 0)
        {
            Nitrobutton.SetActive(true);
            Time.timeScale = 0;
            FingerNitro.SetActive(true);

        }
        if (other.gameObject.tag == "finalstudy" & preview <= 0)
        {
            preview = 1;
            PlayerPrefs.SetInt("prevw", preview);
        }     
        
    }    
}