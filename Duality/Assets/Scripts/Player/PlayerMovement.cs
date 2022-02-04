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
    private Lifebar lifebar;

    Vector2 dashDir;
    float dashSpeed;
    public enum State
    {
        Normal,
        Rolling,
    }

    public State state;

    public Ghost ghost;

    private void Awake()
    {
        instance = this;

        state = State.Normal;

        lifebar = GetComponent<Lifebar>();
    }

    private void Update()
    {
        switch (state)
        {
            case State.Normal:

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

                if (Input.GetAxisRaw("Horizontal") > 0)
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

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    dashDir = normMovement;
                    dashSpeed = PlayerStats.movementSpeed * 10f;
                    state = State.Rolling;
                }
                break;

            case State.Rolling:

                lifebar.invincible = true;
                ghost.makeGhost = true;

                float dashSpeedDropMult = 5f;
                dashSpeed -= dashSpeed * dashSpeedDropMult * Time.deltaTime;

                float dashSpeedMinimum = 50f;
                if(dashSpeed < dashSpeedMinimum)
                {
                    state = State.Normal;
                    lifebar.invincible = false;
                    ghost.makeGhost = false;
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        switch(state)
        {
            case State.Normal:
                rb.MovePosition(rb.position + normMovement * movementSpeed * Time.fixedDeltaTime);

                if (!beingKnockedback)
                {
                    rb.velocity = normMovement * movementSpeed;
                }
                break;

            case State.Rolling:
                rb.velocity = dashDir * dashSpeed;
                break;
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
            rb.AddForce(-direction * knockbackPower * 20f);
        
            yield return null;
        }
        beingKnockedback = false;
    }
}