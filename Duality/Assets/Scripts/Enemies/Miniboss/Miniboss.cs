using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miniboss : MonoBehaviour
{
    public float knockbackPower = 100f;
    public float knockbackDuration = 1f;

    public Transform shootPoint;
    public GameObject projectile;
    private float timeBtwShots;
    public float starTimeBtwShots;

    public float attackDuration;
    public Animator anim;
    private float timeBtwAttacks;
    public float starTimeBtwAttacks;

    private void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);
            timeBtwShots = starTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if(timeBtwAttacks <= 0)
        {
            StartCoroutine(Attack());
            timeBtwAttacks = starTimeBtwAttacks;
        }
        else
        {
            timeBtwAttacks -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(PlayerMovement.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
        }
    }

    public IEnumerator Attack()
    {
        float timer = 0f;
        while (timer < attackDuration)
        {
            timer += Time.deltaTime;
            anim.SetBool("IsAttacking", true);

            yield return null;
        }
        anim.SetBool("IsAttacking", false);
    }
}