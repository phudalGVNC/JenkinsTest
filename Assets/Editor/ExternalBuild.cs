using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class ExternalBuild
{
    public static void BuildCore_APK()
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

        var sceneList = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes); 

        PlayerSettings.Android.useAPKExpansionFiles = false;
        EditorUserBuildSettings.buildAppBundle = false;

        string apkName = string.Format($"Output/{DateTime.Now.Year}{DateTime.Now.Month.ToString("D2")}{DateTime.Now.Day.ToString("D2")}{DateTime.Now.Hour.ToString("D2")}{DateTime.Now.Minute.ToString("D2")}_{serverType}");

        BuildPipeline.BuildPlayer(
            sceneList.ToArray(),
            apkName + ".apk",
            BuildTarget.Android,
            BuildOptions.None);
    }

    public static void BuildCore_AAB()
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

        var sceneList = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);

        PlayerSettings.Android.useAPKExpansionFiles = true;
        EditorUserBuildSettings.buildAppBundle = true;

        string apkName = string.Format($"Output/{DateTime.Now.Year}{DateTime.Now.Month.ToString("D2")}{DateTime.Now.Day.ToString("D2")}{DateTime.Now.Hour.ToString("D2")}{DateTime.Now.Minute.ToString("D2")}_{serverType}");

        BuildPipeline.BuildPlayer(
            sceneList.ToArray(),
            apkName + ".aab",
            BuildTarget.Android,
            BuildOptions.None);
    }
}