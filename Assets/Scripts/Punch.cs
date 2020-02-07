using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rBody;

    [SerializeField]
    private float _timeOffset = 0;
    private float _interval = 3;
    private float _endPosOffset = 2;

    private Vector3 _startPos;
    private Vector3 _endPos;
     
    void Start()
    {
        _startPos = transform.position;
        _endPos = transform.position + (transform.right * _endPosOffset);

        if(_timeOffset > 0)
        {
            StartCoroutine(WaitToBox());
        }
        else
        {
            StartCoroutine(Boxer());
        }
    }
    private IEnumerator WaitToBox()
    {
        yield return new WaitForSeconds(_timeOffset);
        StartCoroutine(Boxer());
    }
    private IEnumerator Boxer()
    {
        yield return new WaitForSeconds(_interval);

        float _frac = 0.01f;
        float _speed = 2;

        while (_frac > 0.0f)
        {
            yield return new WaitForFixedUpdate();

            _frac += _speed * Time.deltaTime;

            _rBody.MovePosition(Vector3.Lerp(_startPos, _endPos, _frac));

            if(_frac >= 1.0f)
            {
                _speed = -_speed;
            }
        }

        StartCoroutine(Boxer());
    }
}
