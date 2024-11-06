using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class ExternalBuild
{
    public static void BuildCore()
    {
        string serverType = "Default";
        string[] args = System.Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-serverType" && i + 1 < args.Length)
            {
                serverType = args[i + 1];
                break;
            }
        }

        BuildCore_APK(serverType);
    }

    public static void BuildCore_APK(string serverType)
    {
        var sceneList = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);

        PlayerSettings.Android.useAPKExpansionFiles = false;
        EditorUserBuildSettings.buildAppBundle = false;

        BuildPipeline.BuildPlayer(
            sceneList.ToArray(),
            string.Format($"Output/{DateTime.Now.Year}{DateTime.Now.Month.ToString("D2")}{DateTime.Now.Day.ToString("D2")}{DateTime.Now.Hour.ToString("D2")}{DateTime.Now.Minute.ToString("D2")}_{serverType}.apk"),
            BuildTarget.Android,
            BuildOptions.None);
    }

    public static void BuildCore_AAB()
    {
        var sceneList = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);

        PlayerSettings.Android.useAPKExpansionFiles = true;
        EditorUserBuildSettings.buildAppBundle = true;

        BuildPipeline.BuildPlayer(
            sceneList.ToArray(),
            string.Format($"Output/{DateTime.Now.Year}{DateTime.Now.Month.ToString("D2")}{DateTime.Now.Day.ToString("D2")}{DateTime.Now.Hour.ToString("D2")}{DateTime.Now.Minute.ToString("D2")}.aab"),
            BuildTarget.Android,
            BuildOptions.None);
    }
}