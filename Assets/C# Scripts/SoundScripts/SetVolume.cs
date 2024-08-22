using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;
    [SerializeField] private GameObject toggle;

    private void Start()
    {
        toggle.GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt("MusicOn") == 1;
    }

    public void PlayMusic(bool isMusicPlay)
    {
        if (isMusicPlay == true)
            mixer.audioMixer.SetFloat("MusicVolume", 0);

        if (isMusicPlay == false)
            mixer.audioMixer.SetFloat("MusicVolume", -80);

        PlayerPrefs.SetInt("MusicOn", isMusicPlay ? 1 : 0);
    }
}
