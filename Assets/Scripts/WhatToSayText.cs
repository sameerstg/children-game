using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WhatToSayText : MonoBehaviour
{
    Text text;
    private void Awake()
    {
        text = GetComponent<Text>();
    }
    private void Start()
    {
        
        SpeechController._instance.onNewSpeech += (x) => text.text = "Say : "+x; 
    }
}
