using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_PlayerMovement : MonoBehaviour
{
    [Header("Movement & Animation")]
    public Animator playerAnim;
    public Rigidbody rb;
    public CharacterController playerController;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed, horizontalInput, verticalInput;
    public float groundDrag;
    public bool walking = false;
    public bool idle = true;
    public bool falling = false;
    public bool sprinting = false;
    public float gravity = -9.81f;
    public float jumpHeight = 2.0f;
    public Transform orientation;
    Vector3 moveDirection;
    Vector3 playerVelocity;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;
    public bool inAir;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

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
        inAir = !Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.5f);
        //grounded = playerController.isGrounded;
        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        MyInput();
        MovePlayer();
        AnimationController();

    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //Vector3 move = new Vector3(horizontalInput * orientation.right, 0, verticalInput);
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        playerController.Move(moveDirection.normalized * w_speed * Time.deltaTime);

        if (moveDirection.normalized != Vector3.zero)
        {
            gameObject.transform.forward = moveDirection.normalized;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        playerController.Move(playerVelocity * Time.deltaTime);
    }


    private void AnimationController()
    {
        idle = true;
        sprinting = false;
        walking = false;
        falling = false;
        if (Input.GetButtonDown("Jump"))
        {
            playerAnim.SetTrigger("Jump");
        }
        if (inAir)
        {
            playerAnim.SetBool("Falling", true);
            falling = true;
        }
        else
        {
            playerAnim.ResetTrigger("Jump");
            playerAnim.SetBool("Falling", false);
            falling = false;
        }
        if (verticalInput != 0f || horizontalInput != 0f)
        {
            idle = false;
            walking = true;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                walking = false;
                sprinting = true;
                w_speed = w_speed + rn_speed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                walking = true;
                sprinting = false;
                w_speed = olw_speed;
            }

            if (walking)
            {
                playerAnim.SetBool("Jog", true);
                playerAnim.SetBool("Idle", false);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerAnim.SetBool("Sprint", true);
                playerAnim.SetBool("Jog", false);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerAnim.SetBool("Sprint", false);
                playerAnim.SetBool("Jog", true);
            }
        }
        else
        {
            if (!falling || Input.GetKeyUp(KeyCode.LeftShift))
            {
                idle = true;
                walking = false;
                sprinting = false;
                w_speed = olw_speed;
                playerAnim.SetBool("Jog", false);
                playerAnim.SetBool("Idle", true);
            }
        }

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    playerAnim.SetTrigger("Jog");
        //    playerAnim.ResetTrigger("Idle");
        //    walking = true;
        //}
        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    playerAnim.ResetTrigger("Jog");
        //    playerAnim.SetTrigger("Idle");
        //    walking = false;
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    playerAnim.SetTrigger("JogBack");
        //    playerAnim.ResetTrigger("Idle");
        //}
        //if (Input.GetKeyUp(KeyCode.S))
        //{
        //    playerAnim.ResetTrigger("JogBack");
        //    playerAnim.SetTrigger("Idle");
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        //}

        //if (walking == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.LeftShift))
        //    {
        //        w_speed = w_speed + rn_speed;
        //        playerAnim.SetTrigger("Sprint");
        //        playerAnim.ResetTrigger("Jog");
        //    }
        //    if (Input.GetKeyUp(KeyCode.LeftShift))
        //    {
        //        w_speed = olw_speed;
        //        playerAnim.ResetTrigger("Sprint");
        //        playerAnim.SetTrigger("Jog");
        //    }
        //}
    }
}
