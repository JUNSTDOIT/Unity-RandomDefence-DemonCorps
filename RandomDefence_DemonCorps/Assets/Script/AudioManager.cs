using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : DontDestroy<AudioManager>
{
    [SerializeField]
    AudioMixer _audioMixer;
    public void SetBGMVolume(float volume)
    {
        _audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        _audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
