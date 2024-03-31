using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        string normalizeText = NormalizeSentence(said);

        if (normalizeText.ToLower() != speechesToSay[speechesSaid.Count].ToLower()) return;
        onSpeechSaid?.Invoke(speechesToSay[speechesSaid.Count]);

        speechesSaid.Add(speechesToSay[speechesSaid.Count]);

        if (speechesSaid.Count == speechesToSay.Count) return;
        GetSpeechToSay();
    }
    char[] forbiddenChars = new char[] { '.', '!', ',' };
    string NormalizeSentence(string sentence)
    {
        var normalizeText = sentence;

        foreach (char forbiddenChar in forbiddenChars)
        {
            normalizeText = normalizeText.Replace(forbiddenChar.ToString(), "");
        }

        return normalizeText;
    }
}
