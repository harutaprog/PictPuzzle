using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_RightTop : HitCheck
{
    public override void FlagTrue()
    {
        PlayerScript.RightHitFlag_Top = true;
    }

    public override void FlagFalse()
    {
        PlayerScript.RightHitFlag_Top = false;
    }
}
