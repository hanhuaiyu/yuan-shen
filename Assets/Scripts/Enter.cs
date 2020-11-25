using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enter : MonoBehaviour
{
    private int INDEX;
    private int NUM;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            INDEX = SceneManager.GetActiveScene().buildIndex;
            switch(INDEX)
            {
                case 2:
                    NUM = FindObjectOfType<Player_Controller>().GetNum(2);
                    if (NUM < 4) return;
                    break;
                case 3:
                    NUM = FindObjectOfType<Player_Controller>().GetNum(1);
                    if (NUM < 4) return;
                    break;
                case 4:
                    NUM = FindObjectOfType<Player_Controller>().GetNum(3);
                    if (NUM < 4) return;
                    break;
                default:
                    break;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
