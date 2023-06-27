using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonHealth : MonoBehaviour
{
    [SerializeField]
    GameObject _bloodFX;
    [SerializeField]
    Slider _sliderHP;
    [SerializeField]
    float _hp;
    bool _isDie = false;
    public bool _IsDie => _isDie;
    public void HPUP(int hpup) => _hp += hpup;
    public void SetHP(int hp)
    {
        _hp = hp;
        _isDie = false;
        GetComponent<Animator>().SetBool("Die", false);
        GetComponent<BoxCollider>().enabled = true;
        _bloodFX.SetActive(false);
    }
    public void Damage(float dmg) => _hp -= dmg;
    void Start()
    {
        _sliderHP.maxValue = _hp;
    }
    void Die()
    {
        AudioManager.Instance.MonPain();
        _isDie = true;
        GetComponent<Animator>().SetBool("Die", true);
        GetComponent<BoxCollider>().enabled = false;
        if (GetComponent<MonCtrl>()._Type == MonsterManager.MonsterType.Lv6)
            UIManager.Instance.GetMoney(200);
        else if(GetComponent<MonCtrl>()._Type == MonsterManager.MonsterType.Lv12)
            UIManager.Instance.GetMoney(200);
        else
            UIManager.Instance.GetMoney(1);
        _bloodFX.SetActive(true);
    }
    void Update()
    {
        _sliderHP.value = _hp;
        if (_hp <= 0 && !_isDie)
            Die();
    }
}
