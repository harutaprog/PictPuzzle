using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_UnderLeft : HitCheck
{
    public override void FlagTrue()
    {
        PlayerScript.LeftHitFlag_Under = true;
    }

    public override void FlagFalse()
    {
        PlayerScript.LeftHitFlag_Under = false;
    }
}
