using UnityEngine;  
public class BulletDmgItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerStats.bulletDamage += 1f;
            PlayerStats.attackDamage += 1f;
            Destroy(this.gameObject);
        }
    }
}