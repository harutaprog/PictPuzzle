using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class StageFlags : SingletonMonoBehaviour<StageFlags>
{
    [SerializeField]
    private bool[] Flags = new bool[15]
    {   true , false, false, false, false,
        false, false, false, false, false,
        false, false, false, false, false };

    private AsyncOperation async;
    private Canvas canvas;

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

    DontDestroyOnLoad(gameObject);
        canvas = GameObject.FindGameObjectWithTag("LoadUI").GetComponent<Canvas>();
        canvas.GetComponent<Canvas>().enabled = false;
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
        //Debug.Log(savejson);
        File.WriteAllText("Assets\\FlagDatas.json", savejson);
        Debug.Log("File Save");
    }

    public void FlagTrue(int i)
    {
        if (instance.Flags[i - 1] != true)
        {
            instance.Flags[i - 1] = true;
        }
    }

    IEnumerator Load(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        canvas.GetComponent<Canvas>().enabled = true;
        while (!async.isDone)
        {
            yield return null;
        }
        canvas.GetComponent<Canvas>().enabled = false;
    }
}