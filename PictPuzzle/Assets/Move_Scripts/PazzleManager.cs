using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PazzleManager : MonoBehaviour //メインゲーム中のマネージャー
{
    [SerializeField] Move_Player player;
    //[SerializeField] GameObject Button;
    [SerializeField] GameObject Goal;
    public string LoadScene;
    [SerializeField] StageFlags stage;
    [SerializeField] int StageNumber;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Move_Player>();
        Goal = GameObject.Find("Goal");
        stage = GameObject.Find("ControlObject").GetComponent<StageFlags>();
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
        stage.FlagTrue(StageNumber);
    }
}
