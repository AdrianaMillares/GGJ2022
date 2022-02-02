using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    private Vector3 followVelocity = Vector3.zero;
    public float followSpeed = 0.1f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        Vector3 targetPos = Vector3.SmoothDamp(transform.position, playerTransform.position, ref followVelocity, followSpeed);
        transform.position = targetPos;
    }
}