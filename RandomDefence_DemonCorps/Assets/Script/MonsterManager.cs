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
        for (int i = 0; i < _monPrefabs.Length; i++) // MonsterPrefabs�� ���� ��ŭ �ݺ�
        {
            var results = _monPrefabs[i].name.Split('.'); // �������� �̸��� . �� �������� �и��Ѵ�.( 1, 2, 3 ���ڷ� Ȱ�밡��������.)
            int type = int.Parse(results[0]) - 1; // type�� 0, 1, 2 �������� ���־� -1 ���ش�.
            var pool = new GameObjectPool<MonCtrl>(3, () => // ���ٽ����� 
            {
                var obj = Instantiate(_monPrefabs[type]); // type�� �ش��ϴ� monPrefabs�� �ν��Ͻ�
                obj.SetActive(false); // ��Ƽ�� ��Ȱ��ȭ
                obj.transform.SetParent(transform); // ��ġ�� �θ��� ��ġ
                var mon = obj.GetComponent<MonCtrl>(); // mon������ MonsterController �Ҵ�
                mon.InitMonster((MonsterType)type); // type�� ���� ���� �Ҵ�
                return mon;
            });
            _monPool.Add((MonsterType)i, pool); // Pool ����
        }

        //1��
        InvokeRepeating("CreateMon1", 10f, 0.5f);
        Invoke("CencleMon1", 60f);
        //2��
        InvokeRepeating("CreateMon2", 70f, 0.5f);
        Invoke("CencleMon2", 120f);
        //3��
        InvokeRepeating("CreateMon3", 130f, 0.5f);
        Invoke("CencleMon3", 180f);
        //4��
        InvokeRepeating("CreateMon4", 190f, 0.5f);
        Invoke("CencleMon4", 240f);
        //5��
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
