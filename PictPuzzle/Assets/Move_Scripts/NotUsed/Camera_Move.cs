using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    public float Horizontal, Vertical;
    public Vector2 MousePosition;
    public Vector2 newScroll = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal") / 10;
        Vertical = Input.GetAxisRaw("Vertical") / 10;

        /*
        if (Input.GetMouseButtonDown(0)) //マウスの左クリックで画面移動するように
        {
            MousePosition = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            newScroll.x -= (MousePosition.x - Input.mousePosition.x);
            newScroll.y -= (MousePosition.y - Input.mousePosition.y);
            MousePosition = Input.mousePosition;

            Horizontal = Mathf.Clamp(newScroll.x,0,0.1f);
            Vertical = Mathf.Clamp(newScroll.y,0,0.1f) ;
        }
        */
        transform.position = new Vector3(transform.position.x + Horizontal, transform.position.y + Vertical, transform.position.z);
        
    }
}
