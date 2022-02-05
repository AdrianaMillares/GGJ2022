using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public static float movementSpeed;
    public static float attackDamage;
    public static float bulletDamage;
    public static float fireDelay;
    public static float actualLife;
    public static float maxLife;
    public int bossIndex = 0;

    public static bool hasCreatureShooter;
    public static bool hasCreatureMelee;
    public static bool hasCreatureMid;
    public static bool hasCreatureGloves;

    private void Awake()
    {
        movementSpeed = 8f;
        attackDamage = 4.1f;
        bulletDamage = 4.1f;
        fireDelay = 1f;
        maxLife = 100f;
        actualLife = maxLife;

        hasCreatureShooter = false;
        hasCreatureMelee = false;
        hasCreatureMid = false;
        hasCreatureGloves = false;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}