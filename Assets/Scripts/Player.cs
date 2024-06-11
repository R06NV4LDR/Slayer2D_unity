using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

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
            if(moveDelta.x > 0)
                transform.localScale = Vector3.one;
            else if(moveDelta.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);

            moveDelta = moveDelta.normalized * speed;
            
            // Make this thing move!
            transform.Translate(moveDelta * Time.deltaTime);
    }
}
