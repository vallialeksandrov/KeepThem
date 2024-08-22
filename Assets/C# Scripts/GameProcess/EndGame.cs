using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    public static UnityAction onLosedGame;

    private void OnEnable() => StandZone.onLost += CountDestroyObjects;

    private void OnDisable() => StandZone.onLost -= CountDestroyObjects;

    private void CountDestroyObjects() => onLosedGame.Invoke();
}
