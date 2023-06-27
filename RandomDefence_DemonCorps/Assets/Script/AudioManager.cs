using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : DontDestroy<AudioManager>
{
    [SerializeField]
    AudioMixer _audioMixer;
    [SerializeField]
    AudioSource _bgm;
    [SerializeField]
    AudioSource _sfx;
    [SerializeField]
    AudioClip _titlebgm;
    [SerializeField]
    AudioClip _lobbybgm;
    [SerializeField]
    AudioClip _gamebgm;
    [SerializeField]
    AudioClip _endingbgm;
    [SerializeField]
    AudioClip _click;
    [SerializeField]
    AudioClip _highTier;
    [SerializeField]
    AudioClip[] _monPain;
    [SerializeField]
    AudioClip _optionOn;
    [SerializeField]
    AudioClip _optionOff;
    [SerializeField]
    AudioClip[] _unitSell;
    public void TitleBGM()
    {
        _bgm.clip = _titlebgm;
        _bgm.Play();
    }
    public void LobbyBGM()
    {
        _bgm.clip = _lobbybgm;
        _bgm.Play();
    }
    public void GameBGM()
    {
        _bgm.clip = _gamebgm;
        _bgm.Play();
    }
    public void EndingBGM()
    {
        _bgm.clip = _endingbgm;
        _bgm.Play();
    }
    public void Click()
    {
        _sfx.clip = _click;
        _sfx.Play();
    }
    public void HighTier()
    {
        _sfx.clip = _highTier;
        _sfx.Play();
    }
    public void MonPain()
    {
        _sfx.clip = _monPain[Random.Range(0, _monPain.Length)];
        _sfx.Play();
    }
    public void OptionOn()
    {
        _sfx.clip = _optionOn;
        _sfx.Play();
    }
    public void OptionOff()
    {
        _sfx.clip = _optionOff;
        _sfx.Play();
    }
    public void UnitSell()
    {
        _sfx.clip = _unitSell[Random.Range(0, _unitSell.Length)];
        _sfx.Play();
    }
    public void SetBGMVolume(float volume) => _audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    public void SetSFXVolume(float volume) => _audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
}
