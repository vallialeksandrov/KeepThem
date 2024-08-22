using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinZoneLocate : MonoBehaviour
{
    [SerializeField] private Transform[] zonePositions;

    [SerializeField] private GameObject zoneVisible;
    [SerializeField] private ParticleSystem zonePS;

    private void Start()
    {
        StartCoroutine(ChangeLocation());
    }

    private IEnumerator ChangeLocation()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 15f));
            zonePS.Stop();

            zoneVisible.transform.position = zonePositions[Random.Range(0, zonePositions.Length)].position;
            zonePS.Play();
        }
    }
}
