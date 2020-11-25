using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy_frog : Enemy
{
    //刚体
    private Rigidbody2D rb;
    //private Animator anima;
    private Collider2D coll;
    public Transform leftpoint, rightpoint;
    private float leftx, rightx;
    private bool Faceleft = true;
    public float speed, jumpforce;
    public LayerMask Ground;

    protected override void Start()
    {
        base.Start();//获取父级Start
        rb = GetComponent<Rigidbody2D>();
        //anima = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        //断绝子项目联系
        // transform.DetachChildren();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }


    void Update()
    {
        // Movement();
        SwitchAnim();
    }

    //frog移动
    void Movement()
    {
        if (Faceleft)
        {
            if (coll.IsTouchingLayers(Ground))
            {
                anima.SetBool("jumping", true);
                //向左点靠近
                rb.velocity = new Vector2(-speed, jumpforce);

            }

            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                Faceleft = false;
            }
        }
        else
        {

            if (coll.IsTouchingLayers(Ground))
            {
                anima.SetBool("jumping", true);
                //向右点靠近
                rb.velocity = new Vector2(speed, jumpforce);

            }
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                Faceleft = true;
            }
        }
    }
    void SwitchAnim()
    {
        if (anima.GetBool("jumping"))
        {
            if (rb.velocity.y < 0.1)
            {
                anima.SetBool("jumping", false);
                anima.SetBool("falling", true);
            }
        }
        if (coll.IsTouchingLayers(Ground) && anima.GetBool("falling"))
        {
            anima.SetBool("falling", false);
        }
    }
    /* public void Death()
     {
         Destroy(gameObject);
     }
     public void JumpOn()
     {
         anima.SetTrigger("death");
     }*/

}
