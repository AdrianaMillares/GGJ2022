using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    private float attackDamage;

    private float timeBtwAttacks;
    public float starTimeBtwAttacks;

    public Animator anim;

    void Update()
    {
        attackDamage = PlayerStats.attackDamage;

        if (timeBtwAttacks <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                timeBtwAttacks = starTimeBtwAttacks;
            }
        }
        else
        {
            timeBtwAttacks -= Time.deltaTime;
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        foreach (Collider2D enemy in enemiesToDamage)
        {
            if(enemy.gameObject.tag == "Enemy")
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                StartCoroutine(Damage(enemy));
            }
            else if(enemy.gameObject.tag == "Boss")
            {
                BossHealthBar.actualLife -= PlayerStats.attackDamage;
                StartCoroutine(Damage(enemy));
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator Damage(Collider2D enemy)
    {
        if(enemy != null){
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
        }else{yield break;}
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}