using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private PlayerControllerPC player;
    [SerializeField] private Vector3 offset = new Vector3(0,9.7f, -13.3f);
    public float smooth;
    
    private Vector3 vecref = Vector3.zero;
    // Start is called before the first frame update
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerPC>();
        transform.eulerAngles = new Vector3(37, 0, 0);
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + offset, ref vecref, smooth);
        if (player.isRolling || player.isJump)
        {
            smooth += Time.deltaTime * 0.4f;
        }
        else 
        {
            smooth -= Time.deltaTime * 0.16f;
            if (smooth <= 0)
            {
                smooth = 0;
            }
        }
    }
}
