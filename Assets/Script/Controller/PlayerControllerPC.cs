using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerPC : MonoBehaviour
{

    public float HP = 100;
    [SerializeField] private float moveSpeed = 4f;

    [SerializeField] private float smoothTime = 0.01f;
    [SerializeField] private float mutiRun = 1f;
    //Rolling
    //[SerializeField] private float CounttimeStopRoll = 0f;
    [SerializeField] private float timeCountRoll = 0.8f;
    [SerializeField] private float powerPushRoll = 200f;
    //jump
    [SerializeField] private float timeCanJump = 0.5f;
    [SerializeField] private float timeCanRoll = 2f;
    public bool CanAction = true;
    public bool isRolling = false;
    public bool isJump = false;
    public bool canJump = true;
    public bool canRolling = true;
    public float horizontal { get; set; }
    public float vertical { get; set; }
    //public bool isAlive { get; private set; }

    private bool horizontalDown => horizontal != 0;
    private bool verticalDown => vertical != 0;
    private Vector3 refVelocity = Vector3.zero;
    private Vector3 targetVelocity;
    [SerializeField] private Vector3 targetmove;
    [SerializeField] private HeroAnimatorController ani = null;
    [SerializeField] private Rigidbody rb = null;
    [SerializeField] private ManagerDirectionMove directionMoves = null;
    [SerializeField] private JoyStickLManager joystickLManager = null;
    int num = 0;

    
    public ParticleSystem slash;
    //protected override bool isAlive => HP > 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<HeroAnimatorController>();
        directionMoves = GetComponentInChildren<ManagerDirectionMove>();
        joystickLManager = GameObject.FindGameObjectWithTag("JoyStickManager").GetComponent<JoyStickLManager>();
        
        
    }
    void Update()
    {
        // Pc && Mobile : Controller 
        if (!joystickLManager.joystickMove)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }
        //Run
        if (!isJump || !isRolling)
        {
            mutiRun = Input.GetKey(KeyCode.LeftShift) && (horizontal != 0 || vertical != 0) ? 1.5f : 1f;
        }
        //move
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            num = horizontal > 0 ? 3 : 2;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            num = vertical > 0 ? 1 : 0;
        }
        directionMoves.SetActiveDirectionMove((DirectionMove)num);
        //
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
            ani.Attack1H();
            Instantiate(slash, transform.position + (targetmove*3f), transform.rotation);
            


        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.rotation = Quaternion.Euler(0f, 50f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ani.Rolling();
            if (!canRolling)
                return;
            timeCountRoll = 0.8f;
            isRolling = true;
            canRolling = false;
            StartCoroutine(TimeCountDownRoll(timeCanRoll));

        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (!canJump)
        //        return;
        //    isJump = true;
        //    Jump();
        //    canJump = false;
        //    StartCoroutine(TimeCountDownJump(timeCanJump));
        //}
        
        
    }
    
    private void FixedUpdate()
    {
        Move();
        Roll();
        
        ani.SetAnimationMove(MathF.Abs(horizontal), MathF.Abs(vertical));
        
    }
    private void TargetMoveZero()
    {
        if (!horizontalDown && !verticalDown)
        {
            targetmove = Vector3.zero;
        }
    }
    private void TargetMoveNomal()
    {
        if (horizontalDown || verticalDown)
        {
            //targetmove = targetVelocity.normalized;
            targetmove = targetVelocity.normalized;
        }
    }
    private void Attack()
    {
        TargetMoveZero();
        transform.DOMove(transform.position + targetmove, 0.2f);
    }
    //private void Jump()
    //{
    //    TargetMoveZero();
    //    //transform.DOJump(transform.localPosition + targetmove * 1.5f, 1f, 1, 0.3f).SetEase(Ease.InSine);
    //    rb.DOJump(transform.localPosition + targetmove * 1.5f, 1f, 1, 0.3f).SetEase(Ease.OutSine);
    //}
    private void Move()
    {
        TargetMoveNomal();
        if (!isRolling)
        {
            targetVelocity = new Vector3(horizontal,0, vertical) * moveSpeed * mutiRun;
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref refVelocity, smoothTime);
            
        }
        
    }
    
    private void Roll()
    {
        if (isRolling)
        {
            timeCountRoll -= Time.deltaTime;
            
            if (timeCountRoll >= 0)
            {
                rb.AddForce(Vector3.SmoothDamp(targetmove, targetmove * powerPushRoll, ref refVelocity, 0.2f));
            }
            else
            {
                isRolling = false;
                timeCountRoll = 0;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Debug.Log("on Ground");
            isJump = false;
            
        }
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            //if (timeCountJump > 0)
            //    timeCountJump -= Time.deltaTime;
            //if (timeCountJump <= 0)
            //{
            //    canJump = true;
            //}
            //StartCoroutine(TimeCountDown(canJump, 0.5f));
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            
            
        }
    }
    
    //public override void ShowInfomation()
    //{
    //    base.ShowInfomation();
    //}
    IEnumerator TimeCountDownJump(float time)
    {
        yield return new WaitForSeconds(time);
        canJump = true;
    }
    IEnumerator TimeCountDownRoll(float time)
    {
        yield return new WaitForSeconds(time);
        canRolling = true;
    }
    
}
