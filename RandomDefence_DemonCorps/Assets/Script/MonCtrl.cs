using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonCtrl : MonoBehaviour
{
    //----------------------------------
    [Header("[ 이동 속도.. ]"), SerializeField]
    float _moveSpeed = 1f;
    //----------------------------------
    [Header("[ 회전 속도.. ]"), SerializeField]
    float _rotSpeed = 15f;
    //----------------------------------
    [Header("[ 웨이 포인트 배열..]"), SerializeField]
    Transform[] _wayPts;
    //----------------------------------
    [Header("[ 다음 이동 타겟 웨이 포인트 인덱스..]"), SerializeField]
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

    public void InitMonster(MonsterManager.MonsterType type) // 몬스터 타입별 스텟
    {
        _type = type;
        if (((int)type + 1) == 1) // 몬스터1
        {
            _moveSpeed = 10f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(10);
        }
        if (((int)type + 1) == 2) // 몬스터2
        {
            _moveSpeed = 10f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(40);
        }
        if (((int)type + 1) == 3) // 몬스터3
        {
            _moveSpeed = 15f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(160);
        }
        if (((int)type + 1) == 4) // 몬스터4
        {
            _moveSpeed = 10f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(320);
        }
        if (((int)type + 1) == 5) // 몬스터5
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
        //  방향 벡터 계산..
        //  -   현재 위치  ->  다음 웨이 포인트 위치
        Vector3 dir = _wayPts[_nextWayptIdx].position - transform.position;

        //  방향 벡터의 회전 각도를 쿼터니언으로 변환..
        Quaternion rot = Quaternion.LookRotation(dir.normalized);

        //  회전 보간..
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, _rotSpeed * Time.deltaTime);

        //  앞 방향으로 이동..
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
