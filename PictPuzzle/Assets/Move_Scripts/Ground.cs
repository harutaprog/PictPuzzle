﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    public Move_Remake player;
    private void Start()
    {
        player = transform.parent.GetComponent<Move_Remake>();
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Cursor")
        {
            player.GroundHitFlag = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Cursor")
        {
            player.GroundHitFlag = true;
            player.Jump_or_Reverse_Check();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Cursor")
        {
            player.GroundHitFlag = false;
        }
    }
}
