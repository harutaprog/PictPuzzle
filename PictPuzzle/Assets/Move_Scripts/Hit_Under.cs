using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Under : MonoBehaviour
{
    //下部分の判定
    public Move_Player player;
    bool Under;
    // Start is called before the first frame update
    void Start()
    {
        player =  transform.parent.GetComponent<Move_Player>();
        Under = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Cursor" && Under) 
        player.Jump();
        Under = false;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        player.HitUnder = false;
        Under = true;
    }
}