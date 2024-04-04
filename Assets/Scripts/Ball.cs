using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public float targetSpeed = 10f;
    public int damage = 1;
    public Transform spawnPoint;

    public UnityEvent onDamageBrick;
    public UnityEvent onHitFloor;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * targetSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Brick"))
        {
            onDamageBrick.Invoke();
            collision.gameObject.GetComponent<Brick>().Damage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Danger"))
        {
            onHitFloor.Invoke();
            transform.position = spawnPoint.position;

        }
    }
}
