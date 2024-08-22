using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandScale : MonoBehaviour
{
    private void OnEnable()
    {
        Bonus.onDecreasedSize += DecreaseSize;
        Bonus.onIncreasedSize += IncreaseSize;
    }

    private void OnDisable()
    {
        Bonus.onDecreasedSize -= DecreaseSize;
        Bonus.onIncreasedSize -= IncreaseSize;
    }

    private void DecreaseSize()
    {
        Vector3 currentSizes = transform.localScale;

        if (currentSizes.x > 0)
        {
            currentSizes.x -= 15; currentSizes.y -= 15; currentSizes.z -= 15;
            transform.localScale = currentSizes;
        }     
    }

    private void IncreaseSize()
    {
        Vector3 currentSizes = transform.localScale;

        if (currentSizes.x > 0)
        {
            currentSizes.x += 15; currentSizes.y += 15; currentSizes.z += 15;
            transform.localScale = currentSizes;
        }
    }
}
