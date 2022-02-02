using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerChest : MonoBehaviour
{
    private GameObject chest;
    public GameObject[] PowerUp;
    private bool InArea = false;

    static System.Random ran = new System.Random();
    private int powerUpIndex;
    private int chestPrice;

    void Update()
    {
        if (InArea && Input.GetKeyDown(KeyCode.E) && (Score.ScoreNum >= chestPrice))
        {
            InArea = false;
            Instantiate(PowerUp[powerUpIndex], chest.transform.position, Quaternion.identity);
            Score.ScoreNum -= chestPrice;
            Destroy(chest.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Chest")
        {
            InArea = true;
            chest = collider.gameObject;
            powerUpIndex = 0;
            chestPrice = 100;
        }

        if (collider.gameObject.tag == "Chest+")
        {
            InArea = true;
            chest = collider.gameObject;
            powerUpIndex = 1;
            chestPrice = 150;
        }

        if (collider.gameObject.tag == "Chest++")
        {
            InArea = true;
            chest = collider.gameObject;
            powerUpIndex = 2;
            chestPrice = 200;
        }
    }
}