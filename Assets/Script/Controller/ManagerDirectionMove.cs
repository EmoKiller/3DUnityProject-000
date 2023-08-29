using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerDirectionMove : MonoBehaviour
{
    [SerializeField] public static List<ChildrenDirectionMove> directionMove = new List<ChildrenDirectionMove>();
    
    private void Awake()
    {
        directionMove = GetComponentsInChildren<ChildrenDirectionMove>().ToList();
        foreach (var Move in directionMove)
            Move.OnSelected = SetActiveDirectionMove;
        
    }
    private void Start()
    {
        SetActiveDirectionMove(DirectionMove.Front);
    }
    public void SetActiveDirectionMove(DirectionMove type)
    {
        foreach (var move in directionMove)
        {
            move.gameObject.SetActive(move.direction == type);
        }
    }
}
