using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anima;
    protected AudioSource DeathAudio;

    protected virtual void Start()
    {
        anima = GetComponent<Animator>();
        DeathAudio = GetComponent<AudioSource>();
    }

    public void Boom()
    {
        GetComponent<Collider2D>().enabled = false;
        anima.SetTrigger("death");
        //当“death”的动画播放完成，触发“Death()”销毁。
        DeathAudio.Play();
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Boom();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EHit")
        {
            Boom();
        }
    }
}
