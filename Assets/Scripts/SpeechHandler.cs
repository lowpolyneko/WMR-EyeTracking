using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechHandler : MonoBehaviour, IMixedRealitySpeechHandler
{
    public GameObject cubePrefab;

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        switch (eventData.Command.Keyword.ToLower())
        {
            case "cube": //spawn cube
                SpawnCube();
                break;
            default:
                Debug.Log("Unrecognized command " + eventData.Command.Keyword);
                break;
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

    void SpawnCube()
    {
        if (!cubePrefab)
            return;

        Instantiate(cubePrefab, CoreServices.InputSystem.GazeProvider.GazeDirection, Quaternion.identity);
    }
}
