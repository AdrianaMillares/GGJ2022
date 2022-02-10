using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRoom : MonoBehaviour
{
    private bool inArea = false;
    public GameObject[] bossPrefab;
    public Image image;
    public Image[] images;
    public GameObject canvas;
    private GameObject cutscene;
    private PlayerMovement player;
    private PlayerScript playerScript;
    public Animator anim;

    private void Start()
    {
        canvas.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    private void Update()
    {
        if(inArea == true)
        {
            StartCoroutine(ShowIllustration());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inArea = true;
        }
    }

    IEnumerator ShowIllustration()
    {
        if(PlayerStats.instance.bossIndex == 0)
        {
            //anim.SetTrigger("fade");
            PlayerMovement.instance.source.volume = 0f;
            player.enabled = false;
            playerScript.enabled = false;
            image.sprite = images[0].sprite;
            canvas.SetActive(true);
            yield return new WaitForSeconds(10f);
            PlayerMovement.instance.source.volume = 1f;
            player.enabled = true;
            playerScript.enabled = true;
            canvas.SetActive(false);
            Instantiate(bossPrefab[PlayerStats.instance.bossIndex], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (PlayerStats.instance.bossIndex == 1)
        {
            //anim.SetTrigger("fade");
            PlayerMovement.instance.source.volume = 0f;
            player.enabled = false;
            playerScript.enabled = false;
            image.sprite = images[1].sprite;
            canvas.SetActive(true);
            yield return new WaitForSeconds(10f);
            PlayerMovement.instance.source.volume = 1f;
            playerScript.enabled = true;
            player.enabled = true;
            canvas.SetActive(false);
            Instantiate(bossPrefab[PlayerStats.instance.bossIndex], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (PlayerStats.instance.bossIndex == 2)
        {
            //anim.SetTrigger("fade");
            PlayerMovement.instance.source.volume = 0f;
            player.enabled = false;
            playerScript.enabled = false;
            image.sprite = images[2].sprite;
            canvas.SetActive(true);
            yield return new WaitForSeconds(10f);
            PlayerMovement.instance.source.volume = 1f;
            playerScript.enabled = true;
            player.enabled = true;
            canvas.SetActive(false);
            Instantiate(bossPrefab[PlayerStats.instance.bossIndex], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(PlayerStats.instance.bossIndex == 3)
        {
            PlayerMovement.instance.source.volume = 0f;
            player.enabled = false;
            playerScript.enabled = false;
            cutscene = GameObject.Find("Cutscene").GetComponentInChildren<Canvas>().gameObject;
            cutscene.SetActive(true);
            yield return new WaitForSeconds(22f);
            PlayerMovement.instance.source.volume = 1f;
            playerScript.enabled = true;
            player.enabled = true;
            cutscene.SetActive(false);
            Instantiate(bossPrefab[PlayerStats.instance.bossIndex], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}