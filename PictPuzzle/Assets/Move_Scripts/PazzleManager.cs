using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PazzleManager : MonoBehaviour //メインゲーム中のマネージャー
{
    [SerializeField] Camera Camera;
    [SerializeField] Move_Player player;
    [SerializeField] GameObject Button;
    public string LoadScene;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        Debug.Log("ゲームスタート");
        player.GameStart();
    }

    public void StageClear()
    {
        player.GameClear();
    }
}
