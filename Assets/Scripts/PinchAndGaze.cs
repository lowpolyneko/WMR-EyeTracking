using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchAndGaze : MonoBehaviour
{
    [SerializeField]
    public float PinchThreshold = 0.7f;
    [SerializeField]
    public float GrabThreshold = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPinching())
        {
            Debug.Log("Detected Gesture!");
        }
    }

    private bool IsPinching()
    {
        return HandPoseUtils.CalculateIndexPinch(Handedness.Both) > PinchThreshold;
    }
}
