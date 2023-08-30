using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChestHandle : MonoBehaviour
{
    [SerializeField] private Animator ani;
    [SerializeField] private GameObject BaseEffect;
    [SerializeField] private GameObject showUI;
    [SerializeField] private GameObject coin;
    private bool isOpen = false;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && !isOpen)
        {
            
            Debug.Log("Show Button Action");
            showUI.gameObject.SetActive(true);
            
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !isOpen)
            {
                ani.SetBool("Open",true);
                StartCoroutine(Open());
                Debug.Log("Press E");
                isOpen = true;


            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Off Button Action");
            showUI.gameObject.SetActive(false);
        }
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(0.8f);
        BaseEffect.gameObject.SetActive(true);
    }

}
