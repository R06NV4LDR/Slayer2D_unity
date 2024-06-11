using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;

    private Animator ani;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
            if (_playerAwarenessController.AwareOfPlayer)
            {
                //_targetDirection = _playerAwarenessController.DirectionToPlayer;
                transform.position =
                    Vector2.Lerp(transform.position, _playerAwarenessController.player.transform.position, Time.deltaTime * 0.8f);
                
                ani.SetBool("walking", true);
            }
            else
            {
                _targetDirection = Vector2.zero;
                ani.SetBool("walking", false);
            }
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    _rigidbody.SetRotation(rotation);

    }

private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidbody.velocity = Vector2.zero;
        }
        else
        {
            _rigidbody.velocity = transform.up * speed;
        }
    }
}
