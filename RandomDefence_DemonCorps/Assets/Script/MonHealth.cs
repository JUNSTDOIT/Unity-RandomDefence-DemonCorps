using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonHealth : MonoBehaviour
{
    [SerializeField]
    Slider _sliderHP;
    [SerializeField]
    float _hp;
    bool _isDie = false;
    public bool _IsDie => _isDie;
    public void SetHP(int hp)
    {
        _hp = hp;
        _isDie = false;
        GetComponent<Animator>().SetBool("Die", false);
        GetComponent<BoxCollider>().enabled = true;
    }
    public void Damage(float dmg) => _hp -= dmg;
    void Start()
    {
        _sliderHP.maxValue = _hp;
    }
    void Die()
    {
        _isDie = true;
        GetComponent<Animator>().SetBool("Die", true);
        GetComponent<BoxCollider>().enabled = false;
        UIManager.Instance.GetMoney();
    }
    void Update()
    {
        _sliderHP.value = _hp;
        if (_hp <= 0 && !_isDie)
            Die();
    }
}
