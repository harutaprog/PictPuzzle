using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move_Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D box;
    Vector2 vector;
    //public Vector2 Click;
    public float MoveSpeed;
    static float Speed;            //移動スピード
    public float JumpPower; //ジャンプ力
    public bool JumpFlag,JumpNow,JumpFallNow,Not;//ジャンプできるか否か、ジャンプしているか(落下があり得るため)
    bool ReverseFlag, FreeFall;            //反転のフラグ
    bool IsGround;              //着地しているかの判断
    [SerializeField] bool Start_Flag, DebugMode;
    public bool HitUnder;
    public Animator Animator;
    Vector2 force = new Vector2(1.0f, 0.0f);
    //   [SerializeField] ContactFilter2D filter2d;
    // [SerializeField] GameObject Top, Under;
    // Start is called before the first frame update
    void Awake()
    {
        transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        MoveSpeed = 1.0f;
        Speed = MoveSpeed;
        //MoveSpeed = 0.0f;
        Start_Flag = false;
        Not = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(DebugMode)
        {
            GameStart();
        }
        //Debug.Log(rb.velocity.y);
        if (Start_Flag)
        {
            rb.velocity = new Vector2(transform.localScale.x * MoveSpeed, rb.velocity.y);
            //Debug.Log(rb.velocity.x);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
            //MoveSpeed = 0.0f;

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
        /*
        if (IsGround == true)
        {
            ReverseFlag = true;
        }
        else
        {
            ReverseFlag = false;
        }
        */
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
            JumpFlag = false;
        } 
    }
    public void Jump()　//ジャンプできるなら飛び越える
    {
        HitUnder = true;
        if ( JumpFlag && Not)
        {
            JumpFlag = false;
            Debug.Log("Jump");
            ReverseFlag = false;
            JumpNow = true;
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y + JumpPower);
        }
        else
        {
            Reverse();
        }
    }
    void NextJump()
    {
        if (JumpFlag && Not)
        {
            JumpFlag = false;
            Debug.Log("NextJump");
            ReverseFlag = false;
            JumpNow = true;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + JumpPower + 1);
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
        ReverseFlag = true;
        JumpFlag = true;
        Not = true;
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
        if(HitUnder)
        {
            NextJump();
        }
        if(Not == false)
        {
            Reverse();
        }
    }

    public void Not_Ground()
    {
        IsGround = false;
        JumpFlag = false;
    }
    public void FallEnd()
    {
        MoveSpeed = 0.0f;

        Invoke("Move_Restart", 0.5f);
    }
}
