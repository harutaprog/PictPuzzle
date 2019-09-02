using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageControlButton : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;

    //移動したいシーンの名前(特に指定しなかった場合"void"シーンに移る)
    [SerializeField]
    private string sceneName = "void";


    //SceneNameで指定したシーンに移動するスクリプト(大文字小文字も区別。間違えているとエラー)
    public void SceneLoad()
    {
        StageFlags.instance.AudioPlay(audioClip);
        StageFlags.instance.StartCoroutine("Load", sceneName);
    }

    //ゲームを終了させるスクリプト
    public void GameExit()
    {
        StageFlags.instance.AudioPlay(audioClip);
        //        UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }

    //ステージセレクト画面に移動するスクリプト(名前を指定しなくても移動する)
    public void SelectBack()
    {
        StageFlags.instance.AudioPlay(audioClip);
        StageFlags.instance.StartCoroutine("Load", "StageSelect");
    }

    //ステージセレクト画面に移動するスクリプト(名前を指定しなくても移動する)
    public void TitleBack()
    {
        StageFlags.instance.AudioPlay(audioClip);
        StageFlags.instance.StartCoroutine("Load", "Title");
    }

    //同じシーンを再読み込みさせるスクリプト
    public void Reroad()
    {
        StageFlags.instance.AudioPlay(audioClip);
        Scene loadScene = SceneManager.GetActiveScene();
        StageFlags.instance.StartCoroutine("Load", loadScene.name);
    }
}