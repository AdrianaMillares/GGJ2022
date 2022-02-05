using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] DungeonManager dungeon;
    
    public void Play(){
        SceneManager.LoadScene("1");
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