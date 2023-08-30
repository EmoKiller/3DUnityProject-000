using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : Singleton<GameManager>
{
    

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SingletonTest()
    {
        Debug.Log("test sing");
    }

}
