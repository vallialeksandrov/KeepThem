using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
    [SerializeField] private TMP_Text _messageText;
    
    public void Init(string message) => _messageText.text = message;
}
