using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("Mastervolume", level);
    }

    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("Music", level);
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("SoundFX", Mathf.Log10(level) * 20f);
    }
}
