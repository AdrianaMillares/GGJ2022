using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Regresar : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene("Room3");
    }
}