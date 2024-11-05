using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExternalBuild
{
    public static void BuildCore()
    {
        var sceneList = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);

        BuildPipeline.BuildPlayer(
            sceneList.ToArray(),
            "JenkinsTest",
            BuildTarget.Android,
            BuildOptions.None);
    }
}
