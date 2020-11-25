using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenRemark : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLable;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index = 13;
    List<string> textList = new List<string>();
    void Awake()
    {
        GetTextFromFile(textFile);
      
    }
    private void OnEnable()
    {
        textLable.text = textList[index];
        index++;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count) 
        {
            gameObject.SetActive(false);
            index = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.R) )
        {
            textLable.text = textList[index];
            index++;
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
}
