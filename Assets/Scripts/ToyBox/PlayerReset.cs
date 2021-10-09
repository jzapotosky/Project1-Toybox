using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    [SerializeField] private bool _resetToStart = false;
    [SerializeField] private CharacterController _controller = null;
    [SerializeField] private LayerMask _layerMask;

    private static PlayerReset _instance;
    public static PlayerReset Instance
    {
        get
        {
            if(_instance == null) { _instance = FindObjectOfType<PlayerReset>(); }
            return _instance;
        }
    }

    //Transform Data
    private Vector3 _lastPosition = Vector3.zero;
    private Quaternion _lastRotation = Quaternion.identity;

    void Start()
    {
        RecordTransform();
    }

    void FixedUpdate()
    {
        if (_resetToStart == false && CheckGrounded())
        {
            RecordTransform();
        }
    }

    public void RecordTransform()
    {
        _lastPosition = transform.position;
        _lastRotation = transform.rotation;
    }

    private bool CheckGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + (Vector3.up * 0.3f), Vector3.down, out hit, 0.5f, _layerMask))
        {
            return true;
        }

        return false;
    }

    public void ResetLastPosition()
    {
        _controller.enabled = false;

        transform.position = _lastPosition;
        transform.rotation = _lastRotation;

        _controller.enabled = true;
    }
}
