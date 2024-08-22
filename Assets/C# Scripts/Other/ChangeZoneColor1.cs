using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeZoneColor1 : MonoBehaviour
{
    [SerializeField] private ParticleSystem.ColorOverLifetimeModule _particleSystem;

    private void Start()
    {
        _particleSystem = gameObject.GetComponent<ParticleSystem>().colorOverLifetime;
    }

    private void OnTriggerEnter(Collider other)
    {
        _particleSystem.color = Color.red;
        StartCoroutine(BackToStartColor());
    }

    private IEnumerator BackToStartColor()
    {
        yield return new WaitForSeconds(3f);
        _particleSystem.color = Color.yellow;
    }
}
