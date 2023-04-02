using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
	public float change;
	private GameObject c;
	void OnEnable() {
		c = GameObject.Find("Carl");
		c.gameObject.GetComponent<Rigidbody2D>().gravityScale = change;
	}
}
