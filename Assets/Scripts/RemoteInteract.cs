using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteInteract : MonoBehaviour
{
    public Transform trackedObject;
    public Vector3 offset;

    private BoxCollider myCollider;
    private Renderer trackedRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        trackedRenderer = trackedObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // track whatever object the remote interact belongs to
        transform.position = trackedObject.position + offset;
    }

    // Color change for set objects
    private void OnTriggerStay(Collider other)
    {
        trackedRenderer.material.color = Color.green;
    }

    private void OnTriggerExit(Collider other)
    {
        trackedRenderer.material.color = Color.white;
    }
}
