using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TameArea : MonoBehaviour
{
    private bool inArea;
    public BoxCollider2D col;
    public GameObject boss;

    private PlayerMovement movement;
    public GameObject choicePanel;
    public GameObject squidItem;
    public GameObject floorChange;

    public BossHealthBar bossHealthBar;

    private void Start()
    {
        col.enabled = false;
        choicePanel.SetActive(false);
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        movement.enabled = true;
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

        if(bossHealthBar.inCriticalState == true)
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
        Instantiate(floorChange, GameObject.Find("BossRoom(Clone)").transform.position, Quaternion.identity);
        Instantiate(squidItem, transform.position, Quaternion.identity);
        Destroy(boss);
        choicePanel.SetActive(false);
    }

    public void KillBoss()
    {
        Instantiate(floorChange, GameObject.Find("BossRoom(Clone)").transform.position, Quaternion.identity);
        choicePanel.SetActive(false);
        movement.enabled = true;
    }
}