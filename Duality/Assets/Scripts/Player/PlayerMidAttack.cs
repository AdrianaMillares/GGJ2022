using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMidAttack : MonoBehaviour
{
    public Transform attackAnchor;
    public Transform attackPos;
    public float attackRange;
    private float attackDamage;
    public LayerMask whatIsEnemies;

    private float timeBtwAttacks;
    public float starTimeBtwAttacks;

    private void Update()
    {
        attackDamage = PlayerStats.attackDamage;

        if (Input.GetAxis("ShootHorizontal") > 0)
        {
            attackAnchor.localRotation = Quaternion.Euler(0, 0, 90);
            if (timeBtwAttacks <= 0)
            {
                Attack();
                timeBtwAttacks = starTimeBtwAttacks;
            }
            else
            {
                timeBtwAttacks -= Time.deltaTime;
            }
        }
        if (Input.GetAxis("ShootHorizontal") < 0)
        {
            attackAnchor.localRotation = Quaternion.Euler(0, 0, -90);
            if (timeBtwAttacks <= 0)
            {
                Attack();
                timeBtwAttacks = starTimeBtwAttacks;
            }
            else
            {
                timeBtwAttacks -= Time.deltaTime;
            }
        }
        if (Input.GetAxis("ShootVertical") > 0)
        {
            attackAnchor.localRotation = Quaternion.Euler(0, 0, 180);
            if (timeBtwAttacks <= 0)
            {
                Attack();
                timeBtwAttacks = starTimeBtwAttacks;
            }
            else
            {
                timeBtwAttacks -= Time.deltaTime;
            }
        }
        if (Input.GetAxis("ShootVertical") < 0)
        {
            attackAnchor.localRotation = Quaternion.Euler(0, 0, 0);
            if (timeBtwAttacks <= 0)
            {
                Attack();
                timeBtwAttacks = starTimeBtwAttacks;
            }
            else
            {
                timeBtwAttacks -= Time.deltaTime;
            }
        }
    }

    void Attack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        foreach (Collider2D enemy in enemiesToDamage)
        {
            if (enemy.gameObject.tag == "Enemy")
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                StartCoroutine(Damage(enemy));
                if (enemy.GetComponent<EnemyHealth>().health > 0)
                {
                    FindObjectOfType<AudioManager>().Play("EnemyDamage");
                }
                else if (enemy.GetComponent<EnemyHealth>().health <= 0)
                {
                    FindObjectOfType<AudioManager>().Play("Explosion");
                }
            }
            else if (enemy.gameObject.tag == "Boss")
            {
                BossHealthBar.actualLife -= PlayerStats.attackDamage;
                StartCoroutine(Damage(enemy));
                FindObjectOfType<AudioManager>().Play("EnemyDamage");
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator Damage(Collider2D enemy)
    {
        if (enemy != null)
        {
            for (int i = 0; i < 3; i++)
            {
                enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                yield return new WaitForSeconds(0.1f);
                if (enemy != null)
                {
                    enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                    yield return new WaitForSeconds(0.1f);
                }
                else { yield break; }
            }
        }
        else { yield break; }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}