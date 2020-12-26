using UnityEngine;
using UnityEditor;

public class BuildAssetBundles
{
    [MenuItem("Build/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string outputFolder = "Assets/__Bundles";

        //Check if __Bundles folder exist
        if (!AssetDatabase.IsValidFolder(outputFolder))
        {
            Debug.Log("Folder '__Bundles' does not exist, creating new folder");

            AssetDatabase.CreateFolder("Assets", "__Bundles");
        }

        BuildPipeline.BuildAssetBundles(outputFolder, BuildAssetBundleOptions.ChunkBasedCompression, EditorUserBuildSettings.activeBuildTarget);
    }
}