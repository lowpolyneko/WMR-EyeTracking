using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTest : MonoBehaviour
{
    void Update()
    {
        LogCurrentGazeTarget();
        LogGazeDirectionOrigin();
    }

    void LogCurrentGazeTarget()
    {
        Debug.Log("User gaze is currently over game object: " + CoreServices.InputSystem.GazeProvider.GazeTarget);
    }

    void LogGazeDirectionOrigin()
    {
        Debug.Log("Gase is looking in direction: " + CoreServices.InputSystem.GazeProvider.GazeDirection);

        Debug.Log("Gaze Origin: " + CoreServices.InputSystem.GazeProvider.GazeDirection);
    }
}
