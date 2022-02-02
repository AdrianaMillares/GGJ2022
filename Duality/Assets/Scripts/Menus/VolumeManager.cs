using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;


    private void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = AudioManager.instance.source.volume;
    }

    private void Update()
    {
        volumeSlider.value = AudioManager.instance.source.volume;
    }

    public void SetVolume()
    {
        AudioManager.instance.source.volume = volumeSlider.value;
    }
}