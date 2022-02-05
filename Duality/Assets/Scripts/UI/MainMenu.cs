using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        PlayerStats.instance.bossIndex = 0;
        PlayerStats.movementSpeed = 8f;
        PlayerStats.attackDamage = 4.1f;
        PlayerStats.bulletDamage = 4.1f;
        PlayerStats.fireDelay = 1f;
        PlayerStats.maxLife = 100f;
        PlayerStats.actualLife = PlayerStats.maxLife;
        PlayerStats.hasCreatureShooter = false;
        PlayerStats.hasCreatureMelee = false;
        PlayerStats.hasCreatureMid = false;
        PlayerStats.hasCreatureGloves = false;

        SceneManager.LoadScene("Room3");
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void Config(){
        SceneManager.LoadScene("Config", LoadSceneMode.Single);
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void Quit(){
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
        FindObjectOfType<AudioManager>().Play("Button");
    }
}