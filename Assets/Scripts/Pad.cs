using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    public float speed = 5f;
    public float forceStrength = 2f;
    public AudioClip padHit;

    private Animator animator;
    private Rigidbody2D rb;

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if(!rb.isKinematic)rb.velocity = new Vector2(speed * direction, 0);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb2))
        {
            if(Random.Range(1, 11) == 7) animator.Play("PlayerBlink");
            AudioSystem.Play(padHit);
            rb2.AddForce(new Vector2(Random.Range(-0.3f, 0.3f), forceStrength), ForceMode2D.Impulse);
        }
    }
}
