using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D box;
    public Vector2 Click;
    public float MoveSpeed,Speed;            //移動スピード
    public float JumpPower,ForcePower; //ジャンプ力
    public bool JumpFlag,JumpNow,JumpFallNow;//ジャンプできるか否か、ジャンプしているか(落下があり得るため)
    public bool FreeFall;              //ジャンプをしない落下
    public bool ReverseFlag;           //反転のフラグ
    public bool IsGround;              //着地しているかの判断
    public bool NowJump;
    [SerializeField] bool Start_Flag;
    //   [SerializeField] ContactFilter2D filter2d;
    // [SerializeField] GameObject Top, Under;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        Speed = MoveSpeed;
        MoveSpeed = 0;
        Start_Flag = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(rb.velocity.y);
        if (Start_Flag)
        {
            rb.velocity = new Vector2(transform.localScale.x * MoveSpeed, rb.velocity.y);
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
            //JumpFlag = true;
            ReverseFlag = true;
        }
        else
        {
            //JumpFlag = false;
            ReverseFlag = false;
        }
        /*
        if (JumpNow == true && rb.velocity.y < -0.0f)
        {
            rb.velocity = new Vector2(ForcePower, rb.velocity.y);
            JumpFallNow = true;
        }
        if (JumpFallNow)
        {
            if (rb.velocity.y == 0)
            {
               Invoke("Move_Restart",0.5f);
            }
        }
        */
        if(JumpNow == false && IsGround == false)
        {
            FreeFall = true;
            MoveSpeed = 0;
        }
        
        if(FreeFall)
        {
            if (rb.velocity.y == 0)
            {
                Invoke("Move_Restart", 0.5f);
            }
        }
        
        if(NowJump)
        {
            Debug.Log(rb.velocity.x);
            
        }
    }
    public void Reverse() //ジャンプできない高さに当たった時に反転
    {
        if (ReverseFlag == true && IsGround == true)
        {
            MoveSpeed = 0;
            ForcePower *= -1;
            Invoke("Set", 1.0f);
        }
    }

    public void Jump(float position)　//ジャンプできるなら飛び越える
    {
        
        if (/*IsGround == true &&*/ JumpFlag == true)
        {
            ReverseFlag = false;
            JumpFlag = false;
            //MoveSpeed = 0;
            //transform.position = new Vector2(transform.position.x + (Speed * transform.localScale.x) / 5, transform.position.y + position);
           
            rb.AddForce(Vector2.up * JumpPower);
            NowJump = true;
            Invoke("Move_Restart",0.3f);  
            // box.isTrigger = true;
        }
    }
    private void Set()
    {
        MoveSpeed = Speed;
        Vector3 temp = gameObject.transform.localScale;
        temp.x *= -1;
        gameObject.transform.localScale = temp;
        JumpFlag = true;
    }
    private void Trigger()
    {
        rb.velocity = new Vector2(0, JumpPower);
        JumpNow = true;
    }
    private void Move_Restart()
    {
        MoveSpeed = Speed;
        ReverseFlag = true;
        JumpFlag = true;
        JumpNow = false;
        JumpFallNow = false;
        FreeFall = false;
    }
    public void Ground()
    {
        IsGround = true;
        NowJump = false;
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
}
