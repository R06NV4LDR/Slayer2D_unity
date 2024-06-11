using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private Rigidbody2D _rigidbody2D;

    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [SerializeField] 
    private float speed;

    private void Start() 
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            
            // Reset MoveDelta
            moveDelta = new Vector3(x, y, 0);


            Debug.Log("x "+ x);
            Debug.Log("y "+ y);

            //Swap sprite direction, wether you're going right or left
            if (moveDelta.x > 0)
                _spriteRenderer.flipX = false;
            else if(moveDelta.x < 0)
                _spriteRenderer.flipX = true;

            moveDelta = moveDelta.normalized * speed;
            
            // Make this thing move!
            _rigidbody2D.velocity = new Vector2(moveDelta.x * Time.deltaTime, moveDelta.y * Time.deltaTime);
    }
}
