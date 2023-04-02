using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappearing : MonoBehaviour
{
    public float timeOfLife;
    public float timeOfDeath;
    public float timeOfWaiting = 0;
    private bool n = false;
    IEnumerator cycle() {
        if (!n)
        {
            yield return new WaitForSecondsRealtime(timeOfDeath);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                transform.GetChild(i).gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            }
            n = true;
        }
        else
        {
            yield return new WaitForSecondsRealtime(timeOfLife);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                transform.GetChild(i).gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            }
            n = false;
        }
        StartCoroutine("cycle");
    }

    void Start() => StartCoroutine("waiting");

    IEnumerator waiting()
    {
        yield return new WaitForSecondsRealtime(timeOfWaiting);
        StartCoroutine("cycle");
    }
}