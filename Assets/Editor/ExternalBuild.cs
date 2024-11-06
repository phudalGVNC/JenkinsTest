using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class ExternalBuild
{
    public static void BuildCore()
    {
        var sceneList = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);

        BuildPipeline.BuildPlayer(
            sceneList.ToArray(),
            string.Format($"Output/{DateTime.Now.Year}{DateTime.Now.Month.ToString("D2")}{DateTime.Now.Day.ToString("D2")}{DateTime.Now.Hour.ToString("D2")}{DateTime.Now.Minute.ToString("D2")}.apk"),
            BuildTarget.Android,
            BuildOptions.None);
    }
}