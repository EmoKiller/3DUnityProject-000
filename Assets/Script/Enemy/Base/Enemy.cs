using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , IDamageAble ,IEnemyMoveAble
{
    [field: SerializeField] public float MaxHealth { get; set; } = 3f;
    public float CurrentHealth { get; set; }
    public Rigidbody2D rb { get; set; }
    public bool IsFacingRight { get; set; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void Damage(float damageMount)
    {
        CurrentHealth -= damageMount;
        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void MoveEnemy(Vector3 velocity)
    {
        rb.velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
    }

    public void CheckForLeftOrRightFacing(Vector3 velocity)
    {
        //if(IsFacingRight && velocity.x < 0f)
        //{
        //    Vector3 rotator = new Vector3(transform.position.x, transform.position.y , 180f);
        //}
    }
}
