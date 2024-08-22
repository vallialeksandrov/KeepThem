using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    void Start() => transform.Rotate(transform.rotation * Random.insideUnitCircle * 100);
}
