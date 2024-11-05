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
            string.Format($"Builds/{DateTime.Now}.apk"),
            BuildTarget.Android,
            BuildOptions.None);
    }
}