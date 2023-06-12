using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJMove : MonoBehaviour
{
    Rigidbody _rigid;
    bool _isDragging = false;
    bool _isMove = false;
    Vector3 _offset;
    Vector3 _curPosition;
    OBJAttack _attack;

    void OnMouseDown()
    {
        _attack.enabled = false;
        _offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(gameObject.transform.position).z));
        _isDragging = true;
    }

    void OnMouseDrag()
    {
        if (_isDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(gameObject.transform.position).z);
            _curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
            //transform.position = curPosition;
        }
    }

    void OnMouseUp()
    {
        _isDragging = false;
        _isMove = true;
    }
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _attack = GetComponent<OBJAttack>();
    }
    void FixedUpdate()
    {
        float dist = Vector3.Distance(transform.position, _curPosition);
        if (dist < 0.1f)
        {
            _isMove = false;
            _attack.enabled = true;
        }
        Debug.Log(dist);
        if (_isMove && !_isDragging)
        {
            //transform.position = Vector3.Lerp(transform.position, _curPosition, 0.005f);
            //transform.position = Vector3.MoveTowards(transform.position, _curPosition, 0.05f);
            //_rigid.velocity = _curPosition;
            Vector3 dir = _curPosition - transform.position;
            dir.Normalize();
            _rigid.AddForce(dir * dist * 100f);
            _isMove = false;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Wall"))
        {
            _attack.enabled = true;
        }
    }
    
    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            _isMove = false;
        }
    }
    */
}
