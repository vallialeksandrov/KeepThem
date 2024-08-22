using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private const string gameID = "5240393";
    [SerializeField] private bool testMode;

    private void Awake() => InitializeID();

    private void InitializeID()
    {
        Advertisement.Initialize(gameID, testMode, this);
    }

    public void OnInitializationComplete() => Debug.Log("Реклама успешно подлкючена");

    public void OnInitializationFailed(UnityAdsInitializationError error, string message) => Debug.LogError("Реклама не подключена");
}
