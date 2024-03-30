using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechController : MonoBehaviour
{
    public static SpeechController _instance;
    public List<string> speechesToSay;
    public List<string> speechesSaid;
    public Action<string> onNewSpeech, onSpeechSaid;
    private void Awake()
    {
        _instance = this;
    }
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        GetSpeechToSay();
    }
    public string GetSpeechToSay()
    {
        onNewSpeech?.Invoke(speechesToSay[speechesSaid.Count]);
        return speechesToSay[speechesSaid.Count];
    }
    public void SpeechSaid(string said)
    {
        Debug.LogError(said);
        if (said != speechesToSay[speechesSaid.Count]) return;
        onSpeechSaid?.Invoke(speechesToSay[speechesSaid.Count]);

        speechesSaid.Add(speechesToSay[speechesSaid.Count]);

        if (speechesSaid.Count == speechesToSay.Count) return;
        GetSpeechToSay();
    }
}
