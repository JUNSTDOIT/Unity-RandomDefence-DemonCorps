using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUICtrl : MonoBehaviour
{
    [SerializeField]
    Button _btnGoLobbyScene;
    void Start()
    {
        _btnGoLobbyScene.onClick.AddListener(GameManager.Instance.LobbyScene);
    }
}
