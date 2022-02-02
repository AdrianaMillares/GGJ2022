using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ConfigMenu : MonoBehaviour
{
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}