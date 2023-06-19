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
    [SerializeField]
    Transform _body;
    [SerializeField]
    Transform _firePos;
    [Header("기본 공격력"), SerializeField]
    float _dmg;
    [Header("공격 범위"), SerializeField]
    float _radius;
    float _time = 0f;
    [Header("공격 속도"), SerializeField]
    float _attackSpeed = 0.25f;
    [SerializeField]
    public ProjectileType _projectileType;
    float _curDmg;

    Dictionary<string, GameObjectPool<ProjectileController>> _projectilePool = new Dictionary<string, GameObjectPool<ProjectileController>>();
    public void RemoveProjectile(ProjectileController projectile)
    {
        projectile.gameObject.SetActive(false);
        _projectilePool[projectile.name].Set(projectile);
    }
    void Start()
    {
        var pool = new GameObjectPool<ProjectileController>(3, () =>
        {
            var obj = Instantiate(_bullet);
            obj.SetActive(false);
            obj.transform.SetParent(transform);
            var projectile = obj.GetComponent<ProjectileController>();
            return projectile;
        });
        _projectilePool.Add(_bullet.name + "(Clone)", pool);
        _curDmg = _dmg;
    }

    void Update()
    {
        Collider[] cols = Physics.OverlapSphere(_body.position, _radius, 1 << 3);
        if(cols.Length > 0)
        {
            _time += Time.deltaTime;
            if(_time > _attackSpeed)
            {
                _dmg = _curDmg + _curDmg * 0.25f * UIManager.Instance._ReinforcementLv;
                _body.LookAt(cols[0].transform);
                GameObject bullet = CreateProjectile().gameObject;
                bullet.GetComponent<ProjectileController>().Target(cols[0].transform);
                bullet.GetComponent<ProjectileController>().Dmg(_dmg);
                bullet.transform.position = _firePos.position;
                bullet.transform.rotation = _firePos.rotation;
                _time = 0;
            }
        }
    }
    ProjectileController CreateProjectile()
    {
        var projectile = _projectilePool[_bullet.name + "(Clone)"].Get();
        projectile.gameObject.SetActive(true);
        return projectile;
    }
}