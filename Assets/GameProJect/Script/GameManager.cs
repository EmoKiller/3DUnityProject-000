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

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine();
        
        //Debug.Log(gameObjecttest.gameObject.name);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void SingletonTest()
    {
        Debug.Log("test sing");
    }

}
