using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_LeftTop : HitCheck
{
    public override void FlagTrue()
    {
        PlayerScript.LeftHitFlag_Top = true;
    }

    public override void FlagFalse()
    {
        PlayerScript.LeftHitFlag_Top = false;
    }
}
