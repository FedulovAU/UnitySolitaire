using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class AssetBunleLoader : MonoBehaviour {

    public Transform go1;
    public Transform go2;
    public Transform go3;
    public Transform go4;
    public Transform go5;

    // Update is called once per frame
    void Update () {
	
	}

    void Start()
    {
        //StartCoroutine("loadBundles");
    }


    IEnumerator loadBundles()
    {
        string url = "file://" + UnityEngine.Application.dataPath + Path.DirectorySeparatorChar + "AssetBundles"
            + Path.DirectorySeparatorChar + "cards_and_commons";
        Debug.Log(url);

        using (WWW www = new WWW(url))
        {
            yield return www;
            if (www.error != null)
            {
                throw new Exception("WWW download had an error:" + www.error);
            }

            AssetBundle assetBundle = www.assetBundle;

            
            Sprite sprite1 = assetBundle.LoadAsset<Sprite>("assets/atlasses/gameScreen/5-plus-button-out.png");
            Sprite sprite2 = assetBundle.LoadAsset<Sprite>("assets/atlasses/gameScreen/aztec-shirt.png");
            Sprite sprite3 = assetBundle.LoadAsset<Sprite>("assets/atlasses/gameScreen/botticelli-shirt.png");
            Sprite sprite4 = assetBundle.LoadAsset<Sprite>("assets/atlasses/gameScreen/card-blank-background.png");
            Sprite sprite5 = assetBundle.LoadAsset<Sprite>("assets/atlasses/gameScreen/card-shade.png");

            go1.GetComponent<SpriteRenderer>().sprite = sprite1;
            go2.GetComponent<SpriteRenderer>().sprite = sprite2;
            go3.GetComponent<SpriteRenderer>().sprite = sprite3;
            go4.GetComponent<SpriteRenderer>().sprite = sprite4;
            go5.GetComponent<SpriteRenderer>().sprite = sprite5;
        }


    }
}
