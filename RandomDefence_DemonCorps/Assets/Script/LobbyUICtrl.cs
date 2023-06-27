using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BackEnd;
using System.Threading.Tasks;

public class LobbyUICtrl : SingletonMonoBehaviour<LobbyUICtrl>
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
    [SerializeField]
    GameObject _panelRank;
    [SerializeField]
    Button _btnRankExit;
    [Header("스크롤 뷰"), SerializeField]
    ScrollRect _scrollRect;
    [SerializeField]
    TMP_Text _textRank;
    public string Rank = "";

    float _bgm;
    float _sfx;
    void Start()
    {
        _btnGameStart.onClick.AddListener(GameStart);
        _btnRanking.onClick.AddListener(Ranking);
        _btnSetting.onClick.AddListener(Setting);
        _panelSetting.SetActive(false);
        _btnGameOff.onClick.AddListener(GameOff);
        _btnExit.onClick.AddListener(GameExit);
        _btnRankExit.onClick.AddListener(RankExit);
        _sliderBGM.value = PlayerPrefs.GetFloat("BGM");
        _sliderSFX.value = PlayerPrefs.GetFloat("SFX");
    }
    void Update()
    {
        AudioManager.Instance.SetBGMVolume(_sliderBGM.value);
        AudioManager.Instance.SetSFXVolume(_sliderSFX.value);
        _textRank.text = Rank;
    }
    void GameStart()
    {
        AudioManager.Instance.Click();
        GameManager.Instance.GameScene();
    }
    void RankExit()
    {
        AudioManager.Instance.OptionOff();
        _panelRank.SetActive(false);
    }
    void GameExit()
    {
        AudioManager.Instance.OptionOff();
        GameManager.Instance.GameContinue();
        _panelSetting.SetActive(false);
        _bgm = _sliderBGM.value;
        PlayerPrefs.SetFloat("BGM", _bgm);
        _sfx = _sliderSFX.value;
        PlayerPrefs.SetFloat("SFX", _sfx);
    }
    void GameOff()
    {
        AudioManager.Instance.Click();
        GameManager.Instance.GameOff();
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
    async void Test()
    {
        await Task.Run(() =>
        {
            BackendLogin.Instance.CustomLogin("user1", "1234");
            BackendRank.Instance.RankGet();
            Debug.Log("테스트를 종료합니다.");
        });
    }
    public void RankGet()
    {
        string rankUUID = "f2d7d490-13ea-11ee-a9a8-5d80efbfae6e"; // 예시 : "4088f640-693e-11ed-ad29-ad8f0c3d4c70"
        var bro = Backend.URank.User.GetRankList(rankUUID);

        if (bro.IsSuccess() == false)
        {
            Debug.LogError("랭킹 조회중 오류가 발생했습니다. : " + bro);
            return;
        }
        Debug.Log("랭킹 조회에 성공했습니다. : " + bro);

        Debug.Log("총 랭킹 등록 유저 수 : " + bro.GetFlattenJSON()["totalCount"].ToString());

        foreach (LitJson.JsonData jsonData in bro.FlattenRows())
        {
            if (_textRank.text == "")
                _textRank.text = jsonData["nickname"].ToString();
            else
                _textRank.text += "\n" + jsonData["nickname"].ToString();
            /*
            Canvas.ForceUpdateCanvases();
            _scrollRect.verticalNormalizedPosition = 0;
            Canvas.ForceUpdateCanvases();
            */
        }
    }
    void Ranking()
    {
        Rank = "";
        AudioManager.Instance.OptionOn();
        _panelRank.SetActive(true);
        var bro = Backend.Initialize(true);
        if (bro.IsSuccess())
            Debug.Log("초기화 성공 : " + bro);
        else
            Debug.Log("초기화 실패 : " + bro);
        Test();
    }
}
