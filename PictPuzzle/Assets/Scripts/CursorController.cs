﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CursorController : MonoBehaviour
{

    //カメラ内のカーソルが動くX, Y座標の範囲
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;
    }
    [SerializeField] Bounds bounds;

    //カメラが動くX,Y座標の範囲
    [System.Serializable]
    public class MapSize
    {
        public float MapMinX, MapMaxX, MapMinY, MapMaxY;
    }
    [SerializeField] MapSize mapSize;

    //各種ゲームオブジェクト
    [SerializeField]
    private Camera maincamera;
    [SerializeField]
    private GameObject cursor;
    [SerializeField]
    private GameObject quad;

    //マップで使用するタイルマップ一式
    [SerializeField]
    private List<Tilemap> tilemaps = new List<Tilemap>();

    //各種座標
    Vector3 mousepos;
    Vector3 cameraPosition;
    Vector3Int cursorpos;

    //計測用
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

        //カーソルを動かす場所を決定
        cursorpos = new Vector3Int(
        (int)Mathf.Clamp(Mathf.Round(Camera.main.ScreenToWorldPoint(mousepos).x),
        bounds.xMin + Mathf.Round(maincamera.transform.position.x), bounds.xMax + Mathf.Round(maincamera.transform.position.x)),

        (int)Mathf.Clamp(Mathf.Round(Camera.main.ScreenToWorldPoint(mousepos).y),
        bounds.yMin + Mathf.Round(maincamera.transform.position.y), bounds.yMax + Mathf.Round(maincamera.transform.position.y)),
        0);

        //カーソルを移動
        cursor.transform.position = cursorpos;

        //カメラを左に移動
        if (Camera.main.ScreenToViewportPoint(mousepos).x <= 0)
            cameraPosition.x = Mathf.Clamp(maincamera.transform.position.x - moveSpeed, mapSize.MapMinX, mapSize.MapMaxX);
        //カメラを右に移動
        else if (Camera.main.ScreenToViewportPoint(mousepos).x >= 1)
            cameraPosition.x = Mathf.Clamp(maincamera.transform.position.x + moveSpeed, mapSize.MapMinX, mapSize.MapMaxX);
        //カメラを下に移動
        if (Camera.main.ScreenToViewportPoint(mousepos).y <= 0)
            cameraPosition.y = Mathf.Clamp(maincamera.transform.position.y - moveSpeed, mapSize.MapMinY, mapSize.MapMaxY);
        //カメラを上に移動
        else if (Camera.main.ScreenToViewportPoint(mousepos).y >= 1)
            cameraPosition.y = Mathf.Clamp(maincamera.transform.position.y + moveSpeed, mapSize.MapMinY, mapSize.MapMaxY);

        maincamera.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -10);



        Ray LeftRay = new Ray(cursorpos, Vector3.left);
        Ray RightRay = new Ray(cursorpos, Vector3.right);
        Ray UpRay = new Ray(cursorpos, Vector3.up);
        Ray DownRay = new Ray(cursorpos, Vector3.down);
        RaycastHit raycastHit;

        Debug.DrawRay(cursorpos, Vector3.left * 0.5f, Color.red);
        Debug.DrawRay(cursorpos, Vector3.right * 0.5f, Color.red);
        Debug.DrawRay(cursorpos, Vector3.up * 0.5f, Color.red);
        Debug.DrawRay(cursorpos, Vector3.down * 0.5f, Color.red);

        if (Physics.Raycast(LeftRay, out raycastHit, 0.5f)) Debug.Log(raycastHit);

        //カーソルの現在位置にタイルマップがあるか取得する
        mapcount = 0;
        for(int i = 0;i < tilemaps.Count; i++)
        {
            //カーソルの位置にタイルマップがあればカウント
            if (tilemaps[mapcount].HasTile(new Vector3Int(cursorpos.x - 1,cursorpos.y - 1,0)) == true)
            {
                mapcount++;
            }
        }
        //マウスがクリックされ、かつカーソルの位置にタイルマップがなければ足場を生成する
        if (Input.GetMouseButtonDown(0) && mapcount == 0)
            Instantiate(quad, cursorpos, Quaternion.identity);
    }
}