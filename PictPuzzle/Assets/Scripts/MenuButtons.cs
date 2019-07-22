using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> StageSelectButtons;
    private int ListNum;


    public void Scroll_Left()
    {
        if (ListNum < StageSelectButtons.Count)
        {
            ListNum++;
            for (int i = 0; i < StageSelectButtons.Count; i++)
            {
                if (i == ListNum) StageSelectButtons[i].SetActive(true);
                else StageSelectButtons[i].SetActive(false);
            }
        }
    }

    public void Scroll_Riget()
    {
        if (ListNum < StageSelectButtons.Count)
        {
            ListNum--;
            for (int i = 0; i < StageSelectButtons.Count; i++)
            {
                if (i == ListNum) StageSelectButtons[i].SetActive(true);
                else StageSelectButtons[i].SetActive(false);
            }
        }
    }
}