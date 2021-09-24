using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private bool _playOnStart = false;

    [Header("Move Info")]
    [SerializeField] private GameObject _platform = null;
    [SerializeField] private List<Transform> _moveNodes = new List<Transform>();
    [SerializeField] private bool _ascending = true;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private int _target = 1;

    [Header("Waiting Info")]
    [SerializeField] private bool _waitAtNodes = false;
    [SerializeField] private bool _waitOnStart = false;
    [SerializeField] private bool _endpointsOnly = false;
    [SerializeField] private float _waitTime = 1.5f;

    private bool _activated = false;
    private bool _forward = false;
    private float _arrivedThres = 0.01f;

    private bool _waiting = false;
    private float _currWait = 0;

    private Vector3 _prevPos = Vector3.zero;
    private Vector3 _currVel = Vector3.zero;

    private bool _playerOn = false;
    private ThirdPersonController _controllerThird = null;
    private FirstPersonController _controllerFirst = null;

    private void Awake()
    {
        _prevPos = _platform.transform.position;
    }

    void Start()
    {
        if(_moveNodes.Count < 2)
        {
            //Debug.LogError("Platform Move requires a minimum of 2 nodes. " + gameObject.name + " was deactivated!");
        }

        if(_waitOnStart && _waitAtNodes)
        {
            _waiting = true;
        }

        _forward = _ascending;
        _activated = _playOnStart;
    }

    void Update()
    {
        if(_activated)
        {
            if(_waiting)
            {
                _currVel = Vector3.zero;

                _currWait += Time.deltaTime;

                if(_currWait > _waitTime)
                {
                    _currWait = 0;
                    _waiting = false;
                }
            }
            else
            {
                _platform.transform.position = Vector3.MoveTowards(_platform.transform.position, _moveNodes[_target].position, _moveSpeed * Time.deltaTime);

                _currVel = _platform.transform.position - _prevPos;
                _prevPos = _platform.transform.position;

                if (Vector3.Distance(_platform.transform.position, _moveNodes[_target].position) < _arrivedThres)
                {
                    if ((_forward && _target + 1 >= _moveNodes.Count) || (!_forward && _target - 1 < 0))
                    {
                        _forward = !_forward;

                        if(_waitAtNodes && _endpointsOnly) { _waiting = true; }
                    }

                    _target = _forward ? _target + 1 : _target - 1;

                    if (_waitAtNodes && !_endpointsOnly) { _waiting = true; }
                }
            }

            if(_playerOn)
            {
                if (_controllerThird != null)
                {
                    _controllerThird.AddPlatformVelocity(_currVel);
                }
                else if (_controllerFirst != null)
                {
                    _controllerFirst.AddPlatformVelocity(_currVel);
                }
            }
        }
    }

    public void Activate()
    {
        _activated = true;
    }

    public void Deactivate()
    {
        _activated = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_controllerThird == null) { _controllerThird = other.gameObject.GetComponent<ThirdPersonController>(); }
            if (_controllerFirst == null) { _controllerFirst = other.gameObject.GetComponent<FirstPersonController>(); }
            _playerOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerOn = false;
        }
    }
}
