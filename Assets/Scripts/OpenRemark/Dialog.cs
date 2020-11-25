using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLable;
    public Image faceImage;


    [Header("文本文件")]
    public TextAsset textFile;
    public int index=18;
    public float textSpeed;
    bool textFinished;

    [Header("头像")]
    public Sprite face01,face02;

   

    List<string> textList = new List<string>();
    void Awake()
    {
        GetTextFromFile(textFile);

    }
    private void OnEnable()
    {
        //textLable.text = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.R)&& textFinished)
        {
            //textLable.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI());
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');
        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }


    IEnumerator SetTextUI() 
    {
        textFinished = false;
        textLable.text = "";

        switch(textList[index])
        {
            case "A\r":
                faceImage.sprite = face02;
                index++;
                break;
            case "B\r":
                faceImage.sprite = face01;
                index++;
                break;
        }
        for (int i=0;i< textList[index].Length;i++) 

        {
            textLable.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        index++;

    }
}
