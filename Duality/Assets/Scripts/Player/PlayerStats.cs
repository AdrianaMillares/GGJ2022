using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float movementSpeed;
    public static float attackDamage;
    public static float bulletDamage;
    public static float fireDelay;
    public static float actualLife;
    public static float maxLife;

    private void Awake()
    {
        movementSpeed = 13f;
        attackDamage = 5f;
        bulletDamage = 5f;
        fireDelay = 1f;
        maxLife = 100f;
        actualLife = maxLife;
    }
}