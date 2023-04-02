using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizon1GravityChange : MonoBehaviour
{
	private GameObject c, cameraV, rotator;
	public Vector2 move = new Vector2(0.5f, 0);
	private float r1;
	public bool change = true, r;

 	void Update() {
		c.GetComponent<Rigidbody2D>().AddForce(move, ForceMode2D.Force);
	}
	void OnEnable() {
		c = GameObject.Find("Carl");
		rotator = GameObject.Find("rotator");
		cameraV = GameObject.Find("CM vcam1");
		r1 = Convert.ToSingle(r);
		r1 = r1 + (r1 - 1f);
		// move *= r1;
		rotator.GetComponent<Rotator>().Change(new Quaternion(0, 0, r1, 1f), 0.01f);
		c.GetComponent<Rigidbody2D>().gravityScale = 0;
		c.GetComponent<CharacterControl>().r = r1;
		if (change) c.GetComponent<CharacterControl>().ray = true;
	}
	void OnDisable() {
		c.GetComponent<Rigidbody2D>().gravityScale = 1;
		rotator.GetComponent<Rotator>().Change(new Quaternion(0, 0, 0, 1f), 0.01f);
		c.GetComponent<CharacterControl>().r = 0;
		// move = new Vector2(0.5f, 0);
		if (change) c.GetComponent<CharacterControl>().ray = false;
	}
}
