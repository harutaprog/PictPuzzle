using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using UnityEngine.Audio;

public class StageFlags : SingletonMonoBehaviour<StageFlags>
{
    [SerializeField]
    private int Stage;  //ステージ数を決める変数

    [SerializeField]
    private bool[] flags;
    [SerializeField]
    [Range(-80,20)]
    private int BGM_Volume = 0, SE_Volume = 0;
    [SerializeField]
    private AudioMixer audioMixer;

    private AudioSource SE;

    private AsyncOperation async;
    private Canvas canvas;

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        //配列の初期化
        flags = new bool[Stage];
        FileLoad();
    }

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        canvas = GameObject.FindGameObjectWithTag("LoadUI").GetComponent<Canvas>();
        canvas.GetComponent<Canvas>().enabled = false;
        SE = gameObject.GetComponent<AudioSource>();
        audioMixer.SetFloat("BGM_Volume", BGM_VolumeGet());
        audioMixer.SetFloat("SE_Volume", SE_VolumeGet());
    }

    //jsonからデータを読み込む関数
    public void FileLoad()
    {
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

    //データをjsonに保存する関数
    public void FileSave()
    {
        string savejson = JsonUtility.ToJson(instance);
        File.WriteAllText(Application.persistentDataPath + "\\FlagDatas.json", savejson);
        Debug.Log("File Save");
    }

    //フラグを返す関数
    public bool FlagRetrun(int i)
    {
        return instance.flags[i - 1];
    }

    //フラグをtrueにする関数
    public void FlagTrue(int i)
    {
        if (instance.flags[i - 1] != true)
        {
            instance.flags[i - 1] = true;
        }
    }

    //フラグをfalseにする関数
    public void FlagFalse(int i)
    {
        if (instance.flags[i - 1] != false)
        {
            instance.flags[i - 1] = false;
        }
    }

    //BGM_Volumeを変更する関数
    public void BGM_VolumeSet(int i)
    {
        instance.BGM_Volume = i;
    }

    //SE_Volumeを変更する関数
    public void SE_VolumeSet(int i)
    {
        instance.SE_Volume = i;
    }

    //BGM_Volumeを取得する関数
    public int BGM_VolumeGet()
    {
        return instance.BGM_Volume;
    }

    //SE_Volumeを取得する関数
    public int SE_VolumeGet()
    {
        return instance.SE_Volume;
    }

    //シーンをロードする関数
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

    //効果音を再生する関数
    public void SEPlay(AudioClip audioClip)
    {
        SE.PlayOneShot(audioClip);
    }
}