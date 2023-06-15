using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUICtrl : MonoBehaviour
{
    [SerializeField]
    Button _btnGameStart;
    [SerializeField]
    Button _btnRanking;
    [SerializeField]
    Button _btnSetting;
    [SerializeField]
    GameObject _panelSetting;
    [SerializeField]
    Slider _sliderBGM;
    [SerializeField]
    Slider _sliderSFX;
    [SerializeField]
    Button _btnGameOff;
    [SerializeField]
    Button _btnExit;
    float _bgm;
    float _sfx;
    void Start()
    {
        _btnGameStart.onClick.AddListener(GameManager.Instance.GameScene);
        _btnRanking.onClick.AddListener(Ranking);
        _btnSetting.onClick.AddListener(Setting);
        _panelSetting.SetActive(false);
        _btnGameOff.onClick.AddListener(GameOff);
        _btnExit.onClick.AddListener(GameExit);
        _sliderBGM.value = PlayerPrefs.GetFloat("BGM");
        _sliderSFX.value = PlayerPrefs.GetFloat("SFX");
    }
    void Update()
    {
        AudioManager.Instance.SetBGMVolume(_sliderBGM.value);
        AudioManager.Instance.SetSFXVolume(_sliderSFX.value);
    }
    void GameExit()
    {
        GameManager.Instance.GameContinue();
        _panelSetting.SetActive(false);
        _bgm = _sliderBGM.value;
        PlayerPrefs.SetFloat("BGM", _bgm);
        _sfx = _sliderSFX.value;
        PlayerPrefs.SetFloat("SFX", _sfx);
    }
    void GameOff()
    {
        GameManager.Instance.GameOff();
        _panelSetting.SetActive(false);
        _bgm = _sliderBGM.value;
        PlayerPrefs.SetFloat("BGM", _bgm);
        _sfx = _sliderSFX.value;
        PlayerPrefs.SetFloat("SFX", _sfx);
    }
    void Setting()
    {
        _panelSetting.SetActive(true);
        GameManager.Instance.GameStop();
    }
    void Ranking()
    {

    }
}
