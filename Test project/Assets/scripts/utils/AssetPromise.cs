using System;
using System.Collections.Generic;
using UnityEngine;

public class AssetPromise {
 
    private List<string> tokens;
    private int loadedAmount = 0;
    private int failedAmount = 0;

    private Action AssetsLoadedSuccess;
    private Action AssetsLoadedFail;


    public AssetPromise(List<string> tokens, Action AssetsLoadedSuccess, Action AssetsLoadedFail)
    {
        this.tokens = new List<string>(tokens);

        AssetLoader.AssetLoaded += OnAssetLoaded;
        AssetLoader.AssetFailed += OnAssetFailed;

        this.AssetsLoadedSuccess = AssetsLoadedSuccess;
        this.AssetsLoadedFail = AssetsLoadedFail;
    }

    private void OnAssetLoaded(string token, AssetBundle assetBundle)
    {
        if (tokens.Contains(token))
        {
            loadedAmount++;
        }

        CheckIfComplete();
    }

    private void OnAssetFailed(string token)
    {
        if (tokens.Contains(token))
        {
            failedAmount++;
        }
        CheckIfComplete();
    }

    private void CheckIfComplete()
    {
        if((loadedAmount + failedAmount) == tokens.Count)
        {
            if(failedAmount > 0)
            {
                AssetsLoadedSuccess();
            } else
            {
                AssetsLoadedFail();
            }

            Dispose();
        }
    }

    public void Dispose()
    {
        AssetLoader.AssetLoaded -= OnAssetLoaded;
        AssetLoader.AssetFailed -= OnAssetFailed;
    }


}
