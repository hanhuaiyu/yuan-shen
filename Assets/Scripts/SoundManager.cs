using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource;
    public AudioClip jumpAudio, hurtAudio, CollectionAudio;


    public void Awake()
    {
        instance = this;
    }

    public void JumpAudio()
    {
        audioSource.clip = jumpAudio;
        audioSource.Play();
    }
    /*
    public void hurtAudio()
    {
        audioSource.clip = hurtAudio;
        audioSource.Play();
    }
    public void collectionAudio()
    {
        audioSource.clip = collectionAudio;
        audioSource.Play();
    }*/
    // SoundManager.instance.JumpAudio(); 调用静态类

}
