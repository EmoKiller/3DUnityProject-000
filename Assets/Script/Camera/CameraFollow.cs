using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransf;
    [SerializeField] private PlayerControllerPC player;
    [SerializeField] private Vector3 offset = new Vector3(0,9.7f, -13.3f);
    public float smooth;
    public bool endMove = false;
    public float timeCount = 0;
    private Vector3 vecref = Vector3.zero;
    // Start is called before the first frame update
    private void Awake()
    {
        playerTransf = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerPC>();
        transform.eulerAngles = new Vector3(37, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, playerTransf.transform.position + offset, ref vecref, smooth);
        if (player.isRolling || player.isJump)
        {
            smooth += Time.deltaTime * 1.1f;
            timeCount = 1.2f;
            endMove = false;
        }
        if (!endMove)
        {
            smooth -= Time.deltaTime * 0.5f;
            timeCount -= Time.deltaTime;
            if (timeCount <= 0)
            {
                smooth = 0.001f;
                endMove = true;
            }
        }
    }
}
