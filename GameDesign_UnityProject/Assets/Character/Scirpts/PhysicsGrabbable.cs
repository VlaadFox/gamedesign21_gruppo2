using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PhysicsGrabbable : Grabbable
{
    protected Rigidbody _rigidbody;
    protected Collider _collider;
    public float _pushForce = 10f;

    protected override void Start ()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();

    }

    public override void Grab(GameObject grabber)
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
    }

    public override void Drop()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
    }

    public override void Throw(GameObject caller)
    {
        if (_rigidbody != null)
        {
            _collider.enabled = true;
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce((transform.position - caller.transform.position).normalized * _pushForce, ForceMode.Impulse);
        }
    }
}
