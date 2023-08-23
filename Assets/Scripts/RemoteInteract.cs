using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteInteract : MonoBehaviour
{
    public bool isTriggered;
    public Transform trackedObject;
    public Vector3 offset;

    private Renderer myRenderer;
    private Renderer trackedRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        trackedRenderer = trackedObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // only show if looking at
        myRenderer.enabled = CoreServices.InputSystem.GazeProvider.GazeTarget == gameObject;

        // track whatever object the remote interact belongs to
        transform.position = trackedObject.position + offset;
    }

    // Color change for set objects
    private void OnTriggerStay(Collider other)
    {
        trackedRenderer.material.color = Color.green;
        isTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        trackedRenderer.material.color = Color.white;
        isTriggered = false;
    }
}
