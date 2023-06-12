using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [SerializeField]
    float _speed = 15f;
    [SerializeField]
    bool _useFirePointRotation;
    [SerializeField]
    Vector3 _rotationOffset = new Vector3(0, 0, 0);
    [SerializeField]
    GameObject _hit;
    [SerializeField]
    GameObject _flash;
    Rigidbody _rb;
    [SerializeField]
    GameObject[] _detached;
    Transform _target;
    float _dmg;
    public void Dmg(float dmg) => _dmg = dmg;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_flash != null)
        {

            var flashInstance = Instantiate(_flash, transform.position, Quaternion.identity);
            flashInstance.transform.forward = gameObject.transform.forward;


            var flashPs = flashInstance.GetComponent<ParticleSystem>();
            if (flashPs != null)
            {
                Destroy(flashInstance, flashPs.main.duration);
            }
            else
            {
                var flashPsParts = flashInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(flashInstance, flashPsParts.main.duration);
            }
        }
        Destroy(gameObject, 5);
    }
    public void Target(Transform target)
    {
        _target = target;
    }
    void FixedUpdate()
    {
        if (_target != null)
        {
            //rb.velocity = transform.forward * speed;
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            transform.LookAt(_target);
        }
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monster"))
        {
            _rb.constraints = RigidbodyConstraints.FreezeAll;

            if (_hit != null)
            {
                var hitInstance = Instantiate(_hit, transform.position, transform.rotation);
                if (_useFirePointRotation) { hitInstance.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180f, 0); }
                else if (_rotationOffset != Vector3.zero) { hitInstance.transform.rotation = Quaternion.Euler(_rotationOffset); }
                else { hitInstance.transform.LookAt(other.transform); }


                var hitPs = hitInstance.GetComponent<ParticleSystem>();
                if (hitPs != null)
                {
                    Destroy(hitInstance, hitPs.main.duration);
                }
                else
                {
                    var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(hitInstance, hitPsParts.main.duration);
                }
            }

            foreach (var detachedPrefab in _detached)
            {
                if (detachedPrefab != null)
                {
                    detachedPrefab.transform.parent = null;
                }
            }
            other.GetComponent<MonHealth>().Damage(_dmg);
            Destroy(gameObject);
        }
    }
}
