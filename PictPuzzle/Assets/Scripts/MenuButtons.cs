using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> stageSelectButtons;
    private int listNum = 0;

    public void Start()
    {
        stageSelectButtons.Clear();
        //StageButtons下にある子オブジェクトを全て取得しリスト化
        for(int x = 0;x < transform.childCount;x++)
        {
            stageSelectButtons.Add(transform.GetChild(x).gameObject);
        }
        //stageButton下のオブジェクトを一つ表示
        Button_View();
    }


    public void Scroll_Left()
    {
        if (listNum > 0)
        {
            listNum--;
            Button_View();
        }
    }

    public void Scroll_Right()
    {
        if (listNum < stageSelectButtons.Count - 1)
        {
            listNum++;
            Button_View();
        }
    }

    public void Button_View()
    {
        for (int i = 0; i < stageSelectButtons.Count; i++)
        {
            if (i == listNum)
            {
                stageSelectButtons[i].SetActive(true);
            }else
            {
                stageSelectButtons[i].SetActive(false);
            }
        }
    }
}