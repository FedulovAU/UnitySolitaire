using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class AssetBunleLoader : MonoBehaviour {
    

    void Start()
    {
        StartCoroutine("loadBundles");
    }


    IEnumerator loadBundles()
    {
        string urlBase = "file://" + UnityEngine.Application.dataPath + Path.DirectorySeparatorChar + "AssetBundles"
            + Path.DirectorySeparatorChar;

        string url = urlBase + "permanent-assets";

        
        
        using (WWW www = new WWW(url))
        {
            yield return www;
            if (www.error != null)
            {
                throw new Exception("WWW download had an error:" + www.error);
            }

            AssetBundle assetBundleAtlas = www.assetBundle;
            assetBundleAtlas.LoadAllAssets();
        }

        
        url = urlBase + "bluebutton";

        using (WWW www = new WWW(url))
        {
            yield return www;
            if (www.error != null)
            {
                throw new Exception("WWW download had an error:" + www.error);
            }

            AssetBundle assetBundleButton = www.assetBundle;
            GameObject button = assetBundleButton.LoadAsset("BlueButton") as GameObject;

            GameObject.Instantiate(button);

            assetBundleButton.Unload(false);
        }
        


    }
}
