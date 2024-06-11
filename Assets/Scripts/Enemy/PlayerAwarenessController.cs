using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField] private bool showRadius = false;
    
    [SerializeField]
    private float playerAwarenessDistance;

    [SerializeField]
    public Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (showRadius)
        {
            Gizmos.color = new Color(1, 1, 0, .5f);
            Gizmos.DrawSphere(transform.position, playerAwarenessDistance);
        }
    }
}
