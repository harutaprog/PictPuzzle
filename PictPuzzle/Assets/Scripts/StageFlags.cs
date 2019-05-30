using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StageFlags : SingletonMonoBehaviour<StageFlags>
{
    [SerializeField]
    public bool[] Flags = new bool[15]
    {   false, false, false, false, false,
        false, false, false, false, false,
        false, false, false, false, false };

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(gameObject);
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

}
