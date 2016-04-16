using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using System.IO;

public class AssetLoader : MonoBehaviour {

    public static event Action<string, AssetBundle> AssetLoaded;
    public static event Action<string> AssetFailed;

    private const int RETRIES = 3;
    private const string ASSETS_FOLDER = "AssetBundles";
    private const string URL_PREFIX = "file://";

    private static AssetLoader instance;
    public static AssetLoader Instance
    {
        get { return instance; }
    }
    
    private Dictionary<string, int> loadingAssets;

    void Awake () {
        DontDestroyOnLoad(this);
        instance = this;
        loadingAssets = new Dictionary<string, int>();
    }

    public bool IsLoading(string token)
    {
        return loadingAssets.ContainsKey(token);
    }

    public void LoadAssets(List<string> tokens)
    {
        foreach (string token in tokens)
        {
            if (!IsLoading(token))
            {
                string url = Path.Combine(Application.dataPath, ASSETS_FOLDER);
                url = Path.Combine(url, token);
                Debug.Log(url);

                loadingAssets.Add(token, 0);

                StartCoroutine(Load(url, token));
            }
        }
    }

    private void RetryLoading(string token, WWW www)
    {
        loadingAssets[token]++;
        if (loadingAssets[token] > RETRIES)
        {
            Debug.LogError("WWW download had an error: " + www.error);
            if (AssetFailed != null)
            {
                AssetFailed(token);
            }
        }
        else
        {
            Debug.LogError("retrying download: " + www.url);
            StartCoroutine(Load(www.url, token));
        }
    }


    private IEnumerator Load(string url, string token)
    {
       
        using (WWW www = new WWW(url))
        {
            Debug.Log("WWW download start " + www.url);
            yield return www;

            if (www.error != null)
            {
                RetryLoading(token, www);
            }
            else
            {
                AssetBundle assetBundle = www.assetBundle;
                if(assetBundle != null)
                {
                    loadingAssets.Remove(token);

                    Debug.Log("WWW download complete " + www.url);
                    if (AssetLoaded != null)
                    {
                        AssetLoaded(token, assetBundle);
                    }
                }
                else
                {
                    RetryLoading(token, www);
                }
            }
        }
         
    }
	
	
}
