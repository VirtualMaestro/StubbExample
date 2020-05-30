#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;

public static class BuildScript
{
    private static readonly string[] EnabledScenes = _FindEnabledEditorScenes();

    // ------------------------------------------------------------------------
    // called from Jenkins
    // ------------------------------------------------------------------------
    public static void BuildMacOs()
    {
        var args = _FindArgs();

        var fullPathAndName = args.targetDir + args.appName + ".app";
        _BuildProject(EnabledScenes, fullPathAndName, BuildTargetGroup.Standalone, BuildTarget.StandaloneOSX,
            BuildOptions.None);
    }

    // ------------------------------------------------------------------------
    // called from Jenkins
    // ------------------------------------------------------------------------
    public static void BuildWindows64()
    {
        var args = _FindArgs();

        var fullPathAndName = args.targetDir + args.appName;
        _BuildProject(EnabledScenes, fullPathAndName, BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64,
            BuildOptions.None);
    }

    // ------------------------------------------------------------------------
    // called from Jenkins
    // ------------------------------------------------------------------------
    public static void BuildLinux()
    {
        var args = _FindArgs();

        string fullPathAndName = args.targetDir + args.appName;
        _BuildProject(EnabledScenes, fullPathAndName, BuildTargetGroup.Standalone, BuildTarget.StandaloneLinux64,
            BuildOptions.None);
    }

    private static Args _FindArgs()
    {
        var returnValue = new Args();

        // find: -executeMethod
        //   +1: JenkinsBuild.BuildMacOS
        //   +2: FindTheGnome
        //   +3: D:\Jenkins\Builds\Find the Gnome\47\output
        var args = Environment.GetCommandLineArgs();
        var execMethodArgPos = -1;
        var allArgsFound = false;
        
        for (var i = 0; i < args.Length; i++)
        {
            if (args[i] == "-executeMethod")
            {
                execMethodArgPos = i;
            }

            var realPos = execMethodArgPos == -1 ? -1 : i - execMethodArgPos - 2;
            
            if (realPos < 0) continue;

            if (realPos == 0)
                returnValue.appName = args[i];
            else if (realPos == 1)
            {
                returnValue.targetDir = args[i];
                if (!returnValue.targetDir.EndsWith(Path.DirectorySeparatorChar + ""))
                    returnValue.targetDir += Path.DirectorySeparatorChar;

                allArgsFound = true;
            }
        }

        if (!allArgsFound)
            Console.WriteLine(
                "[JenkinsBuild] Incorrect Parameters for -executeMethod Format: -executeMethod JenkinsBuild.BuildWindows64 <app name> <output dir>");

        return returnValue;
    }


    // ------------------------------------------------------------------------
    // ------------------------------------------------------------------------
    private static string[] _FindEnabledEditorScenes()
    {
        var editorScenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            if (scene.enabled)
                editorScenes.Add(scene.path);

        return editorScenes.ToArray();
    }

    // ------------------------------------------------------------------------
    // e.g. BuildTargetGroup.Standalone, BuildTarget.StandaloneOSX
    // ------------------------------------------------------------------------
    private static void _BuildProject(string[] scenes, string targetDir, BuildTargetGroup buildTargetGroup,
        BuildTarget buildTarget, BuildOptions buildOptions)
    {
        Console.WriteLine("[JenkinsBuild] Building:" + targetDir + " buildTargetGroup:" + buildTargetGroup.ToString() +
                          " buildTarget:" + buildTarget.ToString());

        // https://docs.unity3d.com/ScriptReference/EditorUserBuildSettings.SwitchActiveBuildTarget.html
        bool switchResult = EditorUserBuildSettings.SwitchActiveBuildTarget(buildTargetGroup, buildTarget);
        if (switchResult)
        {
            Console.WriteLine("[JenkinsBuild] Successfully changed Build Target to: " + buildTarget.ToString());
        }
        else
        {
            Console.WriteLine("[JenkinsBuild] Unable to change Build Target to: " + buildTarget.ToString() +
                              " Exiting...");
            return;
        }

        // https://docs.unity3d.com/ScriptReference/BuildPipeline.BuildPlayer.html
        BuildReport buildReport = BuildPipeline.BuildPlayer(scenes, targetDir, buildTarget, buildOptions);
        BuildSummary buildSummary = buildReport.summary;
        if (buildSummary.result == BuildResult.Succeeded)
        {
            Console.WriteLine("[JenkinsBuild] Build Success: Time:" + buildSummary.totalTime + " Size:" +
                              buildSummary.totalSize + " bytes");
        }
        else
        {
            Console.WriteLine("[JenkinsBuild] Build Failed: Time:" + buildSummary.totalTime + " Total Errors:" +
                              buildSummary.totalErrors);
        }
    }

    private class Args
    {
        public string appName = "AppName";
        public string targetDir = "~/Desktop";
    }
}
#endif