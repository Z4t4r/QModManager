using System.IO;
using UnityEditor;

public class ExportAssetBundles
{
    [MenuItem("Tools/Build AssetBundles")]
    static void ExportResource()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        File.Delete("Assets/AssetBundles/AssetBundles");
        File.Delete("Assets/AssetBundles/AssetBundles.meta");
        File.Delete("Assets/AssetBundles/AssetBundles.manifest");
        File.Delete("Assets/AssetBundles/AssetBundles.manifest.meta");
    }
}