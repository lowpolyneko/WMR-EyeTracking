using Microsoft.MixedReality.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct GestureEvent
{
    public GestureType action;
    public bool isGlobal;
    public UnityEvent callback;
}

public class GestureHandler : MonoBehaviour
{
    [SerializeField]
    public List<GestureEvent> listeners;

    private bool hasPinched = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Edge case for when hand is not tracked
        if (!GestureRecognition.IsHandTracked())
            return;

        GestureType events = GestureType.None;
        if (GestureRecognition.IsPinching() && !hasPinched)
        {
            Debug.Log("Pinch Registered");
            hasPinched = true;
            events |= GestureType.Pinch;
        }
        else if (!GestureRecognition.IsPinching() && hasPinched)
        {
            hasPinched = false;
        }

        foreach (GestureEvent e in listeners)
        {
            // Only send callback if item is being looked at
            if (e.isGlobal || CoreServices.InputSystem.GazeProvider.GazeTarget == gameObject)
            {
                // Check for corrisponding event
                if ((e.action ^ events) == 0)
                    e.callback.Invoke();
            }
        }
    }
}
