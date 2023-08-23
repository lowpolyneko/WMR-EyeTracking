using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class EyeInteractionHandler : MonoBehaviour
{
    private GameObject selected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPinchStart()
    {
        GameObject target = CoreServices.InputSystem.GazeProvider.GazeTarget;

        if (!selected)
        {
            if (target.GetComponent<GrabbableCube>())
            {
                selected = target;
                selected.GetComponent<GrabbableCube>().OnGrabStart();
            }
            return;
        }

        if (target.name == "RemoteInteract")
            selected.transform.position = target.transform.position;
        selected.GetComponent<GrabbableCube>().OnGrabEnd();
        selected = null;
    }

    public void OnKeywordSelect()
    {
        GameObject target = CoreServices.InputSystem.GazeProvider.GazeTarget;

        if (!selected)
        {
            if (target.GetComponent<GrabbableCube>())
            {
                selected = target;
                selected.GetComponent<GrabbableCube>().OnGrabStart();
            }
            return;
        }

        selected.GetComponent<GrabbableCube>().OnGrabEnd();
        selected = null;
    }

    public void OnKeywordPlace()
    {
        GameObject target = CoreServices.InputSystem.GazeProvider.GazeTarget;

        if (selected)
        {
            if (target.name == "RemoteInteract")
                selected.transform.position = target.transform.position;

            selected.GetComponent<GrabbableCube>().OnGrabEnd();
        }

        selected = null;
    }
}
