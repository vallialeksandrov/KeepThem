using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] bonusPrefabs;
    [SerializeField] private Transform spawnPosition;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 10, 10);
    }

    private void Spawn()
    {
        GameObject currentBP = Instantiate(bonusPrefabs[Random.Range(0, bonusPrefabs.Length)]);
        currentBP.transform.position = spawnPosition.position + Random.insideUnitSphere * 6;
    }
}
