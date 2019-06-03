using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageJumpButton : MonoBehaviour
{
    [SerializeField]
    private string Scenename = "void";
    [SerializeField]
    private int stageId;
    [SerializeField]
    private bool stageSelectButton = false;
    public void nextScene()
    {
        StageFlags.instance.StartCoroutine("Load", Scenename);
        if(stageSelectButton == true) StageFlags.Instance.FlagTrue(stageId - 1);
    }

}
