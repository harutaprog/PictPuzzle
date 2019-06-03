using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageFlags : SingletonMonoBehaviour<StageFlags>
{
    [SerializeField]
    private bool[] Flags = new bool[15]
    {   true, false, false, false, false,
        false, false, false, false, false,
        false, false, false, false, false };

    private AsyncOperation async;
    private GameObject loadUI;

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        loadUI = GameObject.FindGameObjectWithTag("LoadUI");
        loadUI.GetComponent<Canvas>().enabled = false;
        Debug.Log(loadUI);
        Debug.Log("awake");
        FileLoad();
    }

    public void FileLoad()
    {
        if (File.Exists("Assets\\FlagDatas.json"))
        {
            string loadjson = File.ReadAllText("Assets\\FlagDatas.json");
            JsonUtility.FromJsonOverwrite(loadjson, instance);
            Debug.Log("File Load");
        }
        else Debug.Log("No File");
    }

    public void FileSave()
    {
        string savejson = JsonUtility.ToJson(instance);
        Debug.Log(savejson);
        File.WriteAllText("Assets\\FlagDatas.json", savejson);
        Debug.Log("File Save");

    }

    public void FlagTrue(int i)
    {
        if(instance.Flags[i]!=true) instance.Flags[i] = true;
    }

    IEnumerator Load(string sceneName)
    {
        Debug.Log("ColPlay");
        async = SceneManager.LoadSceneAsync(sceneName);
        loadUI.GetComponent<Canvas>().enabled = true;
        while (!async.isDone)
        {
            //            var proressVal = Mathf.Clamp01(async.progress / 0.9f);
            //            slider.value = proressVal;
            Debug.Log("loading");
            yield return null;
        }
        //      loadUI.GetComponent<Image>().enabled = false;
        Debug.Log("active");
        loadUI.GetComponent<Canvas>().enabled = false;
    }

}
