using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private GameObject losePanel, gamePanel;

    private void OnEnable() => EndGame.onLosedGame += OpenLosePanel;

    private void OnDisable() => EndGame.onLosedGame -= OpenLosePanel;

    private void OpenLosePanel()
    {
        losePanel.SetActive(true);
        gamePanel.SetActive(false);
    }
}
