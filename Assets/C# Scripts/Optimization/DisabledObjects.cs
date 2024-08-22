using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;

    private const string saveKey = "SaveLevel";

    void Start()
    {
        if (PlayerPrefs.GetInt(saveKey) == 0)
            DisableObjects();
        else
            EnableObjects();
    }

    public void DisableObjects()
    {
        for (int i = 0; i < objects.Length; i++)
            objects[i].SetActive(false);

        PlayerPrefs.SetInt(saveKey, 0);
    }

    public void EnableObjects()
    {
        for (int i = 0; i < objects.Length; i++)
            objects[i].SetActive(true);

        PlayerPrefs.SetInt(saveKey, 1);
    }
}
