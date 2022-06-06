using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CustomFileLogger : MonoBehaviour
{
    string fileName;

    private void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    // Start is called before the first frame update
    void Start()
    {
        fileName = Application.dataPath + "/LogFile.text";
    }


    void Log( string logString, string stackTrace, LogType logType)
    {
        TextWriter textWriter = new StreamWriter( fileName, true );
        textWriter.WriteLine( "[" + System.DateTime.Now + "]" + logString );
        textWriter.Close();
    }
}
