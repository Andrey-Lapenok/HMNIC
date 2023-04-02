using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    public float minAlpha = 0;
    public float speed = 0.01f;
    private Color colorOfEnd;

    void Start()
    {
        colorOfEnd = new Color(255f, 255f, 255f, minAlpha);
    }
    void Update()
    {
        foreach (Transform i in transform)
        {
            i.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(i.gameObject.GetComponent<SpriteRenderer>().color, colorOfEnd, speed);
            if (i.gameObject.GetComponent<SpriteRenderer>().color[3] <= 0.01f) Destroy(gameObject);
        }

    }
}
