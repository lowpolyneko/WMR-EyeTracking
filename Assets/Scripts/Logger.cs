using Microsoft.MixedReality.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logger : MonoBehaviour
{
    public List<RemoteInteract> trackedInteracts;

    private string path;
    private FileStream oStream;

    // angular speed calc
    private Vector3 previousGazeDirection;
    private float previousTime;
    private float angularSpeed;

    // total movement/distance traveled
    private Vector3 totalMovement;

    // Start is called before the first frame update
    void Start()
    {
        // generate file name
        path = Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".csv";
        oStream = File.Create(path);

        string heading = "Time, Gaze Angular Speed, Distance Traveled, Total Movement, Gaze Origin, Gaze Target, Gaze Direction, Hit Position, Head Movement Dir, Head Velocity";
        for (int i = 0; i < trackedInteracts.Count; i++)
        {
            heading += ", Is object ontop of #" + (i + 1);
        }
        heading += "\n";

        WriteText(heading);

        previousGazeDirection = CoreServices.InputSystem.EyeGazeProvider.GazeDirection;
        previousTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate/Retrieve stats
        string dataLine = "";

        // angular speed
        // Calculate current gaze direction and time
        Vector3 currentGazeDirection = CoreServices.InputSystem.EyeGazeProvider.GazeDirection;
        float currentTime = Time.time;

        // Calculate change in gaze direction and time
        Vector3 gazeDirectionDelta = currentGazeDirection - previousGazeDirection;
        float timeDelta = currentTime - previousTime;

        // Calculate gaze angular speed
        angularSpeed = Vector3.Angle(gazeDirectionDelta, Vector3.forward) / timeDelta;

        // total movement
        Vector3 distanceTraveled = currentGazeDirection - previousGazeDirection;
        totalMovement += distanceTraveled.Abs();

        // Write data
        dataLine += currentTime;
        dataLine += ", " + angularSpeed;
        dataLine += ", " + Vector3ToString(distanceTraveled);
        dataLine += ", " + Vector3ToString(totalMovement);
        dataLine += ", " + Vector3ToString(CoreServices.InputSystem.GazeProvider.GazeOrigin);
        dataLine += ", " + CoreServices.InputSystem.GazeProvider.GazeTarget.name ?? "null";
        dataLine += ", " + Vector3ToString(currentGazeDirection);
        dataLine += ", " + Vector3ToString(CoreServices.InputSystem.GazeProvider.HitPosition);
        dataLine += ", " + Vector3ToString(CoreServices.InputSystem.GazeProvider.HeadMovementDirection);
        dataLine += ", " + Vector3ToString(CoreServices.InputSystem.GazeProvider.HeadVelocity);

        for (int i = 0; i < trackedInteracts.Count; i++)
        {
            dataLine += ", " + Convert.ToInt32(trackedInteracts[i].isTriggered);
        }
        dataLine += "\n";

        WriteText(dataLine);

        // Update previous gaze direction and time
        previousGazeDirection = currentGazeDirection;
        previousTime = currentTime;
    }

    private void OnApplicationQuit()
    {
        oStream.Close();
    }

    private void WriteText(string text)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(text);
        oStream.Write(info, 0, info.Length);
    }

    private string Vector3ToString(Vector3 v)
    {
        return string.Format("{0:0.00}:{1:0.00}:{2:0.00}", v.x, v.y, v.z);
    }
}
