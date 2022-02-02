using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] DungeonManager dungeon;
    
    public void Play(){
        SceneManager.LoadScene("Room3");
    }

    public void Config(){
        SceneManager.LoadScene("Config", LoadSceneMode.Single);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void Quit(){
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}