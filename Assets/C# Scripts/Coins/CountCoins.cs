using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountCoins : MonoBehaviour
{
    [SerializeField] private CoinsBank coinsBank;

    [SerializeField] private int currentCoins;
    [SerializeField] private TMP_Text currentCoinsText, endCoinsText;

    private void Start()
    {
        currentCoins = 0;
        UpdateText();
    }

    private void OnEnable()
    {
        Coin.onAddedCoin += AddCoin;
        RewardedAds.onWatched += PresentCoins;
        EndGame.onLosedGame += SaveCurrentCoins;
    }

    private void OnDisable()
    {
        Coin.onAddedCoin -= AddCoin;
        RewardedAds.onWatched -= PresentCoins;
        EndGame.onLosedGame -= SaveCurrentCoins;
    }

    private void AddCoin()
    {
        currentCoins++;
        UpdateText();
    }

    private void SaveCurrentCoins()
    {
        coinsBank.AllCoins += currentCoins;
        coinsBank.SaveCoins();
    }

    private void PresentCoins()
    {
        currentCoins *= 3;
        UpdateText();

        SaveCurrentCoins();
    }

    private void UpdateText()
    {
        currentCoinsText.text = currentCoins.ToString();
        endCoinsText.text = "+ " + currentCoins.ToString();
    }
}
