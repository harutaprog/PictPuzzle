using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_UnderRight : MonoBehaviour
{
    //下部分の判定
    public Move_Remake player;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponent<Move_Remake>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Cursor")
        {
            player.RightHitFlag_Under = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Cursor")
        {
            player.RightHitFlag_Under = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Cursor" && player.GroundHitFlag)
        {
            player.Jump_or_Reverse();
        }
    }
}