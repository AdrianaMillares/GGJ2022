using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TameArea : MonoBehaviour
{
    private bool inArea;
    public BoxCollider2D col;
    public GameObject boss;

    public PlayerMovement movement;
    public GameObject choicePanel;
    private float criticalHealth;

    private void Start()
    {
        col.enabled = false;
        choicePanel.SetActive(false);
        movement.enabled = true;

        criticalHealth = BossHealthBar.actualLife * 0.25f;
    }

    public void Update()
    {
        if(inArea == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                movement.enabled = false;
                choicePanel.SetActive(true);
            }
        }

        if(BossHealthBar.actualLife <= criticalHealth)
        {
            col.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inArea = false;
    }

    public void TameBoss()
    {
        movement.enabled = true;
        Destroy(boss);
        choicePanel.SetActive(false);
    }

    public void KillBoss()
    {
        movement.enabled = true;
        Destroy(boss);
        choicePanel.SetActive(false);
    }
}