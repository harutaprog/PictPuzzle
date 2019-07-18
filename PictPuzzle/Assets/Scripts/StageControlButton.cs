using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageControlButton : MonoBehaviour
{
    //移動したいシーンの名前(何もない場合voidシーンへ送る)
    [SerializeField]
    private string SceneName = "void";

    public void StageLoad()
    {
        StageFlags.instance.StartCoroutine("Load", SceneName);
    }

    public void GameExit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }

    public void SelectBack()
    {
        StageFlags.instance.StartCoroutine("Load", "StageSelect");
    }

    public void Reroad()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        StageFlags.instance.StartCoroutine("Load", loadScene.name);
    }
}
