using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerPC : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;

    [SerializeField] private float smoothTime = 0.01f;
    [SerializeField] private float mutiRun = 1f;
    //Rolling
    //[SerializeField] private float CounttimeStopRoll = 0f;
    [SerializeField] private float timeCountRoll = 0.8f;
    [SerializeField] private float powerPushRoll = 200f;
    //jump
    [SerializeField] private float timeCountJump = 0.5f;
    public bool isRolling = false;
    public bool isJump = false;
    public bool canJump = true;
    public bool canRolling = true;
    public float horizontal { get; set; }
    public float vertical { get; set; }
    public bool isAlive { get; private set; }

    private bool horizontalDown => horizontal != 0;
    private bool verticalDown => vertical != 0;
    private Vector3 refVelocity = Vector3.zero;
    private Vector3 targetVelocity;
    [SerializeField] private Vector3 targetmove;
    [SerializeField] private HeroAnimatorController ani = null;
    [SerializeField] private Rigidbody rb = null;
    [SerializeField] private List<ChildrenDirectionMove> directionMove = null;
    //[SerializeField] private JoyStickLManager joystickLManager = null;

    private void Awake()
    {
        

        rb = GetComponent<Rigidbody>();
        ani = GetComponent<HeroAnimatorController>();
        directionMove = GetComponentsInChildren<ChildrenDirectionMove>().ToList();
        foreach (var Move in directionMove)
            Move.OnSelected = OnTabSelected;
        //joystickLManager = GameObject.FindGameObjectWithTag("JoyStickManager").GetComponent<JoyStickLManager>();
        isAlive = true;
    }
    void Start()
    {
        InvokeMove(1);

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
        
        //Run
        if (!isJump || !isRolling)
        {
            mutiRun = Input.GetKey(KeyCode.LeftShift) && (horizontal != 0 || vertical != 0) ? 1.5f : 1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            int num = horizontal > 0 ? 3 : 2;
            InvokeMove(num);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            int num = vertical > 0 ? 1 : 0;
            InvokeMove(num);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("DEF J Down");
            Attack();
            ani.Attack1H();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ani.Rolling();
            if (isRolling)
                return;
            timeCountRoll = 0.8f;
            isRolling = true;

            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!canJump)
                return;
            isJump = true;
            timeCountJump = 0.3f;
            Jump();
            canJump = false;
            
        }
        
        
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
            targetmove = targetVelocity.normalized;
        }
    }
    private void Attack()
    {
        TargetMoveZero();
        transform.DOMove(transform.position + targetmove, 0.2f);
    }
    private void Jump()
    {
        TargetMoveZero();
        //transform.DOJump(transform.localPosition + targetmove * 1.5f, 1f, 1, 0.3f).SetEase(Ease.InSine);
        rb.DOJump(transform.localPosition + targetmove * 1.5f, 1f, 1, 0.3f).SetEase(Ease.OutSine);
    }
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
    private void OnTabSelected(DirectionMove type)
    {
        foreach (var move in directionMove)
        {
            move.gameObject.SetActive(move.direction == type);
        }
        
    }
    private void InvokeMove(int num)
    {
        directionMove[num].ToggleOn();
        foreach (var Move in directionMove)
        {
            Move.myEvent.Invoke();
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
            if (timeCountJump > 0)
                timeCountJump -= Time.deltaTime;
            if (timeCountJump <= 0)
            {
                canJump = true;
            }
            //StartCoroutine(TimeCountDown(canJump, 0.5f));
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            
            
        }
    }
    IEnumerator TimeCountDown(bool can,float time)
    {
        
        yield return new WaitForSeconds(time);
        can = true;
        
    }
}
