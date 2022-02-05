using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    private bool inArea = false;
    public GameObject[] bossPrefab;
    
    private void Update()
    {
        if( inArea == true)
        {
            Instantiate(bossPrefab[PlayerStats.instance.bossIndex], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inArea = true;
        }
    }
}