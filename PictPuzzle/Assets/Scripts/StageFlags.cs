using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class StageFlags : SingletonMonoBehaviour<StageFlags>
{
    [SerializeField]
    private bool[] flags = new bool[15]
    {   true , false, false, false, false,
        false, false, false, false, false,
        false, false, false, false, false };
    [SerializeField]
    [Range(-80,20)]
    private int BGM_Volume = 0, SE_Volume = 0;

    private AsyncOperation async;
    private Canvas canvas;
    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
        FileLoad();
    }

    public void FileLoad()
    {
        //Debug.Log(Application.persistentDataPath);
        if (File.Exists(Application.persistentDataPath + "\\FlagDatas.json"))
        {
            string loadjson = File.ReadAllText(Application.persistentDataPath + "\\FlagDatas.json");
            JsonUtility.FromJsonOverwrite(loadjson, instance);
            Debug.Log("File Load");
        }
        else
        {
            instance.FileSave();
            Debug.Log("No File");
        }
    }

    public void FileSave()
    {
        string savejson = JsonUtility.ToJson(instance);
        File.WriteAllText(Application.persistentDataPath + "\\FlagDatas.json", savejson);
        Debug.Log("File Save");
    }

    public void FlagTrue(int i)
    {
        if (instance.flags[i - 1] != true)
        {
            instance.flags[i - 1] = true;
        }
    }

    public void FlagFalse(int i)
    {
        if (instance.flags[i - 1] != false)
        {
            instance.flags[i - 1] = false;
        }
    }

    public void BGM_VolumeSet(int i)
    {
        instance.BGM_Volume = i;
    }

    public void SE_VolumeSet(int i)
    {
        instance.SE_Volume = i;
    }

    public int BGM_VolumeGet()
    {
        return instance.BGM_Volume;
    }

    public int SE_VolumeGet()
    {
        return instance.SE_Volume;
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

    public void AudioPlay(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}