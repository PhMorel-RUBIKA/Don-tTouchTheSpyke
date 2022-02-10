using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundCaller : MonoBehaviour
{
    public static SoundCaller instance;
    public float volumeSound;
    public AudioSource soundAudioSource;

    public Sprite isMuteSprite;
    public Sprite isOnSprite;
    public Image soundButton;

    [Header("AudioClip")] 
    public AudioClip deathSound;
    public AudioClip jumpSound;
    public AudioClip hitWallSound;
    public AudioClip getCandySound;
    public AudioClip buttonUISound;
    public AudioClip unlockCharacterSound;
    public AudioClip winDuelUISound;
    public AudioClip cantSelectSound;

    private bool isMute; 
    
    
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        isMute = false;
    }

    public void DeathSound()
    {
        soundAudioSource.PlayOneShot(deathSound);
    }
    
    public void JumpSound()
    {
        soundAudioSource.PlayOneShot(jumpSound);
    }
    
    public void HitWallSound()
    {
        soundAudioSource.PlayOneShot(hitWallSound);
    }
    
    public void GetCandySound()
    {
        soundAudioSource.PlayOneShot(getCandySound);
    }
    
    public void ButtonUISound()
    {
        soundAudioSource.PlayOneShot(buttonUISound);
    }
    
    public void UnlockCharacterSound()
    {
        soundAudioSource.PlayOneShot(unlockCharacterSound);
    }
    
    public void WinDuelUISound()
    {
        soundAudioSource.PlayOneShot(winDuelUISound);
    }
    
    public void CantSelectSound()
    {
        soundAudioSource.PlayOneShot(cantSelectSound);
    }

    public void SoundChange()
    {
        Debug.Log("Appuye sur le bouton");
        switch (isMute)
        {
            case true:
                isMute = false;
                soundAudioSource.volume = 1;
                soundButton.sprite = isMuteSprite;
                break;
            case false:
                isMute = true;
                soundAudioSource.volume = 0;
                soundButton.sprite = isOnSprite;
                break;
        }
    }
}
