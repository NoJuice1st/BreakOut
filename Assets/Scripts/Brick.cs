using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Brick : MonoBehaviour
{
    public int hp = 1;
    public int pointValue = 1;
    public int pointsOnHit = 0;
    public GameObject particles;
    public AudioClip hit;

    public UnityEvent onDestroy;
    private GameManager gm;
    private SpriteRenderer sr;
    private Color originalColor;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void Damage(int damage = 1)
    {
        AudioSystem.Play(hit);
        hp -= damage;
        Instantiate(particles, gameObject.transform.position, Quaternion.identity);
        gm.AddPoints(pointsOnHit);

        sr.DOColor(originalColor + Color.white / 10f, 0.05f).OnComplete(ResetColor);
        if (hp <= 0)
        {
            onDestroy.Invoke();
            gm.AddPoints(pointValue);
            sr.DOColor(Color.white, 0.15f).OnComplete(Byebye);
        }
    }

    private void ResetColor()
    {
        sr.DOColor(originalColor, 0.05f);
    }

    private void Byebye()
    {   
        Destroy(gameObject);
    }
}
