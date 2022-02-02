using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    
    private float movementSpeed;
    Vector2 movement, normMovement;

    public Rigidbody2D rb;
    bool beingKnockedback = false;

    public Animator anim;

    public Transform attackAnchor;

    public SpriteRenderer melee;
    private Lifebar lifeBar;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lifeBar = gameObject.GetComponent<Lifebar>();
    }

    private void Update()
    {
        movementSpeed = PlayerStats.movementSpeed;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        normMovement = movement.normalized;

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            attackAnchor.localRotation = Quaternion.Euler(0, 0, 90);
            melee.sortingOrder = 1;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            attackAnchor.localRotation = Quaternion.Euler(0, 0, -90);
            melee.sortingOrder = 1;
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            attackAnchor.localRotation = Quaternion.Euler(0, 0, 180);
            melee.sortingOrder = 1;
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            attackAnchor.localRotation = Quaternion.Euler(0, 0, 0);
            melee.sortingOrder = 3;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + normMovement * movementSpeed * Time.fixedDeltaTime);

        if (!beingKnockedback) 
        {
            rb.velocity = normMovement * movementSpeed;
        }
    }

    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;
        beingKnockedback = true;

        while (timer < knockbackDuration)
        {
            timer += Time.deltaTime;
        
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.velocity = direction * knockbackPower;
            rb.AddForce(-direction * knockbackPower * 25);
        
            yield return null;
        }
        beingKnockedback = false;
    }
}