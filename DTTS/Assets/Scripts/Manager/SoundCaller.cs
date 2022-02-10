using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCaller : MonoBehaviour
{
    public static SoundCaller instance;
    public float volumeSound;
    public AudioSource soundAudioSource;

    [Header("AudioClip")] 
    public AudioClip deathSound;
    public AudioClip jumpSound;
    public AudioClip hitWallSound;
    public AudioClip getCandySound;
    public AudioClip buttonUISound;
    public AudioClip unlockCharacterSound;
    public AudioClip winDuelUISound;
    public AudioClip cantSelectSound;
    
    
    private void Awake()
    {
        if (instance == null) instance = this;
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
    
    
}
