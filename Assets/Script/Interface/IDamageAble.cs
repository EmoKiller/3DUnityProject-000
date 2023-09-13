using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IDamageAble
{
    void Damage(float damageMount);
    void Die();
    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }
}
