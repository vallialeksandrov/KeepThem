using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Bonus : MonoBehaviour
{
    public static UnityAction onGotCoin, onDecreasedSize, onIncreasedSize, onFreezed;  
    public static UnityAction<int> onPlayedSound;

    [SerializeField] private const string tagDeadZone = "DeadZone";

    public enum Names { coinBonus, decreaseSizeBonus, increaseSizeBonus, freezeBonus}
    public Names names = new Names();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CoinZoneLocate coinZoneLocate))
        {
            Destroy(gameObject);
            CheckBonus();
        }
        else if (other.CompareTag(tagDeadZone))
        {
            Destroy(gameObject);
        }
    }

    private void CheckBonus()
    {
        switch (names)
        {
            case Names.coinBonus:
                onGotCoin?.Invoke();
                onPlayedSound?.Invoke((int)Names.coinBonus);
                break;

            case Names.decreaseSizeBonus:
                onDecreasedSize?.Invoke();
                onPlayedSound?.Invoke((int)Names.decreaseSizeBonus);
                break;

            case Names.increaseSizeBonus:
                onIncreasedSize?.Invoke();
                onPlayedSound?.Invoke((int)Names.increaseSizeBonus);
                break;

            case Names.freezeBonus:
                onFreezed?.Invoke();
                onPlayedSound?.Invoke((int)Names.freezeBonus);
                break;
        }
    }      
}
