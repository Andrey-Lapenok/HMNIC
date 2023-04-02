using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    public Transform[] Trajectory = new Transform[1];
    public float speed = 2f;
    private Transform c;
    private Rigidbody2D rb;
    private int i = 0;

    public enum typeM {_return = 1, _respawn = 2};
    public typeM typeOfMovement;

    void Start()
    {
        c = GameObject.Find("Carl").transform;
        //rb = c.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        switch (typeOfMovement)
        {
            case typeM._return:
                if (transform.position == Trajectory[i].position) {
                	//if (i == 0 && c.parent) {rb.AddForce(new Vector2(Trajectory[i].position.x - Trajectory[Trajectory.Length - 1].position.x, 
                	//	Trajectory[i].position.y - Trajectory[Trajectory.Length - 1].position.y).normalized * speed, ForceMode2D.Impulse);}
                	//else if (c.parent) {rb.AddForce(new Vector2(Trajectory[i].position.x - Trajectory[i-1].position.x, 
                	//	Trajectory[i].position.y - Trajectory[i-1].position.y).normalized * speed, ForceMode2D.Impulse);}
                    if (i >= Trajectory.Length - 1) 
                    {
                    	i = -1;
	                }
                    i++;
                    c.SetParent(null);
                }
                transform.position = Vector3.MoveTowards(transform.position, Trajectory[i].position, Time.deltaTime * speed);
                break;
            case typeM._respawn:
                if (transform.position == Trajectory[i].position){
                    if (i >= Trajectory.Length - 1) {
                        i = -1;
                        transform.position = Trajectory[i].position;
                    }
                    i++;
                }
                transform.position = Vector3.MoveTowards(transform.position, Trajectory[i].position, Time.deltaTime * speed);
                break;
        }
        // if (rb.velocity != new Vector2(0, 0)) c.SetParent(null);
    }
}