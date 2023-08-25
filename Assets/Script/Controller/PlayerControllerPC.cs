using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerPC : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    [SerializeField] private float smoothTime = 0.01f;
    [SerializeField] private float mutiRun = 1f;
    //Rolling
    [SerializeField] private float CounttimeStopRoll = 0f;
    [SerializeField] private float timeStopRoll = 0.8f;
    [SerializeField] private float powerPushRoll = 100f;
    private bool isRolling = false;
    public float horizontal { get; set; }
    public float vertical { get; set; }
    public bool isAlive { get; private set; }

    private bool horizontalDown => horizontal != 0;
    private bool verticalDown => vertical != 0;
    private Vector3 refVelocity = Vector3.zero;
    private Vector3 targetVelocity = Vector3.zero;
    [SerializeField] private Vector3 targetmove;
    [SerializeField] private HeroAnimatorController ani = null;
    [SerializeField] private Rigidbody rb = null;
    //[SerializeField] private JoyStickLManager joystickLManager = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<HeroAnimatorController>();
        //joystickLManager = GameObject.FindGameObjectWithTag("JoyStickManager").GetComponent<JoyStickLManager>();
        isAlive = true;
    }
    void Start()
    {
        
    }

    void Update()
    {
        //if (!joystickLManager.joystickMove)
        //{
        //    horizontal = Input.GetAxis("Horizontal");
        //    vertical = Input.GetAxis("Vertical");
        //}
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("ATK J Down");
            ani.Attack();
        }
        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log("DEF K Down");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ani.Rolling();
            if (isRolling)
                return;
            Debug.Log("Roll Space Down");
            isRolling = true;
            rb.velocity = targetmove;

            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Roll Space Down");
            Jump();
        }
        mutiRun = Input.GetKey(KeyCode.LeftShift) && (horizontal != 0 || vertical != 0) ? 1.5f : 1f;

    }
    private void FixedUpdate()
    {
        Move();
        //ani.SetAnimationMove(MathF.Abs(horizontal), MathF.Abs(vertical));
        Roll();
    }
    private void Move()
    {
        
        if (horizontalDown )
        {
            float eulerAngleY = horizontal < 0 ? 180 : 0;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, eulerAngleY, transform.eulerAngles.z);
        }

        if (!isRolling)
        {
            targetVelocity = new Vector3(horizontal, vertical) * moveSpeed * mutiRun;
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref refVelocity, smoothTime);
        }
    }
    private void Jump()
    {
        transform.DOJump(transform.localPosition + targetmove, 1f,1,2f);
    }
    private void Roll()
    {
        if (horizontalDown || verticalDown)
        {
            targetmove = targetVelocity.normalized;
            
        }
        if (isRolling)
        {
            
            CounttimeStopRoll += Time.deltaTime;
            
            if (CounttimeStopRoll <= timeStopRoll)
            {
                rb.AddForce(Vector3.SmoothDamp(targetmove, targetmove * powerPushRoll, ref refVelocity, 0.2f));

            }
            else
            {
                isRolling = false;
                CounttimeStopRoll = 0;
            }
        }
    }
}
