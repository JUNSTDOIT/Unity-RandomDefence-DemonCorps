using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJAttack : MonoBehaviour
{
    public enum ProjectileType
    {
        None = -1,
        Bullet1,
        Bullet2,
        Bullet3,
        Bullet4,
        Bullet5,
        Bullet6,
        Bullet7,
        Bullet8,
        Bullet9,
        Max
    }
    [SerializeField]
    GameObject _bullet;
    [Header("기본 공격력"), SerializeField]
    float _dmg;
    [Header("공격 범위"), SerializeField]
    float _radius;
    float _time = 0f;
    [Header("공격 속도"), SerializeField]
    float _attackSpeed = 0.25f;

    Dictionary<ProjectileType, GameObjectPool<ProjectileController>> _bulletPool = new Dictionary<ProjectileType, GameObjectPool<ProjectileController>>();
    public void RemoveProjectile(ProjectileController projectile) // Projectile 제거 함수
    {
        projectile.gameObject.SetActive(false); // Projectile 비활성화
        _bulletPool[projectile._Type].Set(projectile); // projectile을  m_projectilePool에 환원
    }
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
                bullet.GetComponent<ProjectileController>().Target(cols[0].transform);
                bullet.GetComponent<ProjectileController>().Dmg(_dmg);
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