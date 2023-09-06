using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDrop : MonoBehaviour
{
    private int number = 1;
    private SpriteRenderer flip = null;
    private void Start()
    {
        flip = GetComponent<SpriteRenderer>();
        if (number % 2 != 0 )
        {
            flip.flipX = true;
        }else
            flip.flipX = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("take Items");
            Debug.Log("Show :" + number);
            Destroy(gameObject);
        }
    }

}
