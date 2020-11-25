using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public void GetFeedback(int type)
    {
        switch(type)
        {
            case 0:
                //FindObjectOfType<Player_Controller>().GetHeart();
                Destroy(gameObject);
                break;
            case 1:
                FindObjectOfType<Player_Controller>().GetCase();
                Destroy(gameObject);
                break;
            case 2:
                FindObjectOfType<Player_Controller>().GetAirEye();
                Destroy(gameObject);
                break;
            case 3:
                FindObjectOfType<Player_Controller>().GetStoneEye();
                Destroy(gameObject);
                break;
        }
    }
}
