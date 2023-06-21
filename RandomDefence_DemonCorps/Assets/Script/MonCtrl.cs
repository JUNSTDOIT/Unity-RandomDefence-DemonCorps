using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonCtrl : MonoBehaviour
{
    //----------------------------------
    [Header("[ �̵� �ӵ�.. ]"), SerializeField]
    float _moveSpeed = 1f;
    //----------------------------------
    [Header("[ ȸ�� �ӵ�.. ]"), SerializeField]
    float _rotSpeed = 15f;
    //----------------------------------
    [Header("[ ���� ����Ʈ �迭..]"), SerializeField]
    Transform[] _wayPts;
    //----------------------------------
    [Header("[ ���� �̵� Ÿ�� ���� ����Ʈ �ε���..]"), SerializeField]
    int _nextWayptIdx = 1;

    float _time = 0f;

    float _curMoveSpeed;
    MonHealth _monHP;
    MonsterManager.MonsterType _type;
    public MonsterManager.MonsterType _Type { get { return _type; } }
    public void SetMoveSpeed(float speed)
    {
        _moveSpeed = speed;
        Invoke("ResetMoveSpeed", 4f);
    }
    void ResetMoveSpeed() => _moveSpeed = _curMoveSpeed;

    public void InitMonster(MonsterManager.MonsterType type) // ���� Ÿ�Ժ� ����
    {
        _type = type;
        if (((int)type + 1) == 1) // ����1
        {
            _moveSpeed = 10f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(10);
        }
        if (((int)type + 1) == 2) // ����2
        {
            _moveSpeed = 10f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(40);
        }
        if (((int)type + 1) == 3) // ����3
        {
            _moveSpeed = 15f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(160);
        }
        if (((int)type + 1) == 4) // ����4
        {
            _moveSpeed = 10f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(320);
        }
        if (((int)type + 1) == 5) // ����5
        {
            _moveSpeed = 10f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(64000);
        }
    }

    void Awake()
    {
        _wayPts = GameObject.Find("Way Points").GetComponentsInChildren<Transform>();
        _monHP = GetComponent<MonHealth>();
    }
    void Move_By_WayPts()
    {
        //  ���� ���� ���..
        //  -   ���� ��ġ  ->  ���� ���� ����Ʈ ��ġ
        Vector3 dir = _wayPts[_nextWayptIdx].position - transform.position;

        //  ���� ������ ȸ�� ������ ���ʹϾ����� ��ȯ..
        Quaternion rot = Quaternion.LookRotation(dir.normalized);

        //  ȸ�� ����..
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, _rotSpeed * Time.deltaTime);

        //  �� �������� �̵�..
        transform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed);

    }
    void Update()
    {
        if (!_monHP._IsDie)
            Move_By_WayPts();
        else
        {
            _time += Time.deltaTime;
            if (_time >= 0.25f)
            {
                _nextWayptIdx = 1;
                _time = 0f;
                MonsterManager.Instance.RemoveMonster(this);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WayPoint"))
        {
            _nextWayptIdx++;
            //Debug.Log("test");
            if (_nextWayptIdx >= 5)
                _nextWayptIdx = 1;
        }
    }
}
