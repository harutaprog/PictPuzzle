using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CursorController : MonoBehaviour
{
    //設置できるブロックの上限(特に設定しなければ10個)
    [SerializeField]
    private int blockLimit = 10;

    private bool cursorCheck;
    private bool startCheck = false;
    private bool effectCheck = false;

    //カメラが動くX,Y座標の範囲(特に設定しなければ縦15×横30個分)
    private float mapSizeX = 30, mapSizeY = 15;

    //カメラ内のカーソルが動くX, Y座標の範囲(特に設定しなければ縦10×横14個分)
    [System.Serializable]
    private class Bounds
    {
        public float xMin = -7, xMax = 7, yMin = -5, yMax = 5;
    }
    [SerializeField]
    Bounds mapBounds;

    //各種ゲームオブジェクト
    [SerializeField]
    private GameObject maincamera;
    [SerializeField]
    private GameObject cursor;
    [SerializeField]
    private Move_Remake player;
    [SerializeField]
    private Color cursorColor1, cursorColor2;
    [SerializeField]
    private float moveSpeed = 1;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private AudioClip blockPutSE,effectSE;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private GameObject button;

    private GameObject tileMapParent;

    //マップで使用するタイルマップ一式
    [SerializeField]
    private List<Tilemap> tilemaps = new List<Tilemap>();

    //色を変更する用
    private SpriteRenderer sprite;

    //各種座標
    private Vector3 mousepos;
    private Vector3 cameraPosition;
    private Vector3Int cursorpos;

    //カーソルが指す座標のオブジェクトを計測する用
    private bool mapcount;

    public TileBase tileBase;

    // Start is called before the first frame update
    void Awake()
    {
        sprite = cursor.GetComponent<SpriteRenderer>();
        Time.timeScale = 0;
        CursorBoolSet(false);
        maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        tileMapParent = GameObject.FindGameObjectWithTag("TileMapParent");
        for(int x = 0;x < tileMapParent.transform.childCount; x++)
        {
            tilemaps.Add(tileMapParent.transform.GetChild(x).gameObject.GetComponent<Tilemap>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition.x = Mathf.Clamp(maincamera.transform.position.x + Input.GetAxisRaw("Horizontal") * moveSpeed, 0, mapSizeX);
        cameraPosition.y = Mathf.Clamp(maincamera.transform.position.y + Input.GetAxisRaw("Vertical") * moveSpeed, 0, mapSizeY);

        maincamera.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -10);

        //カーソル表示が許可されているなら実行
        if (cursorCheck == true)
        {
            //マウスの座標を取得
            mousepos = Input.mousePosition;

            //カーソルを動かす場所を決定
            cursorpos = new Vector3Int(
            (int)Mathf.Clamp(Mathf.Round(Camera.main.ScreenToWorldPoint(mousepos).x),
            mapBounds.xMin + Mathf.Round(maincamera.transform.position.x), mapBounds.xMax + Mathf.Round(maincamera.transform.position.x)),

            (int)Mathf.Clamp(Mathf.Round(Camera.main.ScreenToWorldPoint(mousepos).y),
            mapBounds.yMin + Mathf.Round(maincamera.transform.position.y), mapBounds.yMax + Mathf.Round(maincamera.transform.position.y)),
            0);

            //カーソルを移動
            cursor.transform.position = cursorpos;

            //マップカウントの初期化
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

            //true(そこに何かある)なら赤く、false(そこに何もない)なら青くする
            if (mapcount == true)
            {
                sprite.color = cursorColor1;
            }
            else
            {
                sprite.color = cursorColor2;
            }

            //クリックすることで動く仕組み(effectクラスを継承したもの)があるならカーソルを消す
            if (effectCheck == true)
            {
                cursor.SetActive(false);
            }
            else
            {
                cursor.SetActive(true);
            }

            //マウスがクリックされ、かつカーソルの位置に他のオブジェクトがないなら足場を生成する
            if (Input.GetMouseButtonDown(0) && mapcount == false && blockLimit > 0)
            {
                audioSource.clip = blockPutSE;
                audioSource.Play();
                tilemaps[0].SetTile(cursorpos, tileBase);
                blockLimit--;
            }

            //マウスがクリックされ、かつカーソルの位置にeffectを継承したobjectがあるならそれを取得し、起動する
            else if (Input.GetMouseButtonDown(0) && effectCheck == true)
            {
                audioSource.clip = effectSE;
                audioSource.Play();
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, new Vector3(0, 0, 1));
                Debug.Log(hit.collider.gameObject);
                if (hit.collider.GetComponent<Effect>() != null)
                {
                    hit.collider.GetComponent<Effect>().effect();
                }
            }
        }
    }

    //カーソルの表示・非表示を設定するスクリプト(trueで表示、falseで非表示)
    public void CursorBoolSet(bool setbool)
    {
        cursorCheck = setbool;
        if (cursor.activeSelf != setbool)
        {
            cursor.SetActive(setbool);
        }
    }

    //BlockLimitを渡すスクリプト(設置可能なブロック数を表示したりする用)
    public int BlocklimitGet()
    {
        return blockLimit;
    }

    //startCheckを渡すスクリプト
    public bool StartCheckGet()
    {
        return startCheck;
    }

    //startCheckを外部から変更する際のスクリプト
    public void StartCheckSet(bool a)
    {
        startCheck = a;
    }

    public void StageStart()
    {
        CursorBoolSet(true);
        StartCheckSet(true);
        Time.timeScale = 1.0f;
        button.SetActive(false);
    }
}