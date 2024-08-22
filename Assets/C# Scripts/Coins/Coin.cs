using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public static UnityAction onAddedCoin;
    private Action<Coin> _destroyAction;

    [SerializeField] private const string tagDeadZone = "DeadZone";

    public void Init(Action<Coin> destroyAction) => _destroyAction = destroyAction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CoinZoneLocate coinZoneLocate))
        {
            _destroyAction(this);
            onAddedCoin?.Invoke();
        }
        else if (other.CompareTag(tagDeadZone))
        {
            _destroyAction(this);
        }
    }
}
