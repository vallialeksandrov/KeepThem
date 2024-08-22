using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skibidi : MonoBehaviour
{
    [SerializeField] private Message message;
    [SerializeField] private string info;

    [SerializeField] private Animator headAnimator;
    [SerializeField] private AudioSource headAudioSource;

    [SerializeField] private GameObject oldToiletPrefab;

    private void OnMouseDown()
    {
        headAnimator.SetBool("isTap", true);
        headAudioSource.Play();

        oldToiletPrefab.SetActive(true);

        message.Init(info);
    }
}
