using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public float targetSpeed = 10f;
    public int damage = 1;

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
        if(collision.gameObject.name.Contains("Floor"))
        {
            onHitFloor.Invoke();
            transform.position = Vector2.zero;
        }
    }
}
