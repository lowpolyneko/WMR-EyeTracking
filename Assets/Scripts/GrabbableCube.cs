using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrabbableCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set text on cube to be the name of the object
        GetComponentInChildren<TextMeshPro>().text = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
