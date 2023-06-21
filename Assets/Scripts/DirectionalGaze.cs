using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalGaze : MonoBehaviour
{

    private Vector3 lastGazeDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate travel between two vectors
        Vector3 currentDir = CoreServices.InputSystem.GazeProvider.GazeDirection;
        Debug.Log("Distance Traveled: " + (currentDir - lastGazeDirection));

        lastGazeDirection = currentDir;
    }
}
