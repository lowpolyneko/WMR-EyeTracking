using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrabbableCube : MonoBehaviour
{
    private Renderer myRenderer;
    private AudioSource myAudioSource;

    public AudioClip pickupSFX;
    public AudioClip dropSFX;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        myAudioSource = GetComponent<AudioSource>();

        // Set text on cube to be the name of the object
        GetComponentInChildren<TextMeshPro>().text = transform.parent.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrabStart()
    {
        myRenderer.material.color = Color.green;

        myAudioSource.clip = pickupSFX;
        myAudioSource.Play();
    }

    public void OnGrabEnd()
    {
        myRenderer.material.color = Color.white;

        myAudioSource.clip = dropSFX;
        myAudioSource.Play();
    }

    // Color change for set objects
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "RemoteInteract")
            myRenderer.material.color = Color.green;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "RemoteInteract")
            myRenderer.material.color = Color.white;
    }
}
