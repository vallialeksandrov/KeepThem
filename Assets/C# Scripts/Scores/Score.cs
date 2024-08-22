using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Score : MonoBehaviour
{
    public static UnityAction<float> onGotScore;

    [SerializeField] private float score, highscore;
    [SerializeField] private TMP_Text scoreText, endScoreText;

    private void Start() => LoadHighscore();

    private void OnEnable() => StandZone.onFinded += CountTime;

    private void OnDisable() => StandZone.onFinded -= CountTime;
        
    private void CountTime()
    {
        score += Time.deltaTime;
        onGotScore?.Invoke(score);

        scoreText.text = "Очки: " + score.ToString("0");
        endScoreText.text = "Очки: " + score.ToString("0");

        if (score > highscore)
            SaveScore();
    }

    private void LoadHighscore()
    {
        if (File.Exists(Application.persistentDataPath + "/saveScore.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveScore.dat", FileMode.Open);

            SaveDataScore data = (SaveDataScore)bf.Deserialize(file);
            file.Close();

            highscore = data.savedScore;
        }
    }

    private void SaveScore()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveScore.dat");

        SaveDataScore data = new SaveDataScore();

        data.savedScore = score;
        bf.Serialize(file, data);
        file.Close();
    }
}

[System.Serializable]
public class SaveDataScore
{
    public float savedScore;
}

