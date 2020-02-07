using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _speed;

    private Vector3 _offset;
    private Vector3 _velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _offset = new Vector3(0, 5, -7);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 _targetPos = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, _targetPos, ref _velocity, 0.3f, 5.0f);
    }
}
