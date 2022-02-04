using UnityEngine;

public class MoveSpeedItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats.movementSpeed += 5f;
            Destroy(this.gameObject);
        }
    }
}