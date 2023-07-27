using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct VoiceCommand
{
    public string keyword;
    public GameObject prefab;
}

public class SpeechHandler : MonoBehaviour, IMixedRealitySpeechHandler
{
    [SerializeField]
    public List<VoiceCommand> commands;

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        foreach (VoiceCommand c in commands)
        {
            if (eventData.Command.Keyword.ToLower() == c.keyword) {
                Instantiate(c.prefab, CoreServices.InputSystem.GazeProvider.GazeDirection, Quaternion.identity);
                return;    
            }
        }

         Debug.Log("Unrecognized command " + eventData.Command.Keyword);
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
