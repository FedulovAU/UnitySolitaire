using UnityEngine;
using System.Collections.Generic;
using System;

public class AssetManager : MonoBehaviour {

    public static event Action AssetsReady;

    private Dictionary<string, AssetBundle> loadedAssets;

    private static AssetManager instance;
    public static AssetManager Instance{
        get { return instance; }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;

        loadedAssets = new Dictionary<string, AssetBundle>();
        AssetLoader.AssetLoaded += OnAssetLoaded;
        AssetLoader.AssetFailed += OnAssetFailed;

    }

    public void LoadScreenAssets(List<string> newScreenTokens)
    {
        List<string> tokensToLoad = new List<string>();
        List<string> tokensToUnload = new List<string>();

        foreach(string token in newScreenTokens)
        {
            if (!loadedAssets.ContainsKey(token))
            {
                tokensToLoad.Add(token);
            }
        }

        foreach (string token in loadedAssets.Keys)
        {
            if (!newScreenTokens.Contains(token))
            {
                tokensToUnload.Add(token);
            }
        }

        UnloadAssets(tokensToLoad);
        AssetPromise promise = new AssetPromise(tokensToLoad, AssetsLoadedSuccess, AssetsLoadedFail);
        AssetLoader.Instance.LoadAssets(tokensToLoad);
    }

    public AssetBundle GetAssetBundle(string token)
    {
        return loadedAssets[token];
    }

    public void UnloadAssets(List<string> tokensToUnload)
    {
        foreach (string token in tokensToUnload)
        {
            if (loadedAssets.ContainsKey(token))
            {
                AssetBundle assetBundle = loadedAssets[token];
                if(assetBundle != null)
                {
                    assetBundle.Unload(true);
                    loadedAssets.Remove(token);
                }
            }
        }
    }

    private void OnAssetLoaded(string token, AssetBundle assetBundle)
    {
        loadedAssets.Add(token, assetBundle);
    }

    private void OnAssetFailed(string token)
    {
        loadedAssets.Add(token, null);
    }


    private void AssetsLoadedSuccess()
    {
        if (AssetsReady != null)
        {
            AssetsReady();
        }
    }

    private void AssetsLoadedFail()
    {
        if (AssetsReady != null)
        {
            AssetsReady();
        }
    }


}
