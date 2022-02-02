using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource source;
    public AudioClip[] clips;
    int currentScene;

    private bool isPlaying;

    private void Start()
    {
        source.clip = clips[0];
        source.Play();
        isPlaying = true;

        source.volume = .4f;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != currentScene)
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
            if ((currentScene == 0 || currentScene == 2 || currentScene == 3 || currentScene == 4) && isPlaying == false)
            {
                source.clip = clips[0];
                source.Play();
                isPlaying = true;

            }
            else if ((currentScene == 0 || currentScene == 2 || currentScene == 3 || currentScene == 4) && isPlaying == true)
            {
                source.clip = clips[0];
            }

            else if (currentScene == 1)
            {
                isPlaying = false;
                source.Stop();
                source.clip = clips[1];
                source.Play();
            }
        }
    }
}