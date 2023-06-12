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
    public void Damage(float dmg) => _hp -= dmg;
    void Start()
    {
        _sliderHP.maxValue = _hp;
    }
    void Die()
    {
        _isDie = true;
        GetComponent<Animator>().SetTrigger("Die");
        GetComponent<BoxCollider>().enabled = false;
    }
    void Update()
    {
        _sliderHP.value = _hp;
        if (_hp <= 0)
        {
            Die();
            Destroy(gameObject, 1f);
        }
    }
}
