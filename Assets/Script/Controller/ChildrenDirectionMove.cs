using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ChildrenDirectionMove : MonoBehaviour
{
    public DirectionMove direction;
    public bool isOn = false;
    public Action<DirectionMove> OnSelected = null;
    public UnityEvent myEvent;
    private void Awake()
    {
        myEvent.AddListener(OnValueChanged);
    }
    private void OnValueChanged()
    {
        if (isOn)
            OnSelected?.Invoke(direction);
        Debug.Log("directionMove" + direction);
        Debug.Log("isOn" + isOn);
        isOn = false;
    }
    public void ToggleOn() => isOn = true;

    public void ToggleOff() => isOn = false;
}
