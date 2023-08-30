using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slash : MonoBehaviour
{
    
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());

    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1f);
        
        Destroy(gameObject);
    }
    // Update is called once per frame
    
}
