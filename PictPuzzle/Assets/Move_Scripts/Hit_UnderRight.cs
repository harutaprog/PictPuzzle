using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_UnderRight : HitCheck
{
    public override void FlagTrue()
    {
        PlayerScript.RightHitFlag_Under = true;
    }

    public override void FlagFalse()
    {
        PlayerScript.RightHitFlag_Under = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Cursor" && collision.gameObject.tag != "Goal" && collision.gameObject.tag != "Miss" && PlayerScript.GroundHitFlag)
        {
            PlayerScript.Jump_or_Reverse();
        }

        if(collision.gameObject.tag == "Goal")
        {
            PlayerScript.Clear = true;
        }

        if(collision.gameObject.tag == "Miss")
        {
            PlayerScript.MissFlag = true;
        }
    }
}