using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_PlayerMovement : MonoBehaviour
{
    [Header("Movement & Animation")]
    public Animator playerAnim;
    public Rigidbody rb;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed, horizontalInput, verticalInput;
    public float groundDrag;
    public bool walking;
    public Transform orientation;
    Vector3 moveDirection;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
        //}
        MovePlayer();
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        AnimationController();
        MyInput();
        SpeedControl();

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * w_speed * 1f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > w_speed)
        {
            Vector3 limitedVel = flatVel.normalized * w_speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void AnimationController()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("Jog");
            playerAnim.ResetTrigger("Idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("Jog");
            playerAnim.SetTrigger("Idle");
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("JogBack");
            playerAnim.ResetTrigger("Idle");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("JogBack");
            playerAnim.SetTrigger("Idle");
        }
        //if (Input.GetKey(KeyCode.A))
        //{
        //    playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        //}

        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                w_speed = w_speed + rn_speed;
                playerAnim.SetTrigger("Sprint");
                playerAnim.ResetTrigger("Jog");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                w_speed = olw_speed;
                playerAnim.ResetTrigger("Sprint");
                playerAnim.SetTrigger("Jog");
            }
        }
    }
}
