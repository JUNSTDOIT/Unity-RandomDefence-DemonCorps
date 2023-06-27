using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUICtrl : MonoBehaviour
{
    [SerializeField]
    Button _btnSetting;
    [SerializeField]
    GameObject _panelSetting;
    [SerializeField]
    Slider _sliderBGM;
    [SerializeField]
    Slider _sliderSFX;
    [SerializeField]
    Button _btnHome;
    [SerializeField]
    Button _btnRestart;
    [SerializeField]
    Button _btnContinue;
    float _bgm;
    float _sfx;
    void Start()
    {
        _btnSetting.onClick.AddListener(Setting);
        _panelSetting.SetActive(false);
        _btnHome.onClick.AddListener(Home);
        _btnRestart.onClick.AddListener(ReStart);
        _btnContinue.onClick.AddListener(Continue);
        _sliderBGM.value = PlayerPrefs.GetFloat("BGM");
        _sliderSFX.value = PlayerPrefs.GetFloat("SFX");
    }

    void Update()
    {
        AudioManager.Instance.SetBGMVolume(_sliderBGM.value);
        AudioManager.Instance.SetSFXVolume(_sliderSFX.value);
    }
    void ReStart()
    {
        AudioManager.Instance.Click();
        GameManager.Instance.GameRestart();
        _bgm = _sliderBGM.value;
        PlayerPrefs.SetFloat("BGM", _bgm);
        _sfx = _sliderSFX.value;
        PlayerPrefs.SetFloat("SFX", _sfx);
    }
    void Home()
    {
        AudioManager.Instance.Click();
        GameManager.Instance.LobbyScene();
        _bgm = _sliderBGM.value;
        PlayerPrefs.SetFloat("BGM", _bgm);
        _sfx = _sliderSFX.value;
        PlayerPrefs.SetFloat("SFX", _sfx);
    }
    void Continue()
    {
        AudioManager.Instance.OptionOff();
        GameManager.Instance.GameContinue();
        _panelSetting.SetActive(false);
        _bgm = _sliderBGM.value;
        PlayerPrefs.SetFloat("BGM", _bgm);
        _sfx = _sliderSFX.value;
        PlayerPrefs.SetFloat("SFX", _sfx);
    }
    void Setting()
    {
        AudioManager.Instance.OptionOn();
        _panelSetting.SetActive(true);
        GameManager.Instance.GameStop();
    }

}
