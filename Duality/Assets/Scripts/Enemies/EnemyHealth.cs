using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    static System.Random ran = new System.Random();

    public GameObject lootDrop;
    public int maxCoins;
    public int minCoins;

    public void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            for(int i = 0; i < GenerateRnd(); i++) 
            { 
                Instantiate(lootDrop, transform.position, Quaternion.identity);
            }
        }
    }
     
    public int GenerateRnd()
    {
        return ran.Next(minCoins, maxCoins);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            health -= PlayerStats.bulletDamage;
            Destroy(collision.gameObject);
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
       for (int i = 0; i < 3; i++){
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.1f);
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }
}