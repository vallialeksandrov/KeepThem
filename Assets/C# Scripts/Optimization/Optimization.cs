using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Optimization : MonoBehaviour
{
    [SerializeField] private int currentLevelOpt;
    [SerializeField] private Toggle toggle;

    private const string nameKey = "LevelOptimization";

    private void Start()
    {           
        if (PlayerPrefs.HasKey(nameKey))
        {
            currentLevelOpt = PlayerPrefs.GetInt(nameKey);
            QualitySettings.SetQualityLevel(currentLevelOpt, true);
        }
        else
        {
            currentLevelOpt = 3;
            QualitySettings.SetQualityLevel(currentLevelOpt, true);
        }
    }

    public void SetQuality(int levelOptimization)
    {
        QualitySettings.SetQualityLevel(levelOptimization, true);
        PlayerPrefs.SetInt(nameKey, levelOptimization);
    }
}

