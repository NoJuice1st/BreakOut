using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    public float targetSpeed = 10f;
    public int damage = 1;
    public Transform spawnPoint;

    public UnityEvent onDamageBrick;
    public UnityEvent onHitFloor;
    private Rigidbody2D rb;

    private bool canUnpause = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = Vector2.zero;
        transform.DOScale(1, 0.5f);
    }

    private void Update()
    {
        var prevSpeed = rb.velocity.normalized;
        if (prevSpeed == Vector2.zero) prevSpeed = Vector2.up;
        if(rb.velocity == Vector2.zero) rb.velocity = prevSpeed * targetSpeed;
        else rb.velocity = rb.velocity.normalized * targetSpeed; 
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
            transform.localScale = Vector2.zero;
            transform.position = spawnPoint.position;
            rb.velocity = Vector2.up;
            PauseSelf();
            transform.DOScale(1, 0.5f).OnComplete(UnPauseSelf);
        }
    }

    public void PauseSelf()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void CantUnpause()
    {
        canUnpause = !canUnpause;
    }

    private void UnPauseSelf()
    {
        if(canUnpause)GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
