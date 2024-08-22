using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private CoinsBank coinsBank;
    [SerializeField] private Message message;

    [SerializeField] private string info; 

    private void OnMouseDown() => GetRandomBonus();

    private void GetRandomBonus()
    {
        int bonus = Random.Range(-2, 2);
        coinsBank.AllCoins *= bonus;
        coinsBank.SaveCoins();

        message.Init(info + bonus);

        Destroy(this);
    }
}
