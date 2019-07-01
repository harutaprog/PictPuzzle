using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Jump : MonoBehaviour
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

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Cursor")
            player.FalseJump();
            player.Top_Left = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        player.Top_Left = false;
    }
}
