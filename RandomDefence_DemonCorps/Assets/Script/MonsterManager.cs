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
        Max
    }
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
                mon.InitMonster((MonsterType)type); // type별 몬스터 스텟 할당
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
        //InvokeRepeating("CreateMon5", 250f, 0.5f);
        //Invoke("CencleMon5", 300f);
        Invoke("CreateMon5", 250f);
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
}
