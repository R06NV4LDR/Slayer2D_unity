using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;

    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        //RotateTowardsTarget();
        SetVelocity();
        UpdateAnimationDirection();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
            transform.position =
                Vector2.Lerp(transform.position, _playerAwarenessController.player.transform.position,
                    Time.deltaTime * 0.8f);

            animator.SetBool("walking", true);
        }
        else
        {
            _targetDirection = Vector2.zero;
            animator.SetBool("walking", false);
        }
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


    private void UpdateAnimationDirection()
    {
        if (_targetDirection.x > 0)
        {
            spriteRenderer.flipX = false;
            // transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_targetDirection.x < 0)
        {
            spriteRenderer.flipX = true;
            // transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}