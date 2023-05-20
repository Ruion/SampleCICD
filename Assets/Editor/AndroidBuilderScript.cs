using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AndroidBuilderScript
{
    public static void PerformBuild()
    {
        //EditSetting();
        EditorPrefs.SetBool("JdkUseEmbedded", true);
        EditorPrefs.SetBool("NdkUseEmbedded", true);
        EditorPrefs.SetBool("SdkUseEmbedded", true);
        EditorPrefs.SetBool("GradleUseEmbedded", true);
        EditorPrefs.SetBool("AndroidGradleStopDaemonsOnExit", true);

        BuildPipeline.BuildPlayer(FindEnabledEditorScenes(), $"Builds/{PlayerSettings.productName}.apk", BuildTarget.Android, BuildOptions.None);
    }

    private static string[] FindEnabledEditorScenes()
    {
        List<string> EditorScenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in
        EditorBuildSettings.scenes)
        {
            if (!scene.enabled)
                continue;
            EditorScenes.Add(scene.path);
        }
        return EditorScenes.ToArray();
    }

    static void EditSetting()
    {
        //if (GeneralSettings.AutoGameAndVersionCode)
        //{
        //    //set the other settings from environment variables
        //    PlayerSettings.bundleVersion = GeneralSettings.Instance.gameVersion;
        //    PlayerSettings.Android.bundleVersionCode = GeneralSettings.Instance.BundleVersionCode;
        //}

        //if (GeneralSettings.UseKeystoreSettings)
        //{

        //    PlayerSettings.Android.keystoreName = GeneralSettings.KeystoreName;
        //    PlayerSettings.Android.keystorePass = GeneralSettings.KeystorePass;
        //    PlayerSettings.Android.keyaliasName = GeneralSettings.KeyaliasName;
        //    PlayerSettings.Android.keyaliasPass = GeneralSettings.KeyaliasPass;
        //}

        //PlayerSettings.iOS.buildNumber = GeneralSettings.Instance.BundleVersionCode.ToString();

        //if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)
        //{
        //    // read file
        //    // replace
        //    // write file
        //    var file = System.IO.File.ReadAllText("Assets/Plugins/Android/AndroidManifest.xml");
        //    var edited = file.Replace("android:debuggable=\"true\"", "android:debuggable=\"false\"");
        //    System.IO.File.WriteAllText("Assets/Plugins/Android/AndroidManifest.xml", edited);
        //}

        //EditorUserBuildSettings.buildAppBundle = true;
    }
}
