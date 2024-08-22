using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.Events;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static UnityAction onWatched;

    [SerializeField] private Button adButton;
    [SerializeField] private const string rewardedID = "Rewarded_Android";

    private void Awake() => adButton.interactable = false;

    private void LoadAd()
    {
        Debug.Log("Loading Ad: " + rewardedID);
        Advertisement.Load(rewardedID, this);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(rewardedID))
        {
            adButton.onClick.AddListener(ShowAd);
            adButton.interactable = true;
        }
    }

    private void Start() => Advertisement.Load(rewardedID, this);

    public void ShowAd()
    {
        adButton.interactable = false;
        Advertisement.Show(rewardedID, this);
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(rewardedID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            onWatched?.Invoke();
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    void OnDestroy() => adButton.onClick.RemoveAllListeners();
}
