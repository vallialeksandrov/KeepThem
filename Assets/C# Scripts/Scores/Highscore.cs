using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Highscore : MonoBehaviour
{
    [SerializeField] private float highscore;
    [SerializeField] private TMP_Text highscoreText;

    private void Start() => UpdateRecord();

    private void UpdateRecord()
    {
        if (File.Exists(Application.persistentDataPath + "/saveScore.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveScore.dat", FileMode.Open);

            SaveDataScore data = (SaveDataScore)bf.Deserialize(file);
            file.Close();

            highscore = data.savedScore;
            highscoreText.text = "Рекорд: " + highscore.ToString("0");

            Debug.Log("Score is loading!");
            Debug.Log(data.savedScore);
        }
    }
}
