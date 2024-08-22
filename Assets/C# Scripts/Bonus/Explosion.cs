using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Explosion : MonoBehaviour
{
    public static UnityAction<int> onExploded;

    [SerializeField] private float force, radius;
    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private MeshRenderer[] meshRenderers;

    private void OnTriggerEnter(Collider other) => StartCoroutine(Timer());

    private void OnTriggerExit(Collider other) => Invoke("ActiveMeshRenderer", 3f);

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);

        Collider[] overLappedColliders = Physics.OverlapSphere(transform.position, radius);

        for (int i = 0; i < overLappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overLappedColliders[i].attachedRigidbody;
            if (rigidbody)
                rigidbody.AddExplosionForce(force, transform.position, radius);
        }

        GameObject newPS = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(newPS, 2f);

        meshRenderers[0].enabled = false;
        meshRenderers[1].enabled = false;

        onExploded?.Invoke(4);
    }

    private void ActiveMeshRenderer()
    {
        meshRenderers[0].enabled = true;
        meshRenderers[1].enabled = true;
    }
}
