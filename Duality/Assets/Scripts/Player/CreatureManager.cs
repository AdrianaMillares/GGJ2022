using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    private Transform player;
    public Transform attackPos;

    private int creatureIndex;

    public PlayerShoot creatureShooter;
    public static bool hasCreatureShooter;
    public GameObject creatureShooterPrefab;
    private GameObject creatureShooterInstance;

    public PlayerAttack creatureMelee;
    public static bool hasCreatureMelee;

    private Collider2D col;

    private bool InArea = false;

    public SpriteRenderer melee;

    private Animator anim;
    public RuntimeAnimatorController animatorController;
    public AnimatorOverrideController animatorOverride;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        hasCreatureShooter = false;
        creatureShooter.enabled = false;

        hasCreatureMelee = false;
        creatureMelee.enabled = false;

        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (hasCreatureMelee == true)
        {
            creatureMelee.enabled = true;
            melee.enabled = true;
            melee.GetComponent<Animator>().SetBool("Death", false);
            anim.runtimeAnimatorController = animatorOverride;
        }
        else
        {
            creatureMelee.enabled = false;
            melee.GetComponent<Animator>().SetBool("Death", true);
            melee.enabled = false;
            anim.runtimeAnimatorController = animatorController;
        }

        if (InArea && Input.GetKeyDown(KeyCode.E) && creatureIndex == 1)
        {
            InArea = false;
            hasCreatureShooter = true;
            hasCreatureMelee = false;
            creatureShooterInstance = Instantiate(creatureShooterPrefab, player.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
        else if (InArea && Input.GetKeyDown(KeyCode.E) && creatureIndex == 2)
        {
            InArea = false;
            hasCreatureMelee = true;
            hasCreatureShooter = false;
            Destroy(col.gameObject);
        }

        if (hasCreatureShooter == true && creatureShooterInstance != null)
        {
            creatureShooter.enabled = true;
        }
        else if(hasCreatureShooter == false)
        {
            creatureShooter.enabled = false;
            if(creatureShooterInstance != null)
            {
                creatureShooterInstance.GetComponent<Animator>().SetTrigger("Death");
                Destroy(creatureShooterInstance, 0.5f);
            }
            else
            {
                return;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("CreatureShooter"))
        {
            col = collider;
            InArea = true;
            creatureIndex = 1;
        }
        else if(collider.CompareTag("CreatureMelee"))
        {
            col = collider;
            InArea = true;
            creatureIndex = 2;
        }
    }
}