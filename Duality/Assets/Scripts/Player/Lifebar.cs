using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Lifebar : MonoBehaviour
{
    public Image lifeBar;
    private float actualLife;
    private float maxLife;
    public bool invincible;

    private void Start()
    {
        maxLife = PlayerStats.maxLife;
        actualLife = maxLife;

        invincible = false;
    }

    public void Update()
    {
        actualLife = PlayerStats.actualLife;
        maxLife = PlayerStats.maxLife;
        
        lifeBar.fillAmount = actualLife / maxLife;

        if(actualLife <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && !invincible)
        {
            PlayerStats.actualLife -= col.gameObject.GetComponent<EnemyFollow>().damage;
            StartCoroutine(Damage());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !invincible)
        {
            PlayerStats.actualLife -= 1f;
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        invincible = true;
        for (int i = 0; i < 5; i++)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        invincible = false;
    }
}