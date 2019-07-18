using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Move_Player : Effect
{
    Rigidbody2D rb;
    BoxCollider2D box;
    Vector2 vector;
    public float MoveSpeed;
    static float Speed;            //移動スピード
    public float JumpPower; //ジャンプ力
    bool JumpFlag, JumpNow, JumpFallNow, Not;//ジャンプできるか否か、ジャンプしているか(落下があり得るため)
    bool ReverseFlag, FreeFall;            //反転のフラグ
    bool IsGround;              //着地しているかの判断
    bool Start_Flag, DebugMode;
    public bool HitUnder;
    public Animator Animator;
    Vector2 force = new Vector2(1.0f, 0.0f);
    Collider2D Collider2D;
    LayerMask layer;
    public bool Death, Clear, Deleat;
    public GameObject Miss;
    Vector3Int finalPosition, BeforPosition;

    TileBase tiletmp;
    Tilemap map;
    TilemapCollider2D tileCol;

    public bool Top_Right, Top_Left, Under_Right, Under_Left, Flag;
    void Awake()
    {
        transform.parent = null;        //インスタンスした場所の子オブジェクトの解除
        rb = GetComponent<Rigidbody2D>();       //rigidbodyの取得
        box = GetComponent<BoxCollider2D>();  //BoxCollider2Dの取得
        MoveSpeed = 1.0f;
        Speed = MoveSpeed;
        Start_Flag = false;
        Not = false;
        Death = false;
        DebugMode = true;
        Clear = false;

        if (DebugMode) GameStart();                //移動の許可
    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Start_Flag) rb.velocity = new Vector2(transform.localScale.x * MoveSpeed, rb.velocity.y);
        else rb.velocity = Vector2.zero;     //動かないときはピタッと止める

        if (Under_Left && Under_Right && Top_Left && Top_Right && IsGround) Gameover();     //右上、左上、右下、左下、足元すべてが当たっている(壁に挟まれている場合)
        if (JumpNow == true && rb.velocity.y < -0.0f) JumpFallNow = true;
        if (JumpFallNow)
        {
            if (rb.velocity.y == 0) Invoke("Move_Restart", 0.5f);
        }

        if (JumpNow == false && JumpFallNow == false && IsGround == false)
        {
            FreeFall = true;
            //MoveSpeed = 0;
            JumpFlag = false;
        }
    }

    public void Jump()　//ジャンプできるなら飛び越える
    {
        //Debug.Log("jump");
        if (Flag == true)
        {
            HitUnder = true;
            if (JumpFlag && Not)
            {
                JumpFlag = false;
                ReverseFlag = false;
                JumpNow = true;
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + JumpPower);
            }
            else if (Not == false && Under_Right && Flag)
            {
                Reverse();
            }
        }
    }

    void NextJump()
    {
        JumpFlag = false;
        ReverseFlag = false;
        JumpNow = true;
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + JumpPower + 1);
    }

    public void Reverse() //ジャンプできない高さに当たった時に反転
    {
        if (ReverseFlag == true && IsGround == true)
        {
            ReverseFlag = false;
            MoveSpeed = 0.0f;
            Vector3 temp = gameObject.transform.localScale;
            temp.x *= -1;
            gameObject.transform.localScale = temp;
            Invoke("Set", 1.0f);
        }
    }

    private void Set()
    {
        MoveSpeed = Speed;
        ReverseFlag = true;
        JumpFlag = true;
        Not = true;
        Flag = true;
        if (Under_Right && true) NextJump();
    }

    private void Move_Restart()
    {
        JumpFlag = true;
        MoveSpeed = Speed;
        ReverseFlag = true;
        FreeFall = false;
        Not = true;
    }

    public void GameStart()
    {
        Animator.SetBool("Start", true);
        Start_Flag = true;
        Invoke("Move_Restart", 0.5f);
        Not = true;
        Flag = true;
    }

    public void GameClear()
    {
        Animator.SetBool("Start", false);
        MoveSpeed = 0;
        ReverseFlag = false;
    }

    public void False()
    {
        Not = false;
        JumpFlag = false;
        HitUnder = false;
    }

    public void Ground()
    {
        IsGround = true;
        JumpFlag = true;
        JumpNow = false;
        JumpFallNow = false;
        FreeFall = false;
        Not = true;
        if (Top_Right && Under_Right)
        {
            Flag = false;
            JumpFlag = false;
            Invoke("Reverse", 0.5f);
        }
    }

    public void Not_Ground()
    {
        IsGround = false;
        JumpFlag = false;
    }

    public void FallEnd()
    {
        //MoveSpeed = 0.0f;
        Invoke("Move_Restart", 0.5f);
        if (HitUnder) Invoke("NextJump", 0.5f);
    }

    public void FalseJump()
    {
        if (Not == false && IsGround && ReverseFlag && Under_Right && Under_Left)
        {
            rb.velocity = new Vector2(0, rb.velocity.y + (JumpPower + 2) / 2);
            Not = true;
        }
    }

    private void Gameover()
    {
        if (Death == false)
        {
            Death = true;
            Start_Flag = false;
            Animator.SetBool("Start", false);
            gameObject.SetActive(false);
            Instantiate(Miss, transform).transform.parent = null;
        }
    }

    public override void effect()
    {
        Reverse();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal") Clear = true;

    }
}
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector3 hitPos = Vector3.zero ;
        if (collision.gameObject.tag == "NumBlock")
        {
            Deleat = false;
            foreach (ContactPoint2D point in collision.contacts)
            {
                hitPos = point.point;
            }
            BoundsInt.PositionEnumerator position = collision.gameObject.GetComponent<Tilemap>().cellBounds.allPositionsWithin;
            var allPosition = new List<Vector3>();
            //一番近い場所を保存したいので変数を宣言
            int minPositionNum = 0;

            foreach (var variable in position)
            {
                if (collision.gameObject.GetComponent<Tilemap>().GetTile(variable) != null)
                {
                    allPosition.Add(variable);
                }
            }

            //for文で探査する。でも初期化で0入れてるから1からスタート
            for (int i = 1; i < allPosition.Count; i++)
            {
                if((hitPos - allPosition[i]).magnitude < 0 && (hitPos - allPosition[minPositionNum]).magnitude < 0)
                {
                    //それぞれのあたった場所からの大きさを取得、最小を更新したらminPositionNumを更新する
                    if ((hitPos - allPosition[i]).magnitude > (hitPos - allPosition[minPositionNum]).magnitude)
                    {
                        minPositionNum = i;
                    }
                }
                else
                {
                    //それぞれのあたった場所からの大きさを取得、最小を更新したらminPositionNumを更新する
                    if ((hitPos - allPosition[i]).magnitude < (hitPos - allPosition[minPositionNum]).magnitude)
                    {
                        minPositionNum = i;
                    }
                }
                
            }

            //最終的な位置を一旦格納した。RoundToIntは四捨五入とのことです
            finalPosition = Vector3Int.RoundToInt(allPosition[minPositionNum]);
            BeforPosition = finalPosition;
            tiletmp = collision.gameObject.GetComponent<Tilemap>().GetTile(BeforPosition);

            map = collision.gameObject.GetComponent<Tilemap>();
            tileCol = collision.gameObject.GetComponent<TilemapCollider2D>();


        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(finalPosition);

        if (tiletmp != null)
        {
            map.SetTile(finalPosition, null);
            tileCol.enabled = false;
            tileCol.enabled = true;
        }
    }*/