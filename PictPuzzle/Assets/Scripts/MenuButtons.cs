using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> StageSelectButtons;
    private int ListNum = 0;

    public void Start()
    {
        Button_View();
    }


    public void Scroll_Left()
    {
        if (ListNum > 0)
        {
            Mathf.Clamp(ListNum--, 0, StageSelectButtons.Count);
            Debug.Log(ListNum);
            Button_View();
        }
    }

    public void Scroll_Right()
    {
        if (ListNum < StageSelectButtons.Count - 1)
        {
            Mathf.Clamp(ListNum++,0,StageSelectButtons.Count);
            Debug.Log(ListNum);
            Button_View();
        }
    }

    public void Button_View()
    {
        for (int i = 0; i < StageSelectButtons.Count; i++)
        {
            if (i == ListNum)
            {
                StageSelectButtons[i].SetActive(true);
            }else
            {
                StageSelectButtons[i].SetActive(false);
            }
        }
    }
}