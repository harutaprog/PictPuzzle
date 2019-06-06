using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter_Hight : MonoBehaviour
{
    public Move_Player player;
    public bool Jump_OK = false;
    public float Jump_limit;
    private void Start()
    {
        player = GetComponent<Move_Player>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        foreach (ContactPoint2D contact in collision.contacts)
        {
            float radx = this.transform.position.x - contact.point.x;
            float rady = this.transform.position.y - contact.point.y;
            float rad = Mathf.Atan2(radx, rady) * Mathf.Rad2Deg;
            if (rad > 40 && rad < 120)
            {
                Jump_OK = true;
            }
             if (rad < -40 && rad > -120)
            {
                Jump_OK = true;
            }
        }

        
        GameObject enter = collision.gameObject;
        float Other = enter.transform.position.y + enter.transform.localScale.y / 2;
        //Debug.Log(Other);
        float Player_Hight = this.transform.position.y + this.transform.localScale.y / 2;
        //Debug.Log(Player_Hight);
        float Serch = Player_Hight - Other;
        Debug.Log(Serch + enter.name);
        if (Serch >= Jump_limit  && Jump_OK)
        {
            Debug.Log("jump");
            player.Jump(Serch);
            Jump_OK = false;
        }
        if (Serch < Jump_limit)
        {
            player.Reverse();
            Jump_OK = false;
        }
    }

    public struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
}
