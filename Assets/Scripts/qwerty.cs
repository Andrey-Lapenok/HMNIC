using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qwerty : MonoBehaviour
{
    [SerializeField] private AnimationCurve a;
    public Transform[] Trajectory = new Transform[1];
    public float speed = 2f, currentTime, totalTime;
    private Transform c;
    private Rigidbody2D rb;
    private int i = 0;

    public enum typeM { _return = 1, _respawn = 2 };
    public typeM typeOfMovement;

    void Start()
    {
        totalTime = a.keys[a.keys.Length - 1].time;
        c = GameObject.Find("Carl").transform;
        //rb = c.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        currentTime += Time.deltaTime * speed;
        switch (typeOfMovement)
        {
            case typeM._return:
                if (currentTime >= totalTime)
                {
                    currentTime = 0;
                    print(1);
                    if (i >= Trajectory.Length - 1)
                    {
                        i = -1;
                    }
                    i++;
                    c.SetParent(null);
                }
                if (i != 0)
                {
                    transform.position = Vector3.Lerp(Trajectory[i - 1].position, Trajectory[i].position, a.Evaluate(currentTime));
                    // print(Trajectory[i - 1].name);
                    // print(Trajectory[i].name);
                }
                else 
                {
                    transform.position = Vector3.Lerp(Trajectory[Trajectory.Length - 1].position, Trajectory[i].position, a.Evaluate(currentTime));
                    //print(Trajectory[Trajectory.Length - 1].name);
                    //print(Trajectory[i].name);
                }
                break;
            case typeM._respawn:
                if (transform.position == Trajectory[i].position)
                {
                    if (i >= Trajectory.Length - 1)
                    {
                        i = -1;
                        transform.position = Trajectory[i].position;
                    }
                    i++;
                }
                transform.position = Vector3.Lerp(Trajectory[i - 1].position, Trajectory[i].position, a.Evaluate(currentTime));
                break;
        }
        // if (rb.velocity != new Vector2(0, 0)) c.SetParent(null);
    }
}
