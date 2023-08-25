using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStickLManager : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform handle = null;
    public RectTransform joyStickL = null;
    public Vector2 joystickVec;
    public float joystickDist;
    public Vector2 joystickVecTest;
    public bool joystickMove => joystickVec.x != 0 || joystickVec.y != 0;

    private Vector2 joystickTouchPos;
    private float joystickRadius;
    private PlayerControllerPC Player;

    private void Awake()
    {
        
    }
    void Start()
    {
        joyStickL = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<RectTransform>();
        handle = GameObject.FindGameObjectWithTag("JoyStickHandle").GetComponent<RectTransform>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerPC>();
        joystickRadius = joyStickL.sizeDelta.y / 9 ;
    }

    void Update()
    {
         
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        Debug.Log("Inside Joystick L space");
        Debug.Log(eventData);
        joyStickL.transform.position = eventData.position;
        handle.transform.position = eventData.position;
        joystickTouchPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //handle.transform.position = eventData.position;
        Vector2 dragPos = eventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;
        joystickDist = Vector2.Distance(dragPos, joystickTouchPos);
        if (joystickDist < joystickRadius)
        {
            handle.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }
        else
        {
            handle.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
        Player.horizontal = joystickVec.x;
        Player.vertical = joystickVec.y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector2.zero;
        joystickVec = Vector2.zero;
    }
}
