using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using System.Threading.Tasks;

public class BackendManager : MonoBehaviour
{

    void Start()
    {
        var bro = Backend.Initialize(true);
        if (bro.IsSuccess())
            Debug.Log("초기화 성공 : " + bro);
        else
            Debug.Log("초기화 실패 : " + bro);
        Test();
    }
    async void Test()
    {
        await Task.Run(() =>
        {
            BackendLogin.Instance.CustomSignUp("user2", "1234");
            BackendLogin.Instance.CustomLogin("user2", "1234");
            BackendLogin.Instance.UpdateNickname("test2");
            //BackendLogin.Instance.CustomLogin("user1", "1234");
            BackendRank.Instance.RankInsert(140);
            //BackendRank.Instance.RankGet();
            Debug.Log("테스트를 종료합니다.");
        });
    }
}
