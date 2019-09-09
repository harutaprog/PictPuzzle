using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : Effect
{
    public Move_Remake PlayerScript;

    private void Start()
    {
        PlayerScript = transform.parent.GetComponent<Move_Remake>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag != "Cursor")
        {
            FlagTrue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Cursor")
        {
            FlagFalse();
        }
    }
    public override void effect()
    {
        Debug.Log("Effect");
        PlayerScript.effect();
    }

    public virtual void FlagTrue()
    {

    }

    public virtual void FlagFalse()
    {

    }

}
