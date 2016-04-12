using UnityEditor;
using UnityEditor.Sprites;

public class AssetBundleExporter {

    [MenuItem ("Assets/Generte AssetBundles")]
    static void generateAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles");
    }
	
}
