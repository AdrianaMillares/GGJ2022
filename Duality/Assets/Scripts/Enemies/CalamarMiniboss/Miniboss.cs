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
    public LayerMask whatIsBoss;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet" && collision.IsTouchingLayers(whatIsBoss))
        {
            BossHealthBar.actualLife -= PlayerStats.bulletDamage;
            Destroy(collision.gameObject);
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        for (int i = 0; i < 3; i++)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.1f);
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.1f);
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