using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
 
public class CoinsPool : MonoBehaviour
{
    [SerializeField] private Coin coinPrefab;
    [SerializeField] private Transform coinPosition;

    [SerializeField] private int spawnAmount, lastSpawnAmount;

    [SerializeField] private bool isPlay;

    private ObjectPool<Coin> pool;

    private void Start()
    {
        isPlay = true;
        Spawn();
    }

    private void Spawn()
    {
        pool = new ObjectPool<Coin>(() =>
        { return Instantiate(coinPrefab); },
                    coin => { coin.gameObject.SetActive(true); },
                    coin => { coin.gameObject.SetActive(false); },
                    coin => { Destroy(coin.gameObject); }, false, 10, 80);

        InvokeRepeating(nameof(CreateCoin), 5, 5);
    }

    private void CreateCoin()
    {
        if (isPlay)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                Coin coin = pool.Get();
                coin.transform.position = coinPosition.position + Random.insideUnitSphere * 6;
                coin.Init(DestroyCoin);
            }
        }

        spawnAmount = lastSpawnAmount;
    }

    private void DestroyCoin(Coin coin) => pool.Release(coin);

    private void OnEnable()
    {
        ComplicationGame.onComplicated += IncreaseAmount;
        Bonus.onGotCoin += IncreaseBonusAmount;

        EndGame.onLosedGame += StopGame;
    }

    private void OnDisable()
    {
        ComplicationGame.onComplicated -= IncreaseAmount;
        Bonus.onGotCoin -= IncreaseBonusAmount;

        EndGame.onLosedGame -= StopGame;
    }

    private void IncreaseAmount()
    {     
        spawnAmount++;
        lastSpawnAmount++;
        Spawn();
    }

    private void IncreaseBonusAmount()
    {
        spawnAmount = 20;
        Spawn();
    }

    private void StopGame() => isPlay = false;
}
