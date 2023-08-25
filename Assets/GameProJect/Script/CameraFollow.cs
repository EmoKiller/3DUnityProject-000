using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset = new Vector3(0,9.7f, -13.3f);
    public float smooth;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.eulerAngles = new Vector3(37, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        transform.DOLocalMove(desiredPosition, 1f);
    }
    
    private void LateUpdate()
    {
        
        
    }
}
