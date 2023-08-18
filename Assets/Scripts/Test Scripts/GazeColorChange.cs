using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeColorChange : MonoBehaviour
{
    private new Renderer renderer;
    private bool pinchToggle = false;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (pinchToggle)
            return;

        if (CoreServices.InputSystem.GazeProvider.GazeTarget == gameObject)
        {
            renderer.material.color = Color.magenta;
        }
        else
        {
            renderer.material.color = Color.white;
        }
    }


    public void OnPinch()
    {
        Debug.Log("Detected Gesture!");
        pinchToggle = !pinchToggle; // toggle so color is actually set
        renderer.material.color = Color.black;
    }
}
