using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private float _turnSpeed = 0;
    [SerializeField] private float _turretTurnSpeed = 0;
    [SerializeField] private Transform _turretTransform = null;

    private Rigidbody rigidbody = null;

    private Keyboard _keyboard = null;
    private Mouse _mouse = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        _keyboard = Keyboard.current;
        _mouse = Mouse.current;
    }

    // Update is called once per frame
    void Update()
    {
        //move
        Move();

        //rotate
        Rotate();

        //rotate turret
        RotateTurret();

    }

    private void Move()
    {
        if(_keyboard.wKey.isPressed)
        {
            transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        }
        else if (_keyboard.sKey.isPressed)
        {
            transform.Translate(-Vector3.forward * _moveSpeed * Time.deltaTime);
        }
    }

    private void Rotate()
    {
        if (_keyboard.aKey.isPressed)
        {
            transform.Rotate(-Vector3.up, _turnSpeed * Time.deltaTime);
        }
        else if (_keyboard.dKey.isPressed)
        {
            transform.Rotate(Vector3.up, _turnSpeed * Time.deltaTime);
        }
    }

    private void RotateTurret()
    {
        _turretTransform.Rotate(Vector3.up, _turretTurnSpeed * Time.deltaTime * _mouse.delta.x.ReadValue());
    }

    public void OnProjectileHit(Vector3 dir, float force)
    {
        rigidbody.AddForce(dir * force);
    }

    public void OnLandmineHit(float force)
    {
        rigidbody.AddForce(Vector3.up * force);
    }
}
