using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public struct PowerUpStruct
{
    public GameObject[] PowerUp;
}

public class PlayerChest : MonoBehaviour
{
    private GameObject chest;
    private bool InArea = false;

    private int powerUpIndex;
    private int powerUpSetIndex;
    private int chestPrice;

    public PowerUpStruct[] PowerUpSet = new PowerUpStruct[3];

    void Update()
    {
        if (InArea && Input.GetKeyDown(KeyCode.E) && (Score.ScoreNum >= chestPrice))
        {
            InArea = false;
            PickRandomNumber();

            Instantiate(PowerUpSet[powerUpSetIndex].PowerUp[powerUpIndex], chest.transform.position, Quaternion.identity);

            Score.ScoreNum -= chestPrice;
            Destroy(chest.gameObject);
        }
    }

    private void PickRandomNumber()
    {
        int randomNum = Random.Range(0, 2);

        powerUpIndex = randomNum;
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Chest")
        {
            InArea = true;
            chest = collider.gameObject;
            powerUpSetIndex = 0;
            chestPrice = 100;
        }

        if (collider.gameObject.tag == "Chest+")
        {
            InArea = true;
            chest = collider.gameObject;
            powerUpSetIndex = 1;
            chestPrice = 150;
        }

        if (collider.gameObject.tag == "Chest++")
        {
            InArea = true;
            chest = collider.gameObject;
            powerUpSetIndex = 2;
            chestPrice = 200;
        }
    }
}