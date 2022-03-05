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
    //NEWNEWNEW
    [SerializeField] private GameObject losePanel;
    [SerializeField] private Text coinsText;
            
    private int lineToMove = 1;
    public float lineDistance = 100;
           
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        losePanel.SetActive(false);
        Time.timeScale = 1;
        //NEW
        coins = PlayerPrefs.GetInt("coinN");
        coinsText.text = coins.ToString();
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
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obstacle")
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coins")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);
            //NEWNEWN
            PlayerPrefs.SetInt("coinN", coins);
        }               
    }
    
}