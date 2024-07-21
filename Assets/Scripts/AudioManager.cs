using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioName
{
    ButtonClick,
    BulletSound,
    Background,
    GameOver
}

[Serializable]
public class AudioType
{
    public AudioName audioName;
    public AudioClip audioClip;
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource SFX;
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioType[] Audio;

    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBG(AudioName.Background);
    }


    public void PlayBG(AudioName name)
    {
        AudioClip audioClip = getAudioClip(name);
        if (audioClip != null)
        {
            BGM.clip = audioClip;
            BGM.Play();
        }
        else
        {
            Debug.Log("Audio not found");
        }
    }

    public void PlaySFX(AudioName name)
    {
        AudioClip audioClip = getAudioClip(name);
        if (audioClip != null)
        {
            SFX.clip = audioClip;
            SFX.PlayOneShot(audioClip);
        }
        else
        {
            Debug.Log("SFX not found");
        }
    }


    private AudioClip getAudioClip(AudioName name)
    {
        AudioType audioType = Array.Find(Audio, item => item.audioName == name);
        if (audioType != null)
            return audioType.audioClip;
        return null;
    }

    public void StopAllSoundsExceptBG()
    {
        SFX.Stop();
    }

    public void SetBGVolume(float volume)
    {
        BGM.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        SFX.volume = volume;
    }
}