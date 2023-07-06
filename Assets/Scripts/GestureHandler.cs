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
            events |= GestureType.Pinch;

        foreach (GestureEvent e in listeners)
        {
            if ((e.action & events) != 0)
                e.callback.Invoke();
        }
    }
}
