using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaxHealthItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats.maxLife += 25f;
            Destroy(this.gameObject);
        }
    }
}