using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class DirectionalGaze : MonoBehaviour
{

    private Vector3 lastGazeDirection;
    public Vector3 totalMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate travel between two vectors
        Vector3 currentDir = CoreServices.InputSystem.GazeProvider.GazeDirection;
        Vector3 distanceTraveled = currentDir - lastGazeDirection;
        totalMovement += distanceTraveled.Abs();
        Debug.Log("Distance Traveled: " + distanceTraveled);
        Debug.Log("Total Movement: " + totalMovement);

        lastGazeDirection = currentDir;
    }
}
