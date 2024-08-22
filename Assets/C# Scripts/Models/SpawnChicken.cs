using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChicken : MonoBehaviour
{
    [SerializeField] private GameObject chickenPrefab;
    [SerializeField] private float stamina;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > stamina)
        {
            Instantiate(chickenPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
