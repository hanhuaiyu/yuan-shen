using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relief_Point : MonoBehaviour
{
    private bool isStart;
    private Animator anim;

    void Start()
    {
        isStart = false;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !isStart)
        {
            isStart = true;
            //anim.SetTrigger("isStart");
            anim.SetTrigger("touch");
            Vector2 pos;
            pos.x = transform.position.x;
            pos.y = transform.position.y;
            FindObjectOfType<Player_Controller>().ReliefPoint = pos;
        }
    }

    public void HadOpened()
    {
        anim.SetTrigger("open");
    }
}
