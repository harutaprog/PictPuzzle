using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NumberBlock : MonoBehaviour
{
    public int Nuber;
    public Vector3 hitPos = Vector3.zero;
    Vector3Int DeletePosition;
    TileBase[] tile;
    Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach(ContactPoint2D point in collision.contacts)
            {
                hitPos = point.point;
            }
            BoundsInt.PositionEnumerator position = collision.gameObject.GetComponent<Tilemap>().cellBounds.allPositionsWithin;
            var allPosition = new List<Vector3>();
            int minPositionNum = 0;
            foreach (var variable in position)
            {
                if (collision.gameObject.GetComponent<Tilemap>().GetTile(variable) != null)
                {
                    allPosition.Add(variable);
                }
            }

            for(int i = 1;i < allPosition.Count; i++)
            {
                //それぞれのあたった場所からの大きさを取得、最小を更新したらminPositionNumを更新する
                if ((hitPos - allPosition[i]).magnitude <
                    (hitPos - allPosition[minPositionNum]).magnitude)
                {
                    minPositionNum = i;
                }

                DeletePosition = Vector3Int.RoundToInt(allPosition[minPositionNum]);

                TileBase tiletmp = collision.gameObject.GetComponent<Tilemap>().GetTile(DeletePosition);

                if (tiletmp != null)
                {
                    Tilemap map = collision.gameObject.GetComponent<Tilemap>();
                    TilemapCollider2D tileCol = collision.gameObject.GetComponent<TilemapCollider2D>();

                    map.SetTile(DeletePosition, null);
                    tileCol.enabled = false;
                    tileCol.enabled = true;
                }
            }

        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Nuber >= 0)
        {
           
        }// tilemap.SetTile(); ; //Destroy(gameObject);
    }
}
