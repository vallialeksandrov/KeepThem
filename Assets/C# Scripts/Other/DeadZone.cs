using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crystal"))
            Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
