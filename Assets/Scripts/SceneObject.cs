using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSceneSwitch(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OnKeywordQuit()
    {
        Application.Quit();
    }
}
