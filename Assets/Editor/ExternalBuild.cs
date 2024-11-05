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
            string.Format($"Builds/{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Hour}_{DateTime.Now.Minute}.apk"),
            BuildTarget.Android,
            BuildOptions.None);
    }
}