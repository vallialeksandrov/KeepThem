using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private static bool isPlay;
    [SerializeField] private AudioSource backgroundAS;

    private void Awake()
    {
        if (isPlay == false)
        {
            backgroundAS.Play();

            DontDestroyOnLoad(this);
            isPlay = true; 
        }
    }
}
