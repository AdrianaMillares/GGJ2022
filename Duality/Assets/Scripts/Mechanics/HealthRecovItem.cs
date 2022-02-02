using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthRecovItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats.actualLife += 15f;
            if (PlayerStats.actualLife >= PlayerStats.maxLife)
            {
                PlayerStats.actualLife = PlayerStats.maxLife;
                Destroy(this.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}