using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : SingletonMonoBehaviour<MonsterManager>
{
    public enum MonsterType
    {
        None = -1,
        Lv1,
        Lv2,
        Lv3,
        Lv4,
        Lv5,
        Lv6,
        Lv7,
        Lv8,
        Lv9,
        Lv10,
        Lv11,
        Lv12,
        Max
    }
    [SerializeField]
    GameObject[] _monPrefabs;
    Dictionary<MonsterType, GameObjectPool<MonCtrl>> _monPool = new Dictionary<MonsterType, GameObjectPool<MonCtrl>>();
    public void RemoveMonster(MonCtrl mon)
    {
        mon.gameObject.SetActive(false);
        _monPool[mon._Type].Set(mon);
        UIManager.Instance.MonCount();
    }
    protected override void OnStart()
    {
        _monPrefabs = Resources.LoadAll<GameObject>("Prefab/Monster/");
        for (int i = 0; i < _monPrefabs.Length; i++) // MonsterPrefabs의 길이 만큼 반복
        {
            var results = _monPrefabs[i].name.Split('.'); // 프리팹의 이름을 . 을 기준으로 분리한다.( 1, 2, 3 숫자로 활용가능해진다.)
            int type = int.Parse(results[0]) - 1; // type이 0, 1, 2 형식으로 되있어 -1 해준다.
            var pool = new GameObjectPool<MonCtrl>(3, () => // 람다식으로 
            {
                var obj = Instantiate(_monPrefabs[type]); // type에 해당하는 monPrefabs를 인스턴스
                obj.SetActive(false); // 엑티브 비활성화
                obj.transform.SetParent(transform); // 위치는 부모의 위치
                var mon = obj.GetComponent<MonCtrl>(); // mon변수에 MonsterController 할당
                //mon.InitMonster((MonsterType)type); // type별 몬스터 스텟 할당
                return mon;
            });
            _monPool.Add((MonsterType)i, pool); // Pool 생성
        }

        //1라
        InvokeRepeating("CreateMon1", 10f, 0.5f);
        Invoke("CencleMon1", 60f);
        //2라
        InvokeRepeating("CreateMon2", 70f, 0.5f);
        Invoke("CencleMon2", 120f);
        //3라
        InvokeRepeating("CreateMon3", 130f, 0.5f);
        Invoke("CencleMon3", 180f);
        //4라
        InvokeRepeating("CreateMon4", 190f, 0.5f);
        Invoke("CencleMon4", 240f);
        //5라
        InvokeRepeating("CreateMon5", 250f, 0.5f);
        Invoke("CencleMon5", 300f);
        //6라
        Invoke("CreateMon6", 310f);
        //7라
        InvokeRepeating("CreateMon7", 370f, 0.5f);
        Invoke("CencleMon7", 420f);
        //8라
        InvokeRepeating("CreateMon8", 430f, 0.5f);
        Invoke("CencleMon8", 480f);
        //9라
        InvokeRepeating("CreateMon9", 490f, 0.5f);
        Invoke("CencleMon9", 540f);
        //10라
        InvokeRepeating("CreateMon10", 550f, 0.5f);
        Invoke("CencleMon10", 600f);
        //11라
        InvokeRepeating("CreateMon11", 610f, 0.5f);
        Invoke("CencleMon11", 660f);
        //12라
        Invoke("CreateMon12", 670f);
    }
    void CreateMon1()
    {
        MonsterType type;
        type = MonsterType.Lv1;
        var mon = _monPool[type].Get();
        mon.InitMonster(type);
        mon.gameObject.SetActive(true);
        mon.transform.position = transform.position;
        mon.transform.rotation = transform.rotation;
    }
    void CencleMon1() { CancelInvoke("CreateMon1"); }

    void CreateMon2()
    {
        MonsterType type;
        type = MonsterType.Lv2;
        var mon = _monPool[type].Get();
        mon.InitMonster(type);
        mon.gameObject.SetActive(true);
        mon.transform.position = transform.position;
        mon.transform.rotation = transform.rotation;
    }
    void CencleMon2() { CancelInvoke("CreateMon2"); }
    void CreateMon3()
    {
        MonsterType type;
        type = MonsterType.Lv3;
        var mon = _monPool[type].Get();
        mon.InitMonster(type);
        mon.gameObject.SetActive(true);
        mon.transform.position = transform.position;
        mon.transform.rotation = transform.rotation;
    }
    void CencleMon3() { CancelInvoke("CreateMon3"); }
    void CreateMon4()
    {
        MonsterType type;
        type = MonsterType.Lv4;
        var mon = _monPool[type].Get();
        mon.InitMonster(type);
        mon.gameObject.SetActive(true);
        mon.transform.position = transform.position;
        mon.transform.rotation = transform.rotation;
    }
    void CencleMon4() { CancelInvoke("CreateMon4"); }
    void CreateMon5()
    {
        MonsterType type;
        type = MonsterType.Lv5;
        var mon = _monPool[type].Get();
        mon.InitMonster(type);
        mon.gameObject.SetActive(true);
        mon.transform.position = transform.position;
        mon.transform.rotation = transform.rotation;
    }
    void CencleMon5() { CancelInvoke("CreateMon5"); }
    void CreateMon6()
    {
        MonsterType type;
        type = MonsterType.Lv6;
        var mon = _monPool[type].Get();
        mon.InitMonster(type);
        mon.gameObject.SetActive(true);
        mon.transform.position = transform.position;
        mon.transform.rotation = transform.rotation;
    }
    void CencleMon6() { CancelInvoke("CreateMon6"); }
    void CreateMon7()
    {
        MonsterType type;
        type = MonsterType.Lv7;
        var mon = _monPool[type].Get();
        mon.InitMonster(type);
        mon.gameObject.SetActive(true);
        mon.transform.position = transform.position;
        mon.transform.rotation = transform.rotation;
    }
    void CencleMon7() { CancelInvoke("CreateMon7"); }
    void CreateMon8()
    {
        MonsterType type;
        type = MonsterType.Lv8;
        var mon = _monPool[type].Get();
        mon.InitMonster(type);
        mon.gameObject.SetActive(true);
        mon.transform.position = transform.position;
        mon.transform.rotation = transform.rotation;
    }
    void CencleMon8() { CancelInvoke("CreateMon8"); }
    void CreateMon9()
    {
        MonsterType type;
        type = MonsterType.Lv9;
        var mon = _monPool[type].Get();
        mon.InitMonster(type);
        mon.gameObject.SetActive(true);
        mon.transform.position = transform.position;
        mon.transform.rotation = transform.rotation;
    }
    void CencleMon9() { CancelInvoke("CreateMon9"); }
    void CreateMon10()
    {
        MonsterType type;
        type = MonsterType.Lv10;
        var mon = _monPool[type].Get();
        mon.InitMonster(type);
        mon.gameObject.SetActive(true);
        mon.transform.position = transform.position;
        mon.transform.rotation = transform.rotation;
    }
    void CencleMon10() { CancelInvoke("CreateMon10"); }
    void CreateMon11()
    {
        MonsterType type;
        type = MonsterType.Lv11;
        var mon = _monPool[type].Get();
        mon.InitMonster(type);
        mon.gameObject.SetActive(true);
        mon.transform.position = transform.position;
        mon.transform.rotation = transform.rotation;
    }
    void CencleMon11() { CancelInvoke("CreateMon11"); }
    void CreateMon12()
    {
        MonsterType type;
        type = MonsterType.Lv12;
        var mon = _monPool[type].Get();
        mon.InitMonster(type);
        mon.gameObject.SetActive(true);
        mon.transform.position = transform.position;
        mon.transform.rotation = transform.rotation;
    }
    void CencleMon12() { CancelInvoke("CreateMon12"); }
}
