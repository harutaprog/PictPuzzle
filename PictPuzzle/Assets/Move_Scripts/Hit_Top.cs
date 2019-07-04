using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Top : MonoBehaviour
{
    //上部分(反転)の処理
    public Move_Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponent<Move_Player>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Cursor")
        {
            player.Top_Right = false;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Cursor")
        {
            player.False();
            player.Top_Right = true;
        }
    }

}
