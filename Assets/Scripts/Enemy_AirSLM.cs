using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AirSLM : Enemy
{
    //刚体 ***
    private Rigidbody2D rb;
    //碰撞体 ***
    public Collider2D coll;

    //***
    public float speed = 1.0f;

    //左右界点 ***
    public Transform leftPoint, rightPoint;
    private float left, right;
    //朝向
    private bool faceLeft;

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
        left = leftPoint.position.x;
        right = rightPoint.position.x;
        faceLeft = true;
        wait = waitTime;
    }

    void Update()
    {
        Fly();
        FaceDirect();
    }

    private void Fly()
    {
        if (faceLeft)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
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
