using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rBody;

    private Vector3 _moveDir;

    private bool _moving = false;

    void Start()
    {
        _moveDir = transform.forward;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            if (!_moving)
            {
                StartCoroutine(Movement());
            }
        }
        else
        {
            _moving = false;
        }
    }

    private IEnumerator Movement()
    {
        _moving = true;

        float _speed = 15;
        float _maxVel = 5;

        while (_moving)
        {
            yield return new WaitForFixedUpdate();

            if (_rBody.velocity.magnitude < _maxVel)
            {
                _rBody.AddForce(_moveDir * _speed);
            }
        }
        while (_rBody.velocity.magnitude > 0.5f)
        {
            yield return new WaitForFixedUpdate();

            _rBody.AddForce(-_moveDir * _rBody.velocity.magnitude);

            if (_moving) { break; }
        }
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "finishFloor")
        {
            StartCoroutine(Finished());
        }
        if(collision.transform.tag == "dieZone")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
    private IEnumerator Finished()
    {
        yield return new WaitForSeconds(0.5f);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


}
