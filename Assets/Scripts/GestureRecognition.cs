using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum GestureType
{
    None =  0b00,
    Pinch = 0b01,
    Grab =  0b10,
}

public static class GestureRecognition
{
    private const float PinchThreshold = 0.9f;
    private const float GrabThreshold = 0.4f;

    public static bool IsHandTracked()
    {
        var handJointService = CoreServices.GetInputSystemDataProvider<IMixedRealityHandJointService>();
        if (handJointService != null)
            return handJointService.IsHandTracked(Handedness.Left) || handJointService.IsHandTracked(Handedness.Right);

        return false;
    }

    public static bool IsPinching()
    {
        return HandPoseUtils.CalculateIndexPinch(Handedness.Both) > PinchThreshold;
    }
}
