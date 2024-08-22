using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private CoinsBank coinsBank;

    [Header("Модели")]
    [SerializeField] Models[] models;

    [Header("Проверка")]
    [SerializeField] private bool[] StockCheck;

    [Header("Цена")]
    [SerializeField] private Button buyButton;
    [SerializeField] private TMP_Text priceText;

    [Header("Индексы")]
    [SerializeField] private int index;
    [SerializeField] private int currentModel;
    [SerializeField] private TMP_Text nameText;

    [Header("Позиция")]
    [SerializeField] private Transform modelsPos;

    private void Awake()
    {
        index = PlayerPrefs.GetInt("chosenSkin");
        
        StockCheck = new bool[20];
        if (PlayerPrefs.HasKey("StockArray"))
        {
            StockCheck = PlayerPrefsX.GetBoolArray("StockArray");
        }          
        else
        {
            StockCheck[0] = true;
        }
            
        models[index].isChosen = true;

        for (int i = 0; i < models.Length; i++)
        {
            models[i].inStock = StockCheck[i];
            if (i == index)
            {
                modelsPos.GetChild(i).gameObject.SetActive(true);
            }               
            else
            {
                modelsPos.GetChild(i).gameObject.SetActive(false);
            }
        }

        priceText.text = "Выбран";
        buyButton.interactable = false;

        nameText.text = models[index].nameModels;
    }

    public void ScrollRight()
    {
        if (index < modelsPos.childCount - 1)
        {
            index++;

            if (models[index].inStock && models[index].isChosen)
            {
                priceText.text = "Выбрано";
                buyButton.interactable = false;

                currentModel = index;
                PlayerPrefs.SetInt("SaveSelectModel", currentModel);
            }
            else if (!models[index].inStock)
            {
                priceText.text = models[index].cost.ToString();
                buyButton.interactable = true;
            }
            else if (models[index].inStock && !models[index].isChosen)
            {
                priceText.text = "Выбрать";
                buyButton.interactable = true;
            }

            for (int i = 0; i < modelsPos.childCount; i++)
                modelsPos.GetChild(i).gameObject.SetActive(false);
       
            modelsPos.GetChild(index).gameObject.SetActive(true);

            nameText.text = models[index].nameModels;
        }
    }

    public void ScrollLeft()
    {
        if (index > 0)
        {
            index--;

            if (models[index].inStock && models[index].isChosen)
            {
                priceText.text = "Выбрано";
                buyButton.interactable = false;

                currentModel = index;
                PlayerPrefs.SetInt("SaveSelectModel", currentModel);
            }
            else if (!models[index].inStock)
            {
                priceText.text = models[index].cost.ToString();
                buyButton.interactable = true;
            }
            else if (models[index].inStock && !models[index].isChosen)
            {
                priceText.text = "Выбрать";
                buyButton.interactable = true;
            }

            for (int i = 0; i < modelsPos.childCount; i++)
            {
                modelsPos.GetChild(i).gameObject.SetActive(false);
            }

            modelsPos.GetChild(index).gameObject.SetActive(true);

            nameText.text = models[index].nameModels;
        }
    }

    public void Buy()
    {
        if (buyButton.interactable && !models[index].inStock)
        {
            if (coinsBank.AllCoins >= int.Parse(priceText.text))
            {
                coinsBank.AllCoins -= int.Parse(priceText.text);

                StockCheck[index] = true;
                models[index].inStock = true;
                priceText.text = "Выбрать";

                coinsBank.SaveCoins();
                Save();
            }
        }

        if (buyButton.interactable && !models[index].isChosen && models[index].inStock)
        {
            PlayerPrefs.SetInt("chosenSkin", index);
            buyButton.interactable = false;
            priceText.text = "Выбрано";

            currentModel = index;
            PlayerPrefs.SetInt("SaveSelectModel", currentModel);
        }
    }

    public void Save() => PlayerPrefsX.SetBoolArray("StockArray", StockCheck);
}


[System.Serializable]
public class Models
{
    public int cost;
    public bool inStock, isChosen;
    public string nameModels;
}