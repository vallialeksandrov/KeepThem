using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private Message message;

    [SerializeField] private GameObject chickenPrefab;
    [SerializeField] private string info;

    private void OnMouseDown() => CreateChicken();

    private void CreateChicken()
    {
        Instantiate(chickenPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);

        message.Init(info);
    }
}
