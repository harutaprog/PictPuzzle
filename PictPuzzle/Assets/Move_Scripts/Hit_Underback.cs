using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Underback : MonoBehaviour
{

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag != "Cursor")player.Under_Left = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Cursor") player.Under_Left = false;
    }
}
