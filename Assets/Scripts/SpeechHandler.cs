using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct VoiceCommand
{
    public string keyword;
    public UnityEvent callback;
}

public class SpeechHandler : MonoBehaviour, IMixedRealitySpeechHandler
{
    [SerializeField]
    public List<VoiceCommand> listeners;

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        foreach (VoiceCommand c in listeners)
        {
            if (eventData.Command.Keyword.ToLower() == c.keyword) {
                c.callback.Invoke();
                return;    
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CoreServices.InputSystem.RegisterHandler<IMixedRealitySpeechHandler>(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
