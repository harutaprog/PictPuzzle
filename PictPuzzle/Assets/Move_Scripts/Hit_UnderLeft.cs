using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_UnderLeft : MonoBehaviour
{

    public Move_Remake player;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponent<Move_Remake>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Cursor")
        {
            player.LeftHitFlag_Under = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Cursor")
        {
            player.LeftHitFlag_Under = false;
        }
    }
}
