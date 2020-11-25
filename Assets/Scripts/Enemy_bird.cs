using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_bird : Enemy
{
    private Rigidbody2D rb;
    private Collider2D coll;
    public Transform leftpoint, rightpoint;
    private float leftx, rightx;
    private bool Faceleft = true;
    public float speed;


    void Start()
    {
        base.Start();//获取父级Start
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Movement()
    {
        if (Faceleft)
        {

                //向左点靠近
                rb.velocity = new Vector2(-speed, 0);


            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                Faceleft = false;
            }
        }
        else
        {

                //向右点靠近
                rb.velocity = new Vector2(speed,0);

            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                Faceleft = true;
            }
        }
    }
}
