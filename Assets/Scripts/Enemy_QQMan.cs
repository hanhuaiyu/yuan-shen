using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_QQMan : Enemy
{
    //刚体 ***
    private Rigidbody2D rb;
    //本体碰撞体 ***
    public Collider2D coll;
    //攻击碰撞体,是开关 ***
    public Collider2D hit;
    //触发攻击实体 ***
    public Transform attackTrigger;
    //
    public LayerMask Player;

    //***
    public float speed = 2.0f;

    //左右界点 ***
    public Transform leftPoint, rightPoint;
    private float left, right;
    //朝向
    private bool faceLeft;
    //
    private bool playerAtLeft;
    //
    private Vector3 playerPos;
    //
    private float direct;
    private float directY;
    //警戒距离
    public float alarmDirect = 10.0f;
    //
    private bool alarm;

    //等待时间 ***
    public int waitTime = 3;
    private int wait;
    //行走循环 ***
    public int walkLoop = 800;
    private int Loop;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        //获取刚体
        rb = GetComponent<Rigidbody2D>();
        //初始化变量
        left = leftPoint.position.x;
        right = rightPoint.position.x;
        faceLeft = true;
        playerAtLeft = true;
        wait = waitTime;
        Loop = walkLoop;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        FindPlayer();
        FaceDirect();
    }

    //动作改变(攻击)，由玩家触发,在每个动作结束后，通过event调用
    private void Switchanim()
    {
        if(Physics2D.OverlapCircle(attackTrigger.position, 2.0f, Player))
        {
            anima.SetBool("hit", true);
            anima.SetBool("walk", false);
        }
    }

    //攻击发力,由event调用
    public void Really_Hit()
    {
        hit.enabled = true;
        if (faceLeft)
        {
            rb.velocity = new Vector2(-speed*3, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed*3, 0);
        }
    }
    //攻击停止，由event调用
    public void Stop_Hit()
    {
        hit.enabled = false;
        anima.SetBool("hit", false);
        wait = 0;
    }

    //静止，由event调用
    public void Idole()
    {
        if (wait != 0)
        {
            wait -= 1;
            return;
        }
        else
        {
            wait = waitTime;
            anima.SetBool("walk", true);
        }
        Switchanim();
    }
    //行走
    public void Walk()
    {
        if (!anima.GetBool("walk"))
            return;
        if(Loop != 0)
        {
            Loop -= 1;
            if (faceLeft)
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(speed, 0);
            }
        }
        else
        {
            Loop = walkLoop;
            anima.SetBool("walk", false);
        }
    }

    //警戒
    private void FindPlayer()
    {
        playerPos = FindObjectOfType<Player_Controller>().gameObject.transform.position;
        direct = transform.position.x - playerPos.x;
        directY = transform.position.y - playerPos.y;
        alarm = ((Mathf.Abs(direct) - alarmDirect) > 0 && (Mathf.Abs(directY) - 2.0f) > 0) ? false : true;
        playerAtLeft = (direct >= 0) ? true : false;
    }

    private void FaceDirect()
    {
        if(alarm)
        {
            if (playerAtLeft)
            {
                faceLeft = true;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                faceLeft = false;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (transform.position.x < left || transform.position.x > right)
            {
                Loop = walkLoop;
                anima.SetBool("walk", false);
            }
        }
        else
        {
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
}
