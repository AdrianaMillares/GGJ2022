using UnityEngine;  
public class BulletDmgItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Item");
            PlayerStats.bulletDamage += 0.5f;
            PlayerStats.attackDamage += 0.5f;
            Destroy(this.gameObject);
        }
    }
}