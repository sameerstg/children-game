using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WhatToSayText : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        
        SpeechController._instance.onNewSpeech += (x) => text.text = "Say : "+x; 
    }
}
