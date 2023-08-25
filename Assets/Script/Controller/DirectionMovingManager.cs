using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMovingManager : MonoBehaviour
{
    [SerializeField] public ChildrenDirectionMove front = null;
    [SerializeField] public ChildrenDirectionMove back = null;
    [SerializeField] public ChildrenDirectionMove left = null;
    [SerializeField] public ChildrenDirectionMove right = null;
}
