using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class ExternalBuild
{
    public static void BuildCore()
    {
        FileLogger.Log("Build Core");

        var sceneList = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);

        BuildPipeline.BuildPlayer(
            sceneList.ToArray(),
            "Builds/JenkinsTest.apk",
            BuildTarget.Android,
            BuildOptions.None);
    }
}

public static class FileLogger
{
    private static string logFilePath = Path.Combine(Application.persistentDataPath, "jenkins_debug.log");

    public static void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine($"{System.DateTime.Now}: {message}");
        }
    }
}