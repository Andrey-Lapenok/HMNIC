using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaControl : MonoBehaviour
{
    private Transform player;
    public float distance, wait, waitb;
    private bool x = false;
    private string _tag;
    void Start()
    {
        player = GameObject.Find("Carl").transform;
        _tag = gameObject.tag;
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= distance && !x) { x = true; StartCoroutine("Wait"); }
        if (player.GetComponent<CharacterControl>().respawn.position == player.position) { x = false; gameObject.tag = _tag;}
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(wait);
        gameObject.tag = "dangerous";
        StartCoroutine("Waitb");
    }
    IEnumerator Waitb()
    {
        yield return new WaitForSecondsRealtime(waitb);
        if (Vector3.Distance(transform.position, player.position) >= distance)
        {
            gameObject.tag = _tag;
            x = false;
        }
        else StartCoroutine("Waitb");
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (gameObject.tag == "dangerous" && collision.gameObject.name == "Carl")
            collision.gameObject.GetComponent<CharacterControl>().StartCoroutine("Death");
    }
}
