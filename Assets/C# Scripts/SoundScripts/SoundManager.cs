using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] sounds;

    private void OnEnable()
    {
        Bonus.onPlayedSound += PlaySound;
        Explosion.onExploded += PlaySound;
    }

    private void OnDisable()
    {
        Bonus.onPlayedSound -= PlaySound;
        Explosion.onExploded -= PlaySound;
    }

    private void PlaySound(int numberSound)
    {
        AudioClip playingClip = sounds[numberSound];
        audioSource.PlayOneShot(playingClip);
    }
}
