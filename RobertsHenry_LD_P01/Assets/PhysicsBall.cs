using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBall : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] GameObject _wallLeft;
    [SerializeField] GameObject _wallRight;
    [SerializeField] GameObject _particleParent;

    Rigidbody _rigidbody;
    Vector3 _startLoction;
    Quaternion _startRotation;
    float _move = 0.1f;
    float _newTranslate = 0;
    bool _isMoving = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startLoction = transform.position;
        _startRotation = this.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            _particleParent.transform.position = transform.position;
            _particleSystem.Play();
            _isMoving = true;
        } else if (other.gameObject.CompareTag("Goal"))
        {
            _particleParent.transform.position = transform.position;
            _particleSystem.Play();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            transform.position = _startLoction;
            transform.localRotation = Quaternion.identity;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        //_newTranslate += _move * Time.deltaTime;
        MoveWalls();
    }

    private void MoveWalls()
    {
        if (_isMoving)
        {
            _newTranslate += _move * Time.fixedDeltaTime;
            _wallLeft.transform.position = new Vector3(_wallLeft.transform.position.x, _wallLeft.transform.position.y, _wallLeft.transform.position.z - _newTranslate);

            _wallRight.transform.position = new Vector3(_wallRight.transform.position.x + _newTranslate, _wallRight.transform.position.y, _wallRight.transform.position.z);

            if (_newTranslate >= 0.25f)
            {
                _isMoving = false;
            }
        }
    }
}
