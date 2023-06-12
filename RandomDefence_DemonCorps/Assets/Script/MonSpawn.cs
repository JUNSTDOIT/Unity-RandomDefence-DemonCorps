using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonSpawn : MonoBehaviour
{
    [Header("몬스터 프리팹"), SerializeField]
    GameObject[] _mon;
    float _spawnRateMin = 1f;
    float _spawnRateMax = 2f;
    float _spawnRate;
    float _timeAfterSpawn;
    float _time;
    int _lv = 1;
    void Start()
    {
        _timeAfterSpawn = 0f;
        _spawnRate = Random.Range(_spawnRateMin, _spawnRateMax);
    }
    void CreateMon()
    {
        _timeAfterSpawn += Time.deltaTime;
        if (_timeAfterSpawn >= _spawnRate)
        {
            _timeAfterSpawn = 0f;
            Instantiate(_mon[_lv - 1], transform.position, transform.rotation);
            _spawnRate = Random.Range(_spawnRateMin, _spawnRateMax);
        }
    }

    void Update()
    {
        _time += Time.deltaTime;
        CreateMon();
    }
}
