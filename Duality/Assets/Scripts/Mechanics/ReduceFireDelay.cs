using UnityEngine;

public class ReduceFireDelay : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Item");
            PlayerStats.fireDelay -= 0.2f;
            Destroy(this.gameObject);
        }
    }
}