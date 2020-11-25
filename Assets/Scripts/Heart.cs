using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private GameObject[] Images = new GameObject[6];
    public GameObject Image_1, Image_2, Image_3, Image_4, Image_5;

    void Start()
    {
        Images[1] = Image_1;
        Images[2] = Image_2;
        Images[3] = Image_3;
        Images[4] = Image_4;
        Images[5] = Image_5;
    }

    public void HeartBreak(int index)
    {
        Images[index].SetActive(false);
    }
}
