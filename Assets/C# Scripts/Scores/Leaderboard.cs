using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class Leaderboard : MonoBehaviour
{
    [HideInInspector] private string leaderboard = "CgkI3oi65uEXEAIQAQ";
    [SerializeField] private int _score;

    private void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(success =>
        {
            if (success)
                Debug.Log("Success");
            else
                Debug.LogError("Error22");
        });
    }

    private void OnEnable() => Score.onGotScore += AddScore;

    private void OnDisable() => Score.onGotScore -= AddScore;

    private void AddScore(float score)
    {
        _score = (int)score;
        Social.ReportScore(_score, leaderboard, (bool success) => { });
    }

    public void ShowLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }
}
