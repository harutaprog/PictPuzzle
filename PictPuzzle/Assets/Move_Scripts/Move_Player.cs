using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move_Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D box;
    Vector2 vector;
    public Vector2 Click;
    public float MoveSpeed,Speed;            //移動スピード
    public float JumpPower; //ジャンプ力
    public bool JumpFlag,JumpNow,JumpFallNow;//ジャンプできるか否か、ジャンプしているか(落下があり得るため)
    bool FreeFall;              //ジャンプをしない落下
    public bool ReverseFlag;           //反転のフラグ
    bool IsGround;              //着地しているかの判断
    [SerializeField] bool Start_Flag;
    [SerializeField] bool OneAction; //ジャンプの複数処理を防ぎたい
    RayControll controller;

    Vector2 force = new Vector2(1.0f, 0.0f);
    //   [SerializeField] ContactFilter2D filter2d;
    // [SerializeField] GameObject Top, Under;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<RayControll>();

        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        Speed = MoveSpeed;
        MoveSpeed = 0.0f;
        Start_Flag = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(rb.velocity.y);
        if (Start_Flag)
        {
            rb.velocity = new Vector2(transform.localScale.x * MoveSpeed, rb.velocity.y);
            //Debug.Log(rb.velocity.x);
        }
        /*
        if (Input.GetKeyDown("space"))
        {
            // add *= -1;
            // sp = add;
            Vector2 temp = gameObject.transform.localScale;
            temp.x *= -1;
            gameObject.transform.localScale = temp;

        }
        */
        
        if (IsGround == true)
        {
            ReverseFlag = true;
        }
        else
        {
            ReverseFlag = false;
        }
        
        if (JumpNow == true && rb.velocity.y < -0.0f)
        {
            //rb.velocity = new Vector2(ForcePower, rb.velocity.y);
            JumpFallNow = true;
        }
        if (JumpFallNow)
        {
            if (rb.velocity.y == 0)
            {
               Invoke("Move_Restart",0.5f);
            }
        }

        if(JumpNow == false && JumpFallNow == false && IsGround == false)
        {
            FreeFall = true;
            MoveSpeed = 0;
        }
        
        if(FreeFall)
        {
            if (rb.velocity.y == 0)
            {
                //Invoke("Move_Restart", 0.5f);
            }
        }
        
        
    }
    public void Jump()　//ジャンプできるなら飛び越える
    {
        if (JumpFlag == true)
        {
            Debug.Log("Jump");

            OneAction = false;
            ReverseFlag = false;
            JumpFlag = false;
            JumpNow = true;
            rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
        else
        {
            Reverse();
        }
    }

    public void Reverse() //ジャンプできない高さに当たった時に反転
    {
        if (ReverseFlag == true && IsGround == true)
        {
            ReverseFlag = false;
            MoveSpeed = 0.0f;
            Debug.Log("Reverse");
            MoveSpeed = 0;
            Vector3 temp = gameObject.transform.localScale;
            temp.x *= -1;
            gameObject.transform.localScale = temp;

            Invoke("Set", 1.0f);
        }
    }

   
    private void Set()
    {
        
        MoveSpeed = Speed;
        ReverseFlag = false;
        JumpFlag = true;
    }
    
    private void Move_Restart()
    {
        JumpFlag = true;
        MoveSpeed = Speed;
        ReverseFlag = true;
        FreeFall = false;
    }
    public void Ground()
    {
        IsGround = true;
        JumpFlag = true;
        JumpNow = false;
        JumpFallNow = false;
        FreeFall = false;
    }
    public void Not_Ground()
    {
        IsGround = false;
    }
    
    public void GameStart()
    {
        Start_Flag = true;
        Invoke("Move_Restart", 0.5f);
    }
    public void GameClear()
    {
        MoveSpeed = 0;
    }

    public void False()
    {
        JumpFlag = false;
    }
    public void FallEnd()
    {
        Invoke("Move_Restart", 0.5f);
    }
}
