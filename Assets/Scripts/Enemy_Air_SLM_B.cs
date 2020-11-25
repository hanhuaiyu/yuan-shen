using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Air_SLM_B : Enemy
{
    //刚体 ***
    private Rigidbody2D rb;
    //碰撞体 ***
    public Collider2D coll;

    //***
    public float speed = 1.0f;

    //左右界点 ***
    public Transform TopPoint, BottomPoint;
    private float top, bottom;
    //方向
    private bool UpFly;


    //等待时间 ***
    public int waitTime = 1;
    private int wait;
    //错时 ***
    public int perWait = 0;

    protected override void Start()
    {
        base.Start();

        //获取刚体
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        //初始化变量
        top = TopPoint.position.y;
        bottom = BottomPoint.position.y;
        UpFly = true;
        wait = waitTime;
    }

    void Update()
    {
        Fly();
        FaceDirect();
    }

    private void Fly()
    {
        if (UpFly)
        {
            rb.velocity = new Vector2(0, speed);
        }
        else
        {
            rb.velocity = new Vector2(0, -speed);
        }
    }

    private void FaceDirect()
    {
        //方向判断
        if (transform.position.y < bottom)
        {
            UpFly = true;
        }
        else if (transform.position.y > top)
        {
            UpFly = false;
        }
    }
}
