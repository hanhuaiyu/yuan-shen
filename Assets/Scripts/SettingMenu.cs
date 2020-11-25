using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

using System.Collections.Specialized;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine.UI;



public class SettingMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public AudioMixer audioMixer;
   



    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void UIEnable()     
    { 
        GameObject.Find("Canvas/UI/MainMenu").SetActive(true);
    }




    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MainVolume", value);
    }
 
}
