using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CursorController : MonoBehaviour
{
    //設置できるブロックの上限
    public int BlockLimit = 0;

    private bool cursorCheck;
    public bool startCheck = false;
    public bool effectCheck = false;

    //カメラ内のカーソルが動くX, Y座標の範囲(ブロック何個分か)
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;
    }
    [SerializeField] Bounds bounds;

    //カメラが動くX,Y座標の範囲(ブロック何個分か)
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
    public GameObject cursor;
    [SerializeField]
    private GameObject quad;
    [SerializeField]
    private Move_Player player;

    //色を変更する用
    private SpriteRenderer sprite;

    [SerializeField]
    private Color cursorColor1,cursorColor2;

    //マップで使用するタイルマップ一式
    [SerializeField]
    private List<Tilemap> tilemaps = new List<Tilemap>();

    //各種座標
    Vector3 mousepos;
    Vector3 cameraPosition;
    Vector3Int cursorpos;

    //カーソルが指す座標のオブジェクトを計測する用
    bool mapcount;

    [SerializeField]
    private float moveSpeed = 1;

    [SerializeField]
    private LayerMask layerMask;

    // Start is called before the first frame update
    void Awake()
    {
        sprite = cursor.GetComponent<SpriteRenderer>();
        Time.timeScale = 0;
        CursorFalse();
        cursor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        cameraPosition.x = Mathf.Clamp(maincamera.transform.position.x + Input.GetAxisRaw("Horizontal") * moveSpeed, mapSize.MapMinX, mapSize.MapMaxX);
        cameraPosition.y = Mathf.Clamp(maincamera.transform.position.y + Input.GetAxisRaw("Vertical") * moveSpeed, mapSize.MapMinY, mapSize.MapMaxY);

        maincamera.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -10);

        //カーソル表示が許可されているなら実行
        if (cursorCheck == true)
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

            //カウントの初期化
            mapcount = false;
            effectCheck = false;

            //カーソルの位置にマップを構成するものがあればカウント
            if (Physics2D.OverlapBox(new Vector2(cursorpos.x, cursorpos.y), new Vector2(0.8f, 0.8f), 0, LayerMask.GetMask("Stage")) != null)
            {
                mapcount = true;
            }

            if (Physics2D.OverlapBox(new Vector2(cursorpos.x, cursorpos.y), new Vector2(0.8f, 0.8f), 0, LayerMask.GetMask("Effect")) != null)
            {
                mapcount = true;
                effectCheck = true;
            }

            /*            for (int i = 0; i < tilemaps.Count; i++)
                        {
                            //カーソルの位置にタイルマップがあればカウント
                            if (tilemaps[i].HasTile(new Vector3Int(cursorpos.x - 1, cursorpos.y - 1, 0)) == true)
                            {
                                mapcount = true;
                            }
                        }
                        */

            //trueなら紅く、falseなら蒼くする
            if (mapcount == true) sprite.color = cursorColor1;
            else sprite.color = cursorColor2;

            if (effectCheck == true) cursor.SetActive(false);
            else cursor.SetActive(true);

            //マウスがクリックされ、かつカーソルの位置に他のアイテムがなく、マウスがゲーム画面内にあるなら足場を生成する
            if (Input.GetMouseButtonDown(0) && mapcount == false && BlockLimit > 0)
            {
                Instantiate(quad, cursorpos, Quaternion.identity);
                BlockLimit--;
            }
            else if (Input.GetMouseButtonDown(0) && effectCheck == true) Debug.Log("effect");
        }
    }

    //カーソルを表示するスクリプト(メニュー画面などから復帰した時用)
    public void CursorTrue()
    {
        cursorCheck = true;
        if (cursor.activeSelf == false) cursor.SetActive(true);
    }

    //カーソルを消すスクリプト(メニュー画面などに入る時用)
    public void CursorFalse()
    {
        cursorCheck = false;
if (cursor.activeSelf == true) cursor.SetActive(false);
    }
}