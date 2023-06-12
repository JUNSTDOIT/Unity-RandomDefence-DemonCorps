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

    MonHealth _monHP;

    void Start()
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
        if(!_monHP._IsDie)
            Move_By_WayPts();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WayPoint"))
        {
            _nextWayptIdx++;
            Debug.Log("test");
            if (_nextWayptIdx >= 5)
                _nextWayptIdx = 1;
        }
    }
}
