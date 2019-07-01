using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageControlButton : MonoBehaviour
{
    [SerializeField]
    private string SceneName = "void";
    [SerializeField]
    private int stageId;
    [SerializeField]
    private bool stageSelectButton = false;

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
        SceneManager.LoadScene(loadScene.name);
    }
}
