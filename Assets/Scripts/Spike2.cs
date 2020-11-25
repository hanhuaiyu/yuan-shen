using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;


public class Spike2 : MonoBehaviour
{
    private Animator anima;
    private Collider2D coll;
    private Rigidbody2D rb;

    public LayerMask Player;
    public Transform transform1;
    public Transform transform2;

    public int time;
    private int dec;
    void Start()
    {
        transform1 = this.transform;
        anima = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Retime();
        GroundOn();
    }

    public void JumpOn()
    {
        anima.SetBool("spike2", true);
     
    }
    public void Death()
    {
        
        gameObject.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
        
        //Destroy(gameObject);
       
    }

    public void GroundOn()
    {
        if (coll.IsTouchingLayers(Player))
        {
            anima.SetBool("spike2", true);
           
            dec = 1;
        }
    }
    public void Retime()
    {
        if (dec == 1)
        {
            Invoke("Show", time);
            dec = 0;
        }
    }
    public void Show()
    {
        transform1.position = transform2.position;

        gameObject.SetActive(true);
        GetComponent<Collider2D>().enabled = true;
       
    }
    

}
