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
        StageFlags.instance.FlagTrue(stageId - 1);
        StageFlags.instance.StartCoroutine("Load", SceneName);
    }

}
