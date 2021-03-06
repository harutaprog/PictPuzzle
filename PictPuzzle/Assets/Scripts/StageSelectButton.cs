﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField]
    private int stageID;
    [SerializeField]
    private GameObject lockImage;
    [SerializeField]
    private GameObject clearImage;
    [SerializeField]
    private bool lockFlag = true;
    [SerializeField]
    private AudioClip audioClip;


    void Start()
    {
        if (stageID == 1)
        {
            lockImage.SetActive(false);
            lockFlag = false;
        }
        else
        {
            if (StageFlags.instance.FlagRetrun(stageID - 1) == false)
            {
                lockImage.SetActive(true);
                lockFlag = true;
            }
            else
            {
                lockImage.SetActive(false);
                lockFlag = false;
            }
        }
        if (StageFlags.instance.FlagRetrun(stageID) == true && lockFlag == false)
        {
            clearImage.SetActive(true);
        }
        else clearImage.SetActive(false);
    }

    public void StageLoad()
    {
        if (lockFlag == false)
        {
            StageFlags.instance.SEPlay(audioClip);
            StageFlags.instance.StartCoroutine("Load", "Stage" + stageID);
        }
    }
}
