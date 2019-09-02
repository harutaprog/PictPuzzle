using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : Effect
{
    float TimeCount;
    public override void effect()
    {
        TimeCount = Time.timeScale;
        if(TimeCount == 1.0f)
        {
            Time.timeScale = 2.0f;
        }

        if(TimeCount == 2.0f)
        {
            Time.timeScale = 1.0f;
        }
    }
}
