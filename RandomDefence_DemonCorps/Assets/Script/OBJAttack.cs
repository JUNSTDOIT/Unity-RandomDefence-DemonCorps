using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJAttack : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet;
    [Header("기본 공격력"), SerializeField]
    float _dmg;
    [Header("공격 범위"), SerializeField]
    float _radius;
    float _time = 0f;
    [Header("공격 속도"), SerializeField]
    float _attackSpeed = 0.25f;

    void Start()
    {

    }

    void Update()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, _radius, 1 << 3);
        if(cols.Length > 0)
        {
            _time += Time.deltaTime;
            if(_time > _attackSpeed)
            {
                transform.LookAt(cols[0].transform);
                GameObject bullet = Instantiate(_bullet);
                bullet.GetComponent<BulletCtrl>().Target(cols[0].transform);
                bullet.GetComponent<BulletCtrl>().Dmg(_dmg);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                Destroy(bullet, 2f);
                _time = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(_bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            Destroy(bullet, 2f);
        }
    }
}