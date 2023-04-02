using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumbling : MonoBehaviour
{
    public float wait;
    public float waitb;
    private Transform c;
    private Transform respawn;
    private bool n = false;

    public enum typeR { _respawn = 1, _notrespawn = 2 };
    public typeR typeOfRespawn;

    void Start()
    {
        c = GameObject.Find("Carl").transform;
        respawn = GameObject.Find("Respawn").transform;
    }
    void Update()
    {
        if (respawn.position == c.position){
            n = false;
            for (int i = 0; i < transform.childCount; i++) transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(wait);
        if (n)
        {
            for (int i = 0; i < transform.childCount; i++) transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
        switch (typeOfRespawn)
        {
            case typeR._respawn:
                yield return new WaitForSecondsRealtime(waitb);
                for (int i = 0; i < transform.childCount; i++) transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<PolygonCollider2D>().enabled = true; break;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Carl"){
            n = true;
            StartCoroutine("Wait");
        }
    }
}