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
                //mon.InitMonster((MonsterType)type); // type�� ���� ���� �Ҵ�
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
        InvokeRepeating("CreateMon5", 250f, 0.5f);
        Invoke("CencleMon5", 300f);
        //6��
        Invoke("CreateMon6", 310f);
        //7��
        InvokeRepeating("CreateMon7", 370f, 0.5f);
        Invoke("CencleMon7", 420f);
        //8��
        InvokeRepeating("CreateMon8", 430f, 0.5f);
        Invoke("CencleMon8", 480f);
        //9��
        InvokeRepeating("CreateMon9", 490f, 0.5f);
        Invoke("CencleMon9", 540f);
        //10��
        InvokeRepeating("CreateMon10", 550f, 0.5f);
        Invoke("CencleMon10", 600f);
        //11��
        InvokeRepeating("CreateMon11", 610f, 0.5f);
        Invoke("CencleMon11", 660f);
        //12��
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
