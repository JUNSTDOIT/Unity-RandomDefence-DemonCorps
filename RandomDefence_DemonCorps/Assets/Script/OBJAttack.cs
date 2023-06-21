using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJAttack : MonoBehaviour
{
    public enum UnitType
    {
        None = -1,
        Legend,
        Myth,
        God,
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
    UnitType _unitType = UnitType.None;
    float _curDmg;
    GameObject _allAttack;
    GameObject _slowAttack;
    GameObject _multiAttack;
    float _allAttackTime = 0f;
    float _slowAttackTime = 0f;
    float _multiAttackTime = 0f;

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
        switch (_unitType)
        {
            case UnitType.Legend:
                _multiAttack = Instantiate(Resources.Load<GameObject>("Prefab/Skill/MultiAttack"));
                if (_multiAttack != null)
                    _multiAttack.SetActive(false);
                break;
            case UnitType.Myth:
                _slowAttack = Instantiate(Resources.Load<GameObject>("Prefab/Skill/SlowAttack"));
                if (_slowAttack != null)
                    _slowAttack.SetActive(false);
                break;
            case UnitType.God:
                _allAttack = Instantiate(Resources.Load<GameObject>("Prefab/Skill/AllAttack"));
                if (_allAttack != null)
                    _allAttack.SetActive(false);
                break;
            default:
                break;
        }
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
        switch (_unitType)
        {
            case UnitType.Legend:
                _multiAttackTime += Time.deltaTime;
                if(_multiAttackTime >= 3f && cols.Length > 0)
                {
                    _multiAttack.SetActive(true);
                    _multiAttack.GetComponent<ParticleSystem>().Play();
                    _multiAttackTime = 0f;
                    _multiAttack.transform.position = cols[0].transform.position;
                    Collider[] col = Physics.OverlapSphere(_multiAttack.transform.position, 5f, 1 << 3);
                    if (col.Length > 0)
                        for (int i = 0; i < col.Length; i++)
                            col[i].GetComponent<MonHealth>().Damage(_curDmg + _curDmg * 1f * UIManager.Instance._ReinforcementLv);
                }
                break;
            case UnitType.Myth:
                _slowAttackTime += Time.deltaTime;
                if(_slowAttackTime >= 10f && cols.Length > 0)
                {
                    _slowAttack.SetActive(true);
                    _slowAttack.GetComponent<ParticleSystem>().Play();
                    _slowAttackTime = 0f;
                    cols[0].GetComponent<MonCtrl>().SetMoveSpeed(0f);
                    cols[0].GetComponent<MonHealth>().Damage(_curDmg + _curDmg * 1f * UIManager.Instance._ReinforcementLv);
                    _slowAttack.transform.position = cols[0].transform.position;
                }
                break;
            case UnitType.God:
                _allAttackTime += Time.deltaTime;
                if (_allAttackTime >= 1f && cols.Length > 0)
                {
                    _allAttack.SetActive(true);
                    _allAttack.GetComponent<ParticleSystem>().Play();
                    _allAttackTime = 0f;
                    Collider[] col = Physics.OverlapSphere(_allAttack.transform.position, _radius, 1 << 3);
                    for (int i = 0; i < col.Length; i++)
                            col[i].GetComponent<MonHealth>().Damage(_curDmg + _curDmg * 1f * UIManager.Instance._ReinforcementLv);
                }
                break;
            default:
                break;
        }
    }
    ProjectileController CreateProjectile()
    {
        var projectile = _projectilePool[_bullet.name + "(Clone)"].Get();
        projectile.gameObject.SetActive(true);
        return projectile;
    }
}