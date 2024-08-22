using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeController : MonoBehaviour
{
    private const string controlKey = "NumberController";

    public void ChangeControl(int numberController) => PlayerPrefs.SetInt(controlKey, numberController);
}
