using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    private Transform player;
    public Transform attackPos;

    private int creatureIndex;

    public PlayerShoot creatureShooter;
    public GameObject creatureShooterPrefab;
    private GameObject creatureShooterInstance;

    public PlayerAttack creatureMelee;

    public PlayerMidAttack creatureMid;

    public PlayerGloves creatureGloves;

    private Collider2D col;

    private bool InArea = false;

    public SpriteRenderer melee;

    private Animator anim;
    public RuntimeAnimatorController animatorController;
    public AnimatorOverrideController animatorOverride;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
;
        creatureShooter.enabled = false;

        creatureMelee.enabled = false;

        creatureMid.enabled = false;

        creatureGloves.enabled = false;

        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (PlayerStats.hasCreatureMelee == true)
        {
            creatureMelee.enabled = true;
            melee.enabled = true;
            melee.GetComponent<Animator>().SetBool("Death", false);
        }
        else
        {
            creatureMelee.enabled = false;
            melee.GetComponent<Animator>().SetBool("Death", true);
            melee.enabled = false;
        }

        if(PlayerStats.hasCreatureMid == true)
        {
            creatureMid.enabled = true;
        }
        else
        {
            creatureMid.enabled = false;
        }

        if (PlayerStats.hasCreatureGloves == true)
        {
            creatureGloves.enabled = true;
            anim.runtimeAnimatorController = animatorOverride;
        }
        else
        {
            creatureGloves.enabled = false;
            anim.runtimeAnimatorController = animatorController;
        }

        if (InArea && Input.GetKeyDown(KeyCode.E) && creatureIndex == 1)
        {
            InArea = false;
            PlayerStats.hasCreatureShooter = true;
            PlayerStats.hasCreatureMelee = false;
            PlayerStats.hasCreatureMid = false;
            PlayerStats.hasCreatureGloves = false;
            Destroy(col.gameObject);
        }
        else if (InArea && Input.GetKeyDown(KeyCode.E) && creatureIndex == 2)
        {
            InArea = false;
            PlayerStats.hasCreatureMelee = true;
            PlayerStats.hasCreatureShooter = false;
            PlayerStats.hasCreatureMid = false;
            PlayerStats.hasCreatureGloves = false;
            Destroy(col.gameObject);
        }
        else if (InArea && Input.GetKeyDown(KeyCode.E) && creatureIndex == 3)
        {
            InArea = false;
            PlayerStats.hasCreatureMid = true;
            PlayerStats.hasCreatureShooter = false;
            PlayerStats.hasCreatureMelee = false;
            PlayerStats.hasCreatureGloves = false;
            Destroy(col.gameObject);
        }
        else if (InArea && Input.GetKeyDown(KeyCode.E) && creatureIndex == 4)
        {
            InArea = false;
            PlayerStats.hasCreatureGloves = true;
            PlayerStats.hasCreatureMid = false;
            PlayerStats.hasCreatureShooter = false;
            PlayerStats.hasCreatureMelee = false;
            Destroy(col.gameObject);
        }

        if (PlayerStats.hasCreatureShooter == true && creatureShooterInstance == null)
        {
            creatureShooter.enabled = true;
            creatureShooterInstance = Instantiate(creatureShooterPrefab, player.transform.position, Quaternion.identity);
            anim.runtimeAnimatorController = animatorController;
        }
        else if(PlayerStats.hasCreatureShooter == false)
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
        else if (collider.CompareTag("CreatureMid"))
        {
            col = collider;
            InArea = true;
            creatureIndex = 3;
        }
        else if (collider.CompareTag("CreatureGloves"))
        {
            col = collider;
            InArea = true;
            creatureIndex = 4;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InArea = false;
    }
}