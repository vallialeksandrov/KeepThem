using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartModel : MonoBehaviour
{
    [SerializeField] private GameObject[] models;
    [SerializeField] private Transform[] modelPositions;
    [SerializeField] private int currentModel;

    private void Awake() => currentModel = PlayerPrefs.GetInt("SaveSelectModel");

    private void Start()
    {       
        Instantiate(models[currentModel], modelPositions[0].position, Quaternion.identity);
        Instantiate(models[currentModel], modelPositions[1].position, Quaternion.identity);
        Instantiate(models[currentModel], modelPositions[2].position, Quaternion.identity);
    }
}
