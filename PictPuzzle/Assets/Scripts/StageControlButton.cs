using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageControlButton : MonoBehaviour
{
    //移動したいシーンの名前(特に指定しなかった場合"void"シーンに移るヨ)
    [SerializeField]
    private string SceneName = "void";


    //SceneNameで指定したシーンに移動するスクリプト(大文字小文字も区別するヨ。間違えるとエラーだから気を付けて)
    public void SceneLoad()
    {
        StageFlags.instance.StartCoroutine("Load", SceneName);
    }

    //ゲームを終了させるスクリプト
    public void GameExit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }

    //ステージセレクト画面に移動するスクリプト(名前指定はいらないヨ)
    public void SelectBack()
    {
        StageFlags.instance.StartCoroutine("Load", "StageSelect");
    }

    //同じシーンを再読み込みさせるスクリプト
    public void Reroad()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        StageFlags.instance.StartCoroutine("Load", loadScene.name);
    }

}