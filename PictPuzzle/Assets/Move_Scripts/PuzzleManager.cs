using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PuzzleManager : MonoBehaviour //メインゲーム中のマネージャー
{
    [SerializeField] GameObject player,playerPrefab,GameOverPrefab; //ゲーム開始のプレイヤー制御のため
    //[SerializeField] GameObject Button;
    [SerializeField] GameObject Goal,GoalPrefab;   //ゲームクリアの処理のため
    public string LoadScene;            //タイトルに飛ぶ(たぶん)のため
    [SerializeField] int StageNumber;   //クリアステージ(何番目)のフラグ
    Transform StartPos, GoalPos;
    // Start is called before the first frame update
    void Awake()
    {
        StartPos = GameObject.Find("StartPos").transform;
        GoalPos = GameObject.Find("GoalPos").transform;
        //stage = GameObject.Find("ControlObject").GetComponent<StageFlags>();
        playerPrefab = Instantiate(player, StartPos);
       //playerPrefab.GetComponent<Move_Player>().Instance();

        GoalPrefab = Instantiate(Goal, GoalPos);
        //GoalPrefab.GetComponent<Goal>().Instance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        Debug.Log("ゲームスタート");
        playerPrefab.GetComponent<Move_Player>().GameStart();
    }

    public void StageClear()
    {
        playerPrefab.GetComponent<Move_Player>().GameClear();
    }

    public void Miss()
    {
        Instantiate(GameOverPrefab, playerPrefab.transform).transform.parent = null;
    }
}
