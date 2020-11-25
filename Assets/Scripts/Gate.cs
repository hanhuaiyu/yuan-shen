using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    private Animator anima;
    private  Collider2D coll;
    void Start()
    {
        anima = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        
    }
    private void OnMouseUpAsButton()
    {
        anima.SetBool("open", true);
    }
    private void OnMouseEnter()
    {
        anima.SetBool("gate", true);

    }
    public void Off()
    {
        anima.SetBool("gate", false);

    }



}
