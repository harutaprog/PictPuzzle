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
        if (File.Exists("Resources\\FlagDatas.json"))
        {
            //            string loadjson = File.ReadAllText("Resources\\FlagDatas.json");
            var loadjson = Resources.Load<TextAsset>("FlagDatas.json").ToString();
            JsonUtility.FromJsonOverwrite(loadjson, instance);
            Debug.Log("File Load");
        }
        else Debug.Log("No File");
    }

    public void FileSave()
    {
        string savejson = JsonUtility.ToJson(instance);
        File.WriteAllText("Resources\\FlagDatas.json", savejson);
        Debug.Log("File Save");
    }

    public void FlagTrue(int i)
    {
        if (instance.flags[i - 1] != true)
        {
            instance.flags[i - 1] = true;
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

    public void AudioPlay(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}