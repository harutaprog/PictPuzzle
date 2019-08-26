using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Remake : Effect
{
    private Rigidbody2D _rb;
    private Vector2 _vecter2;
    [SerializeField]
    private Animator _animator;

    private float _moveSpeed, _jumpPower;

    [SerializeField]
    public bool LeftHitFlag_Top,
                 LeftHitFlag_Under,
                 RightHitFlag_Top,
                 RightHitFlag_Under,
                 GroundHitFlag;

    [SerializeField]
    public bool MissFlag = false,Death = false,Clear = false;
    [SerializeField]
    private GameObject MissGameObject;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();       //rigidbodyの取得
        _moveSpeed = 1.0f;
        _jumpPower = 5.0f;
        LeftHitFlag_Top  = LeftHitFlag_Under = RightHitFlag_Top = RightHitFlag_Under = GroundHitFlag = false;
        _animator.SetBool("Start", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftHitFlag_Top == true && LeftHitFlag_Under == true && RightHitFlag_Top == true && RightHitFlag_Under == true && GroundHitFlag == true)
        {
            Death = true;
            MissFlag = true;
            _animator.SetBool("Start", false);
            gameObject.SetActive(false);
            Instantiate(MissGameObject, transform).transform.parent = null;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity =  new Vector2(transform.localScale.x * _moveSpeed, _rb.velocity.y);
    }

    public void Jump_or_Reverse()
    {
        if (GroundHitFlag)
        {
            if (RightHitFlag_Top)
            {
                //Vector3 temp = transform.localScale;
                //temp.x *= -1;
                //                transform.localScale = temp;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y + _jumpPower);
            }
        }
    }

    public void Jump_or_Reverse_Check()
    {
        _moveSpeed = 1.0f;
        if (LeftHitFlag_Top == false || LeftHitFlag_Under == false || RightHitFlag_Top == false || RightHitFlag_Under == false)
        {
            if (RightHitFlag_Under)
            {
                if (RightHitFlag_Top)
                {
                    if (!LeftHitFlag_Top || !LeftHitFlag_Under && !MissFlag)
                    {
                        Vector3 temp = transform.localScale;
                        temp.x *= -1;
                        transform.localScale = temp;
                    }
                }
                Invoke("Jump_or_Reverse", 0.5f);
            }
        }
    }

    public override void effect()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Clear = true;
        }
    }
}
