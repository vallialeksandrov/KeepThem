using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ComplicationGame : MonoBehaviour
{
    public static UnityAction onComplicated;

    [SerializeField] private float difficultyPoints;

    private void OnEnable() => StandZone.onFinded += CountScore;

    private void OnDisable() => StandZone.onFinded -= CountScore;

    private void CountScore()
    {
        difficultyPoints += Time.deltaTime;

        if (difficultyPoints > 500)
        {
            onComplicated?.Invoke();
            difficultyPoints = 0;
        }   
    }
}
