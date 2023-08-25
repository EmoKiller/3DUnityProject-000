using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedSingleton : Singleton<CreatedSingleton>
{
    private CreatedSingleton instance;
    
    private void Awake()
    {
        instance = Instance;
        
        //DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
