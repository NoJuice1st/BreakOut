using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public int hp = 1;
    public int pointValue = 1;
    public int pointsOnHit = 0;
    public GameObject particles;
    public AudioClip hit;

    public UnityEvent onDestroy;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Damage(int damage = 1)
    {
        AudioSystem.Play(hit);
        hp -= damage;
        Instantiate(particles, gameObject.transform.position, Quaternion.identity);
        gm.AddPoints(pointsOnHit);
        if (hp <= 0)
        {
            onDestroy.Invoke();
            gm.AddPoints(pointValue);
            Destroy(gameObject);
        }
    }
}
