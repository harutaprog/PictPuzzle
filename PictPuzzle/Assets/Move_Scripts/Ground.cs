using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : HitCheck
{
    public override void FlagTrue()
    {
        PlayerScript.GroundHitFlag = true;
    }

    public override void FlagFalse()
    {
        PlayerScript.GroundHitFlag = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Cursor")
        {
            PlayerScript.GroundHitFlag = true;
            PlayerScript.Jump_or_Reverse_Check();
        }
    }
}
