using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    protected virtual bool isAlive { get; private set; }


    public virtual void ShowInfomation()
    {
        Debug.Log("isAlive" + isAlive);
    }

}
