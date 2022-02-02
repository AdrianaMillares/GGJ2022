using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    private float fireDelay;
    

    private Transform anchorObj;
    private Transform shootPoint;

    private Transform target;
    public float stoppingDistance;
    public float maxDistance;
    private float speed;
    private float vel;

    private void Start()
    {
        fireDelay = PlayerStats.fireDelay;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        fireDelay = PlayerStats.fireDelay;

        anchorObj = GameObject.Find("ProjectileCreature(Clone)").GetComponent<Transform>();
        shootPoint = GameObject.Find("ShootPoint").GetComponent<Transform>();

        speed = PlayerStats.movementSpeed - 2f;

        float shootHor = Input.GetAxis("ShootHorizontal");
        float shootVer = Input.GetAxis("ShootVertical");

        if((shootHor !=0 || shootVer != 0) && Time.time > lastFire + fireDelay)
        {
            Shoot(shootHor, shootVer);
            lastFire = Time.time;
        }

        if(anchorObj.transform.position == target.transform.position)
        {
            anchorObj.gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
        }
        else
        {
            anchorObj.gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = 2;
        }

        if (Vector2.Distance(anchorObj.transform.position, target.position) < stoppingDistance)
        {
            if(Vector2.Distance(anchorObj.transform.position, target.position) > maxDistance)
                {
                while(Vector2.Distance(anchorObj.transform.position, target.position) > maxDistance){
                    vel = speed;
                    vel = vel + 1;
                    anchorObj.transform.position = Vector2.MoveTowards(anchorObj.transform.position, target.position, vel * Time.deltaTime);
                }
            }
            else
            {
                anchorObj.transform.position = Vector2.MoveTowards(anchorObj.transform.position, target.position, speed * Time.deltaTime);
            }
        }

        void Shoot(float x, float y)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
            bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
                (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
                (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
                0
                );
        }
    }
}