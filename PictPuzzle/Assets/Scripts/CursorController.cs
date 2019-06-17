using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CursorController : MonoBehaviour
{

    // X, Y座標の移動可能範囲
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;
    }
    [SerializeField] Bounds bounds;

    [System.Serializable]
    public class MapSize
    {
        public float MapMinX, MapMaxX, MapMinY, MapMaxY;
    }
    [SerializeField] MapSize mapSize;

    [SerializeField]
    private Camera maincamera;
    [SerializeField]
    private GameObject cursor;
    [SerializeField]
    private GameObject quad;

    [SerializeField]
    private List<Tilemap> tilemaps = new List<Tilemap>();

    Vector3 mousepos;
    Vector3 cameraPosition;
    Vector3Int cursorpos;
    int mapcount;

    [SerializeField]
    private float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //マウスの座標を取得
        mousepos = Input.mousePosition;

        cursorpos = new Vector3Int(
        (int)Mathf.Clamp(Mathf.Round(Camera.main.ScreenToWorldPoint(mousepos).x),
        bounds.xMin + Mathf.Round(maincamera.transform.position.x), bounds.xMax + Mathf.Round(maincamera.transform.position.x)),

        (int)Mathf.Clamp(Mathf.Round(Camera.main.ScreenToWorldPoint(mousepos).y),
        bounds.yMin + Mathf.Round(maincamera.transform.position.y), bounds.yMax + Mathf.Round(maincamera.transform.position.y)),
        0);

        cursor.transform.position = cursorpos;

        //左に移動
        if (Camera.main.ScreenToViewportPoint(mousepos).x <= 0)
            cameraPosition.x = Mathf.Clamp(maincamera.transform.position.x - moveSpeed, mapSize.MapMinX, mapSize.MapMaxX);
        //右に移動
        else if (Camera.main.ScreenToViewportPoint(mousepos).x >= 1)
            cameraPosition.x = Mathf.Clamp(maincamera.transform.position.x + moveSpeed, mapSize.MapMinX, mapSize.MapMaxX);
        //下に移動
        if (Camera.main.ScreenToViewportPoint(mousepos).y <= 0)
            cameraPosition.y = Mathf.Clamp(maincamera.transform.position.y - moveSpeed, mapSize.MapMinY, mapSize.MapMaxY);
        //上に移動
        else if (Camera.main.ScreenToViewportPoint(mousepos).y >= 1)
            cameraPosition.y = Mathf.Clamp(maincamera.transform.position.y + moveSpeed, mapSize.MapMinY, mapSize.MapMaxY);

        maincamera.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -10);

        mapcount = 0;
        for(int i = 0;i < tilemaps.Count; i++)
        {
            if (tilemaps[mapcount].HasTile(new Vector3Int(cursorpos.x - 1,cursorpos.y - 1,0)) == true)
            {
                mapcount++;
            }
        }
        if (Input.GetMouseButtonDown(0) && mapcount == 0)
            Instantiate(quad, cursorpos, Quaternion.identity);
    }
}