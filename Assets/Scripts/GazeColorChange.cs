using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeColorChange : MonoBehaviour
{
    private new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (CoreServices.InputSystem.GazeProvider.GazeTarget == gameObject)
        {
            renderer.material.color = Color.magenta;
        }
        else
        {
            renderer.material.color = Color.white;
        }
    }
}
