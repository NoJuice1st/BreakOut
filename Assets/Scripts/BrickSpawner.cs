using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brick;
    public int count;
    public float interval;
    public int health = 1;
    public int pointValue = 1;
    public int pointsOnHit = 0;
    public Color customColor = Color.black;


    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            var instBrick = Instantiate(brick, transform.position + Vector3.right * interval * i, Quaternion.identity);
            Brick br;
            br = instBrick.GetComponent<Brick>();
            br.hp = health;
            br.pointValue = pointValue;
            br.pointsOnHit = pointsOnHit;

            instBrick.transform.SetParent(transform);
            if(customColor != Color.black)
            {
                instBrick.GetComponent<SpriteRenderer>().color = customColor;
            }
        }
    }
}
