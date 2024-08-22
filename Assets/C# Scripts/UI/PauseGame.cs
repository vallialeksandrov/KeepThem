using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            audioMixer.SetFloat("MusicVolume", -80);
        }         
        else
        {
            Time.timeScale = 1;
            audioMixer.SetFloat("MusicVolume", 0);
        }         
    }
}
