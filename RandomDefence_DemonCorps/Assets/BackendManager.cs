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
            Debug.Log("�ʱ�ȭ ���� : " + bro);
        else
            Debug.Log("�ʱ�ȭ ���� : " + bro);
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
            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }
}
