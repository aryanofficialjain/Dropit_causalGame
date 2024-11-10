using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX; // Sound effects audio source

    [SerializeField]
    private AudioClip landClip, deathClip, iceBreakClip, gameOverClip, starCollectClip; // Sound effect clips

    // Background music audio source
    public AudioSource backgroundMusic;

    // Background music volume (default to 1, which is full volume)
    [Range(0f, 1f)]
    public float backgroundMusicVolume = 1f;

    // Sound effects volume (default to 1, which is full volume)
    [Range(0f, 1f)]
    public float soundFXVolume = 1f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Ensure background music starts playing
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();  // Start background music if it's not already playing
            backgroundMusic.loop = true; // Set background music to loop
        }

        // Set initial volumes
        backgroundMusic.volume = backgroundMusicVolume;
        soundFX.volume = soundFXVolume;
    }

    // Sound effects methods
    public void LandSound()
    {
        soundFX.clip = landClip;
        soundFX.Play();
    }

    public void IceBreakSound()
    {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }

    public void DeathSound()
    {
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    public void GameOverSound()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }

    public void StarCollectSound()
    {
        soundFX.clip = starCollectClip;
        soundFX.Play();
    }

    // Method to pause or resume background music
    public void ToggleBackgroundMusic(bool isPaused)
    {
        if (isPaused)
        {
            backgroundMusic.Pause();  // Pause the background music
        }
        else
        {
            backgroundMusic.UnPause();  // Unpause the background music
        }
    }

    // Method to change background music volume
    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }

    // Method to change sound effects volume
    public void SetSoundFXVolume(float volume)
    {
        soundFX.volume = volume;
    }
}