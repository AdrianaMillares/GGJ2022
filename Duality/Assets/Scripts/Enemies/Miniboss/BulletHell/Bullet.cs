using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;

    private void OnEnable()
    {
        Invoke("Destroy", 5f);
        Physics2D.IgnoreLayerCollision(10, 10);
        Physics2D.IgnoreLayerCollision(10, 9);
        Physics2D.IgnoreLayerCollision(10, 12);
    }

    void Start()
    {
        moveSpeed = 5f;
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Invoke("Destroy", 0.001f);
        }
        if (collision.gameObject.tag.Equals("bigBullet"))
        {
            Invoke("Destroy", 0.001f);
        }
        if (collision.gameObject.layer.Equals(11))
        {
            Invoke("Destroy", 0.001f);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}