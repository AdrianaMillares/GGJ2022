using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Image lifeBar, blackLifeBar;
    public static float actualLife;
    private float maxLife;

    public GameObject boss;
    private bool inArea;

    static System.Random ran = new System.Random();
    public GameObject lootDrop;
    public int maxCoins;
    public int minCoins;

    private void Start()
    {
        maxLife = 300f;
        actualLife = maxLife;
    }

    void Update()
    {
        lifeBar.fillAmount = actualLife / maxLife;
        
        if (inArea == true)
        {
            lifeBar.enabled = true;
            blackLifeBar.enabled = true;
        }
        else
        {
            lifeBar.enabled = false;
            blackLifeBar.enabled = false;
        }

        if (actualLife <= 0)
        {
            for (int i = 0; i < GenerateRnd(); i++)
            {
                Instantiate(lootDrop, transform.position, Quaternion.identity);
            }
            Destroy(boss);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inArea = false;
        }
    }
    public int GenerateRnd()
    {
        return ran.Next(minCoins, maxCoins);
    }
}