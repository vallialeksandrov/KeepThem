using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StandZone : MonoBehaviour
{
    public static UnityAction onFinded, onLost;

    [SerializeField] private const string tagModel = "Crystal";
    [SerializeField] private int lostCount = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(tagModel))
            onFinded?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagModel))
        {
            lostCount++;       
            
            if (lostCount >= 3)
                onLost?.Invoke();
        }          
    }
}

