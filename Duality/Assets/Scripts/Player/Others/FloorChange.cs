using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorChange : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerStats.instance.bossIndex++;
            anim.SetTrigger("FadeOut");
            Invoke(nameof(LoadScene), 1f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Room3");
    }
}