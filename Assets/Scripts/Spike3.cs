using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;


public class Spike3 : MonoBehaviour
{

    private Animator anima;
    private Collider2D coll;
    private Rigidbody2D rb;
    public LayerMask Ground;
    public LayerMask Player;
    public Transform transform1;
    public Transform transform2;
  

    public int time;
    private int a;

    void Start()
    {
        transform1 = this.transform;
        anima = GetComponent<Animator>();
        coll= GetComponent<Collider2D>();
        rb= GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        GroundOn();
        Retime();
    }
    public void Death()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
    public void GroundOn()
    {
        if (coll.IsTouchingLayers(Ground)|| coll.IsTouchingLayers(Player))
        {
            anima.SetBool("spike3",true);
            GetComponent<Collider2D>().enabled = false;
            a = 1;
        }
        if (gameObject.transform.localPosition.y < -80)
        {
            anima.SetBool("spike3", true);
            GetComponent<Collider2D>().enabled = false;
            a = 1;
        }
     
    }
   /* public void JumpOn()
    {

        anima.SetBool("spike3", true);
        GetComponent<Collider2D>().enabled = false;
    }*/
    public void Retime()
    {
        if (a == 1)
        {
            Invoke("Show", time);
            a = 0;
        }

    }
    public void Show()
    {
        transform1.position = transform2.position;
        gameObject.SetActive(true);
        GetComponent<Collider2D>().enabled =true;

    }

}


