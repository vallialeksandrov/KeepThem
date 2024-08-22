using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

public class CoinsBank : MonoBehaviour
{
    [SerializeField] private int allCoins;
    [SerializeField] private TMP_Text allCoinsText;

    public int AllCoins {get => allCoins; set => allCoins = value;}

    private void Awake() => LoadCoins();

    public void SaveCoins()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");

        SaveData data = new SaveData();

        data.savedCoins = allCoins;
        allCoinsText.text = allCoins.ToString();

        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Save successful");
    }

    private void LoadCoins()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            allCoins = data.savedCoins;
            allCoinsText.text = allCoins.ToString();
        }
    }
}

[System.Serializable]
public class SaveData
{
    public int savedCoins;
}


