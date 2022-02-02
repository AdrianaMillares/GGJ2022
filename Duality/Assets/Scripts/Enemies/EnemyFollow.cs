using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    public float chaseArea;
    public float damage;

    public float knockbackPower = 100f;
    public float knockbackDuration = 1f;

    private Rigidbody2D rb;

    public Animator anim;
    private Lifebar lifeBar;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = this.gameObject.GetComponent<Rigidbody2D>();
        lifeBar = GameObject.FindGameObjectWithTag("Player").GetComponent<Lifebar>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < chaseArea)
        {
            ChasePlayer();
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }
    
    public void ChasePlayer()
    {
        Vector3 temp = Vector3.MoveTowards(transform.position, target.position, (speed * 10f) * Time.deltaTime);
        rb.MovePosition(temp);
        anim.SetBool("walking", true);

        ChangeAnim(temp - transform.position);
    }

    public void ChangeAnim(Vector2 direction)
    {
        if(direction.x > 0)
        {
            anim.SetFloat("moveX", 1f);
        }
        else if( direction.x < 0)
        {
            anim.SetFloat("moveX", -1f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !lifeBar.invincible)
        {
            StartCoroutine(PlayerMovement.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseArea);
    }
}