using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pouse : MonoBehaviour
{
    [SerializeField]
    GameObject backImage;
    [SerializeField]
    GameObject PauseButtons;
    [SerializeField]
    GameObject ClearButtons;
    [SerializeField]
    Text text;
    [SerializeField]
    CursorController cursorController;
    [SerializeField]
    Move_Player player;
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
        if (cursorController.startCheck == true && player.Death == false)
        {
            if (Input.GetButtonDown("Cancel") && Time.timeScale != 0)
            {
                Time.timeScale = 0;
                cursorController.CursorFalse();
                backImage.SetActive(true);
                PauseButtons.SetActive(true);
                text.text = ("ポーズ中");
            }

            else if (Input.GetButtonDown("Cancel") && Time.timeScale == 0)
            {
                Time.timeScale = 1;
                cursorController.CursorTrue();
                backImage.SetActive(false);
                PauseButtons.SetActive(false);
            }
        }
        if (player.Death == true)
        {
            if (Time.timeScale != 0) Time.timeScale = 0;
            cursorController.CursorFalse();
            backImage.SetActive(true);
            PauseButtons.SetActive(true);
            text.text = ("ゲームオーバー");
        }

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
