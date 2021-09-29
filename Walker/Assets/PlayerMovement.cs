using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float RunSpeed = 500f;
    // скорость бега
    public float StrafeSpeed = 500f;
    // скорость смещения (право,лево)
    public float JumpForce = 10f;
    //сила прыжка

    protected bool StrafeLeft = false;
    protected bool StrafeRight = false;
    protected bool DoJump = false;

    void Update()
    {
        if (Input.GetKey("d"))
        {
            StrafeLeft = true;
        }
        else
        {
            StrafeLeft = false;
        }
        if (Input.GetKey("a"))
        {
            StrafeRight = true;
        }
        else 
        {
            StrafeRight = false;
        }
        if (Input.GetKeyDown("space"))
        {
            DoJump = true;       
        
        }
        //раскладка
    }
    private void FixedUpdate()
    {
        rb.AddForce(0, 0, RunSpeed * Time.deltaTime);
        //толчок по оcи z
    }
}
