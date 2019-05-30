using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FlagDatas : MonoBehaviour
{
    private static FlagDatas instance = null;
    public static FlagDatas Instance
    {
        get { return FlagDatas.instance; }
    }

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    


    public class StageFlags
    {
        public bool[] Flags = new bool[15]
        {   false, false, false, false, false,
        false, false, false, false, false,
        false, false, false, false, false };
    }
    public void FileLoad()
    {   

        if (!File.Exists("FlagDatas.json"))
        {
            string savejson = JsonUtility.ToJson();
            File.WriteAllText("Assets\\FlagDatas.json", savejson);
        }
        else
        {
            string loadjson = File.ReadAllText("Assets\\FlagDatas.json");
            JsonUtility.FromJsonOverwrite(loadjson,stageFlags.Flags);

        }
    }
}
