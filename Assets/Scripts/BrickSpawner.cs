using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brick;
    public int count;
    public float interval;
    public Color customColor = Color.black;


    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            var instBrick = Instantiate(brick, transform.position + Vector3.right * interval * i, Quaternion.identity);
            
            if(customColor != Color.black)
            {
                instBrick.GetComponent<SpriteRenderer>().color = customColor;
            }
        }
    }
}
