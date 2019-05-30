using UnityEngine;
using System.Collections;

public class Click_RayCast : MonoBehaviour
{
    public string PlayerTag = "Player";

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            /*
            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
            if (Physics2D.Raycast(ray.origin, ray.direction, out hit ,Mathf.Infinity))
            {
                Debug.Log("Hit");
                Debug.Log(hit.collider.gameObject);
                if (hit.collider.gameObject.tag == PlayerTag)
                {
                    hit.collider.gameObject.GetComponent<Move_Player>().Reverse();
                }
            }
            */
        }
    }

}