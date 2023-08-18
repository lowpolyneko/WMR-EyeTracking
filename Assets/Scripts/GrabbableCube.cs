using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrabbableCube : MonoBehaviour
{
    private Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();

        // Set text on cube to be the name of the object
        GetComponentInChildren<TextMeshPro>().text = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrabStart()
    {
        myRenderer.material.color = Color.green;
    }

    public void OnGrabEnd()
    {
        myRenderer.material.color = Color.white;
    }
}
