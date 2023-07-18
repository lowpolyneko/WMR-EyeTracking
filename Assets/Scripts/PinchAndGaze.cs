using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchAndGaze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPinch()
    {
        Debug.Log("Detected Gesture!");
        GetComponent<Renderer>().material.color = Color.black;
    }
}
