using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform Cam;
    public float moveRate;
    private float startPointX, startPointY;
    public bool lockY;//false
    void Start()
    {
        startPointX = transform.position.x;
        startPointY = transform.position.y;
    }

   
    void Update()
    {
        if (lockY)
        {
            transform.position = new Vector2(startPointX + Cam.position.x * moveRate, transform.position.y);
        }  
        else
        {
            transform.position = new Vector2(startPointX + Cam.position.x * moveRate, startPointX+Cam.position.y * moveRate);
        }
    }
}
