using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ChildrenDirectionMove : MonoBehaviour 
{
    public DirectionMove direction;
    public Action<DirectionMove> OnSelected = null;
}
