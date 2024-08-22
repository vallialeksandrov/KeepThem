using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInterAd : MonoBehaviour
{
    [SerializeField] private int countTap;
    [SerializeField] private InterstitialAds interstitialAds;

    private void Start() => countTap = PlayerPrefs.GetInt("Tap");

    public void AddTap() 
    {
        countTap++;
        PlayerPrefs.SetInt("Tap", countTap);

        if (countTap >= 5)
        {
            countTap = 0;
            PlayerPrefs.SetInt("Tap", countTap);
            interstitialAds.ShowAd();         
        }      
    }
}
