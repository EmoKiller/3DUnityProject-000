using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _Animator = null;
    private void Awake()
    {
        _Animator = GetComponent<Animator>();
    }
    
    public void SetAnimationMove(float Horizontal, float Vertical)
    {
        
        if (Input.GetKey(KeyCode.LeftShift) && (Horizontal != 0 || Vertical != 0))
        {
            _Animator.SetInteger("State", 2);
        }
        else if (Horizontal != 0 || Vertical != 0)
        {
            _Animator.SetInteger("State", 1);
        }
        else
        {
            _Animator.SetInteger("State", 0);
        }
    }
    public void Attack()
    {
        _Animator.SetTrigger("Slash");
    }
    public void Rolling()
    {
        _Animator.SetTrigger("Rolling");
    }
}
