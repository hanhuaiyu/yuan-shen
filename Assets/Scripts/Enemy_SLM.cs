using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SLM : Enemy
{
    //刚体 ***
    private Rigidbody2D rb;
    //碰撞体 ***
    public Collider2D coll;

    //***
    public float jumpForce = 10.0f;
    //***
    public float speed = 2.0f;

    //地面图层碰撞体 ***
    public LayerMask ground;
    //左右界点 ***
    public Transform leftPoint, rightPoint;
    private float left, right;
    //朝向
    private bool faceLeft;

    //等待时间 ***
    public int waitTime = 2;
    private int wait;
    //错时 ***
    public int perWait = 0;

    protected override void Start()
    {
        base.Start();

        //获取刚体
        rb = GetComponent<Rigidbody2D>();
        //初始化变量
        left = leftPoint.position.x;
        right = rightPoint.position.x;
        faceLeft = true;
        wait = waitTime;
    }

    void Update()
    {
        SwitchAnim();
        FaceDirect();
    }

    //通过event调用
    private void PerJump()
    {
        if (perWait != 0)
        {
            perWait -= 1;
            return;
        }
        if (wait != 0)
        {
            wait -= 1;
            return;
        }
        else
        {
            wait = waitTime;
        }
        anima.SetBool("perjump", true);
    }

    //通过event调用
    public void MainJump()
    {
        //如果在其它敌人身上跳起
        //if (coll.IsTouchingLayers(ground))
        if (true)
        {
            if (faceLeft)
            {
                rb.velocity = new Vector2(-speed, jumpForce);
            }
            else
            {
                rb.velocity = new Vector2(speed, jumpForce);
            }
            anima.SetBool("jumping", true);
            anima.SetBool("perjump", false);
        }
    }

    //掉落动画没有耗时，不能用“event”。
    //而要通过检测object状态来改变动画。
    private void SwitchAnim()
    {
        if (rb.velocity.y < 0.1f && anima.GetBool("jumping"))
        {
            anima.SetBool("jumping", false);
            anima.SetBool("falling", true);
        }
        if (coll.IsTouchingLayers(ground) && anima.GetBool("falling"))
        {
            anima.SetBool("falling", false);
        }
        if(coll.IsTouchingLayers(ground) && !anima.GetBool("jumping") && !anima.GetBool("falling"))
        {
            anima.SetBool("jumping", true);
        }
    }

    //如果跳到其它敌人身上......
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && anima.GetBool("falling"))
        {
            anima.SetBool("falling", false);
        }
    }

    private void FaceDirect()
    {
        //方向判断
        if (transform.position.x < left)
        {
            faceLeft = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x > right)
        {
            faceLeft = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
