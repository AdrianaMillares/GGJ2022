using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyLong : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float starTimeBtwShots;

    public GameObject projectile;
    private Transform player;
    public float damage;

    public Animator anim;
    public Transform shootPoint;
    float distance;
    public float shootArea;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = starTimeBtwShots;
    }

    public void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);

        if (distance < shootArea)
        {
            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);
                timeBtwShots = starTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(shootPoint.position, shootArea);
    }
}