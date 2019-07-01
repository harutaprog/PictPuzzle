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
    Text text;
    [SerializeField]
    CursorController cursorController;
    [SerializeField]
    Move_Player player;

    // Start is called before the first frame update
    void Awake()
    {
        backImage.SetActive(false);
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
                text.text = ("ポーズ中");
            }

            else if (Input.GetButtonDown("Cancel") && Time.timeScale == 0)
            {
                Time.timeScale = 1;
                cursorController.CursorTrue();
                backImage.SetActive(false);

            }
        }
        if(player.Death == true)
        {
            if(Time.timeScale != 0)Time.timeScale = 0;
            cursorController.CursorFalse();
            backImage.SetActive(true);
            text.text = ("ゲームオーバー");
        }
    }
}
