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
    public UnityEvent callback;
}

public class GestureHandler : MonoBehaviour
{
    [SerializeField]
    public List<GestureEvent> listeners;

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
        if (GestureRecognition.IsPinching())
        {
            Debug.Log("Pinch Registered");
            events |= GestureType.Pinch;
        }

        foreach (GestureEvent e in listeners)
        {
            // Only send callback if item is being looked at
            if (CoreServices.InputSystem.GazeProvider.GazeTarget == gameObject)
            {
                Debug.Log(gameObject + " is being observed!");

                // Check for corrisponding event
                if ((e.action & events) == events)
                    e.callback.Invoke();
            }
        }
    }
}
