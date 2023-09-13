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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {

            Debug.Log("Show Button Action");
            showUI.gameObject.SetActive(true);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !isOpen)
            {
                ani.SetBool("Open", true);
                StartCoroutine(Open());
                Debug.Log("Press E");
                isOpen = true;


            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
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
