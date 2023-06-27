using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeAngularVelocity : MonoBehaviour
{
    [SerializeField]
    private float timeInterval = 0.1f; // Time interval in seconds

    private Vector3 previousGazeDirection;
    private float previousTime;
    private float angularSpeed;

    void Start()
    {
        // Initialize previous gaze direction and time
        previousGazeDirection = CoreServices.InputSystem.EyeGazeProvider.GazeDirection;
        previousTime = Time.time;
    }

    void Update()
    {
        // Calculate current gaze direction and time
        Vector3 currentGazeDirection = CoreServices.InputSystem.EyeGazeProvider.GazeDirection;
        float currentTime = Time.time;

        // Calculate change in gaze direction and time
        Vector3 gazeDirectionDelta = currentGazeDirection - previousGazeDirection;
        float timeDelta = currentTime - previousTime;

        // Calculate gaze angular speed
        angularSpeed = Vector3.Angle(gazeDirectionDelta, Vector3.forward) / timeDelta;

        // Update previous gaze direction and time
        previousGazeDirection = currentGazeDirection;
        previousTime = currentTime;

        Debug.Log("Gaze angular speed: " + angularSpeed);
    }
}
