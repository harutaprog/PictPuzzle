using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_LeftTop : MonoBehaviour
{
    //上部分(反転)の処理
    public Move_Remake player;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponent<Move_Remake>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Cursor")
        {
            player.LeftHitFlag_Top = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Cursor")
        { 
            player.LeftHitFlag_Top = true;
        }
    }
}
