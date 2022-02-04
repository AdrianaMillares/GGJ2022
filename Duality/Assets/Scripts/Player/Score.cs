using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public static int ScoreNum;

    void Start()
    {
        ScoreNum = 0;
        score.text = ScoreNum.ToString();
    }

    private void Update()
    {
        score.text = ScoreNum.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            ScoreNum ++;
            FindObjectOfType<AudioManager>().Play("Coin");
            Destroy(collision.gameObject);
        }
    }
}