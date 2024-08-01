using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;


public class s_PlayerMovement : MonoBehaviour
{
    [Header("Movement & Animation")]
    public Animator playerAnim;
    //public Rigidbody rb;
    public CharacterController playerController;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed, horizontalInput, verticalInput;
    //public float groundDrag;
    public bool walking = false;
    public bool idle = true;
    public bool falling = false;
    public bool sprinting = false;
    public float gravity = -9.81f;
    public float jumpHeight = 2.0f;
    public Transform orientation;
    public bool inMenu = false;
    Vector3 moveDirection;
    Vector3 playerVelocity;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;
    public bool inAir;

    [Header("Camera")]
    public CinemachineFreeLook cineMachine;

    [Header("Audio")]
    public AudioSource playerAudio;
    public AudioClip walk, run, jump;
    public bool audioPause = false;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        inAir = !Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.5f);
        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        if (!inMenu)
        {
            MyInput();
        }
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
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (inMenu)
        {
            moveDirection = Vector3.zero;
        }
        Vector3 desiredDir = moveDirection.normalized;
        //if (moveDirection != Vector3.zero)
        //{
        //    desiredDir = Vector3.Slerp(this.gameObject.transform.forward, moveDirection.normalized, Time.deltaTime * 0.1f);
        //}
        playerController.Move(desiredDir * w_speed * Time.deltaTime);

        if (moveDirection.normalized != Vector3.zero)
        {
            gameObject.transform.forward = moveDirection.normalized;
        }

        if (Input.GetButtonDown("Jump") && grounded && !inMenu)
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
        if (playerAudio.clip == null)
        {
            playerAudio.clip = walk;
        }
        if (Input.GetButtonDown("Jump"))
        {
            playerAnim.SetTrigger("Jump");
            playerAudio.loop = false;
            playerAudio.clip = jump;
            if (playerAudio.isPlaying && playerAudio.clip != jump)
            {
                playerAudio.Stop();
            }
            playerAudio.Play();
            playerAudio.pitch = 1.0f;
            playerAudio.volume = 0.25f;
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
            //if (playerAudio.clip == jump)
            //{
            //    playerAudio.clip = null;
            //}
        }
        if ((verticalInput != 0f || horizontalInput != 0f))
        {
            idle = false;
            walking = true;
            if (Input.GetKey(KeyCode.LeftShift) && !playerAudio.isPlaying && falling == false)
            {
                playerAudio.loop = true;
                playerAudio.clip = run;
                playerAudio.Play();
                playerAudio.pitch = 0.7f;
                playerAudio.volume = 0.25f;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                walking = false;
                sprinting = true;
                w_speed = w_speed + rn_speed;
                SprintAnim();
                if (playerAudio.clip == null)
                {
                    playerAudio.loop = true;
                    playerAudio.clip = run;
                }
                if (((!playerAudio.isPlaying) || playerAudio.clip == walk) && falling == false)
                {
                    playerAudio.loop = true;
                    playerAudio.clip = run;
                    playerAudio.Play();
                    playerAudio.pitch = 0.7f;
                    playerAudio.volume = 0.25f;
                }
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                walking = true;
                sprinting = false;
                w_speed = olw_speed;
                JogAnim();
                if (playerAudio.clip == null)
                {
                    playerAudio.loop = true;
                    playerAudio.clip = walk;
                }
                if (((!playerAudio.isPlaying) || playerAudio.clip == run) && falling == false)
                {
                    playerAudio.loop = true;
                    playerAudio.clip = walk;
                    playerAudio.Play();
                    playerAudio.pitch = 1.25f;
                    playerAudio.volume = 0.25f;
                }
            }
            else if (!Input.GetKey(KeyCode.LeftShift))
            {
                JogAnim();
                if (playerAudio.clip == null)
                {
                    playerAudio.loop = true;
                    playerAudio.clip = walk;
                }
                if (((!playerAudio.isPlaying) || playerAudio.clip == run) && falling == false)
                {
                    playerAudio.loop = true;
                    playerAudio.clip = walk;
                    playerAudio.Play();
                    playerAudio.pitch = 1.25f;
                    playerAudio.volume = 0.25f;
                }
            }
            //if (Input.GetKeyDown(KeyCode.LeftShift))
            //{
            //    playerAnim.SetBool("Sprint", true);
            //    playerAnim.SetBool("Jog", false);
            //}
            //if (Input.GetKeyUp(KeyCode.LeftShift))
            //{
            //    playerAnim.SetBool("Sprint", false);
            //    playerAnim.SetBool("Jog", true);
            //}
        }
        else
        {
            if (!falling || Input.GetKeyUp(KeyCode.LeftShift))
            {
                idle = true;
                walking = false;
                sprinting = false;
                w_speed = olw_speed;
                IdleAnim();
                if (playerAudio.isPlaying && playerAudio.clip != jump)
                {
                    playerAudio.Stop();
                    playerAudio.loop = false;
                }
            }
        }
    }

    public void EnterMenu()
    {
        inMenu = true;
        cineMachine.m_XAxis.m_InputAxisName = "Disabled";
        cineMachine.m_YAxis.m_InputAxisName = "Disabled";
        cineMachine.m_XAxis.m_InputAxisValue = 0f;
        cineMachine.m_YAxis.m_InputAxisValue = 0f;
    }

    public void ExitMenu()
    {
        inMenu = false;
        cineMachine.m_XAxis.m_InputAxisName = "Mouse X";
        cineMachine.m_YAxis.m_InputAxisName = "Mouse Y";
    }

    public void IdleAnim()
    {
        playerAnim.SetBool("Sprint", false);
        playerAnim.SetBool("Jog", false);
        playerAnim.SetBool("Idle", true);
    }

    public void JogAnim()
    {
        playerAnim.SetBool("Sprint", false);
        playerAnim.SetBool("Jog", true);
        playerAnim.SetBool("Idle", false);
    }

    public void SprintAnim()
    {
        playerAnim.SetBool("Sprint", true);
        playerAnim.SetBool("Jog", false);
        playerAnim.SetBool("Idle", false);
    }
}
