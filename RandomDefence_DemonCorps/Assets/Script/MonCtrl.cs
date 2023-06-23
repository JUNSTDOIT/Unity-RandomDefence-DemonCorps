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
    [SerializeField]
    SkinnedMeshRenderer _renderer;
    [SerializeField]
    Shader _shaderAlpaBlending;
    Shader _curshader;
    float _skillTime = 1f;
    bool _isSkill = false;
    float _coolTime = 10f;

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
            _monHP.SetHP(15);
        }
        else if (((int)type + 1) == 2) // ����2
        {
            _moveSpeed = 10f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(30);
        }
        else if (((int)type + 1) == 3) // ����3
        {
            _moveSpeed = 15f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(60);
        }
        else if (((int)type + 1) == 4) // ����4
        {
            _moveSpeed = 5f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(360);
        }
        else if (((int)type + 1) == 5) // ����5
        {
            _moveSpeed = 10f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(240);
        }
        else if (((int)type + 1) == 6) // ����6
        {
            _moveSpeed = 10f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(24000);
            _curshader = _renderer.material.shader;
        }
        else if (((int)type + 1) == 7) // ����7
        {
            _moveSpeed = 5f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(1440);
        }
        else if (((int)type + 1) == 8) // ����8
        {
            _moveSpeed = 10f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(960);
        }
        else if (((int)type + 1) == 9) // ����9
        {
            _moveSpeed = 15f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(1920);
        }
        else if (((int)type + 1) == 10) // ����10
        {
            _moveSpeed = 10f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(3840);
        }
        else if (((int)type + 1) == 11) // ����11
        {
            _moveSpeed = 5f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(7680);
        }
        else if (((int)type + 1) == 12) // ����12
        {
            _moveSpeed = 5f;
            _curMoveSpeed = _moveSpeed;
            _monHP.SetHP(600000);
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
        if(_type == MonsterManager.MonsterType.Lv6)
        {
            if (!_isSkill)
                _coolTime -= Time.deltaTime;
            if(_coolTime <= 0f && !_isSkill)
            {
                _isSkill = true;
                _renderer.material.shader = _shaderAlpaBlending;
                this.gameObject.layer = 0;
                Invoke("SkillCool", _skillTime);
            }
        }
        if(_type == MonsterManager.MonsterType.Lv12)
        {
            _coolTime -= Time.deltaTime;
            if(_coolTime <= 0f)
            {
                _monHP.HPUP(10000);
                _coolTime = 10f;
            }
        }
    }
    void SkillCool()
    {
        _renderer.material.shader = _curshader;
        this.gameObject.layer = 3;
        _coolTime = 10f;
        _isSkill = false;
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
