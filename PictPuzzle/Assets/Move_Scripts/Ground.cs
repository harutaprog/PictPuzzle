using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Move_Player player;
    [SerializeField] ContactFilter2D filter2d;
    private void Start()
    {
        player = transform.parent.GetComponent<Move_Player>();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Cursor")
        {
            player.Ground();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        player.Not_Ground();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Cursor") player.FallEnd();
    }
}
