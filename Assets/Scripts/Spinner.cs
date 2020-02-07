using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rBody;

    private float _angle = 1.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        _rBody.MoveRotation(Quaternion.AngleAxis(_rBody.rotation.y + _angle, -Vector3.up));
        _angle += 1;

        if(_angle == 360) { _angle = 0;  }
    }
}
