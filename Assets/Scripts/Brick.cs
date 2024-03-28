using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    [SerializeField] int hp = 1;
    public UnityEvent onDestroy;
    public GameObject particles;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Damage(int damage = 1)
    {
        hp -= damage;
        Instantiate(particles, gameObject.transform.position, Quaternion.identity);
        if (hp <= 0)
        {
            onDestroy.Invoke();
            gm.AddPoints();
            Destroy(gameObject);
        }
    }
}
