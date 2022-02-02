using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReduceFireDelay : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats.fireDelay -= 0.5f;
            Destroy(this.gameObject);
        }
    }
}