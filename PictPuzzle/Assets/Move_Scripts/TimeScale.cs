using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : Effect
{
    public GameObject Image1,Image2;
    float TimeCount;

    private void Awake()
    {
        Image1.SetActive(true);
        Image2.SetActive(false);
    }

    public override void effect()
    {
        TimeCount = Time.timeScale;
        if(TimeCount == 1.0f)
        {
            Image1.SetActive(false);
            Image2.SetActive(true);
            Time.timeScale = 2.0f;
        }

        if(TimeCount == 2.0f)
        {
            Image1.SetActive(true);
            Image2.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
