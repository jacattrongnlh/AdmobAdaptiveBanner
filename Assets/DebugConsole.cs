using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour
{
    [SerializeField] private Text debugText;

    private void Start() { OnLogText += AddText; }

    private void AddText(string obj)
    {
        UnityMainThreadDispatcher.Instance().Enqueue(() => { debugText.text += $"{obj}\n"; });
    }

    public static Action<string> OnLogText;

    public static void Log(string text)
    {
        OnLogText?.Invoke(text);
    }
}