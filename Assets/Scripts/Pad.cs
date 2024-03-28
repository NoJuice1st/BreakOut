using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    public float speed = 5f;
    public float forceStrength = 2f;

    private Rigidbody2D rb;

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed * direction, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb2))
        {
            rb2.AddForce(new Vector2(0, forceStrength), ForceMode2D.Impulse);
        }
    }
}