using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pouse : MonoBehaviour
{
    [SerializeField]
    private GameObject backImage;
    [SerializeField]
    private GameObject PauseButtons;
    [SerializeField]
    private GameObject ClearButtons;
    [SerializeField]
    private Text text;
    [SerializeField]
    private CursorController cursorController;
    [SerializeField]
    private Move_Player player;
    [SerializeField]
    private int StageID;

    // Start is called before the first frame update
    void Awake()
    {
        backImage.SetActive(false);
        PauseButtons.SetActive(false);
        ClearButtons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームが始まっていて、プレイヤーが死んでいないなら実行
        if (cursorController.StartCheckGet() == true && player.Death == false)
        {
            //キャンセルボタンが押され、タイムスケールが0でない(止まっていない)ならポーズ画面を開く
            if (Input.GetButtonDown("Cancel") && Time.timeScale != 0)
            {
                Time.timeScale = 0;
                cursorController.CursorFalse();
                backImage.SetActive(true);
                PauseButtons.SetActive(true);
                text.text = ("ポーズ中");
            }

            //キャンセルボタンが押され、タイムスケールが0(止まっている)ならポーズ画面を閉じる
            else if (Input.GetButtonDown("Cancel") && Time.timeScale == 0)
            {
                Time.timeScale = 1;
                cursorController.CursorTrue();
                backImage.SetActive(false);
                PauseButtons.SetActive(false);
            }
        }

        //プレイヤーが死んだならゲームオーバー画面を開く
        if (player.Death == true)
        {
            if (Time.timeScale != 0) Time.timeScale = 0;
            cursorController.CursorFalse();
            backImage.SetActive(true);
            PauseButtons.SetActive(true);
            text.text = ("ゲームオーバー");
        }

        //クリア条件を満たしたならクリア画面を開く
        if (player.Clear == true)
        {
            if (Time.timeScale != 0) Time.timeScale = 0;
            cursorController.CursorFalse();
            StageFlags.instance.FlagTrue(StageID);
            StageFlags.instance.FileSave();
            backImage.SetActive(true);
            ClearButtons.SetActive(true);
            text.text = ("ステージクリア");
        }
    }
}