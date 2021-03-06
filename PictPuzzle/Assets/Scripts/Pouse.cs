﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Pouse : MonoBehaviour
{
    [SerializeField]
    private GameObject backImage;
    [SerializeField]
    private GameObject pauseButtons;
    [SerializeField]
    private GameObject clearButtons;
    [SerializeField]
    private GameObject gameOverButtons;
    [SerializeField]
    private CursorController cursorController;
    [SerializeField]
    private Move_Remake player;
    [SerializeField]
    private int StageID;
    [SerializeField]
    private AudioClip BGM;

    private bool pouseFlag = false;

    // Start is called before the first frame update
    void Awake()
    {
        backImage.SetActive(false);
        pauseButtons.SetActive(false);
        clearButtons.SetActive(false);
        gameOverButtons.SetActive(false);
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームが始まっているなら実行
        if (cursorController.StartCheckGet() == true)
        {
            //キャンセルボタンが押され、pouseFlagがfalse(ポーズ中ではない)ならポーズ画面を開く
            if (Input.GetButtonDown("Cancel") && pouseFlag == false)
            {
                pouseFlag = true;
                Time.timeScale = 0;
                cursorController.CursorBoolSet(false);
                backImage.SetActive(true);
                pauseButtons.SetActive(true);
            }

            //キャンセルボタンが押され、タイムスケールが0(止まっている)ならポーズ画面を閉じる
            else if (Input.GetButtonDown("Cancel") && pouseFlag == true)
            {
                pouseFlag = false;
                Time.timeScale = 1;
                cursorController.CursorBoolSet(true);
                backImage.SetActive(false);
                pauseButtons.SetActive(false);
            }
        }

        //プレイヤーが死んだならゲームオーバー画面を開く
        if (player.Death == true)
        {
            if (Time.timeScale != 0) Time.timeScale = 0;
            cursorController.CursorBoolSet(false);
            backImage.SetActive(true);
            gameOverButtons.SetActive(true);
        }

        //クリア条件を満たしたならクリア画面を開く
        if (player.Clear == true)
        {
            if (Time.timeScale != 0) Time.timeScale = 0;
            cursorController.CursorBoolSet(false);
            backImage.SetActive(true);
            clearButtons.SetActive(true);
            StageFlags.instance.FlagTrue(StageID);
            StageFlags.instance.FileSave();
        }
    }
}