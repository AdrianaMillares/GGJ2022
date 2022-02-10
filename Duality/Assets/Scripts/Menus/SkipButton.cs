using UnityEngine;

public class SkipButton : MonoBehaviour
{
    public GameObject loader;

    public void LoadScene()
    {
        loader.SetActive(true);
    }
}