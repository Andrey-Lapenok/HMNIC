using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	public Quaternion to;
	public float speed;
	private int a = 0;
	private GameObject c, cameraV;

	void Start() => cameraV = GameObject.Find("CM vcam1");
	public void Change(Quaternion t, float s) {
		to = t;
		speed = s;
		a += 1;
		StartCoroutine("Wait");
		StartCoroutine("Rotate");
	}
	IEnumerator Wait() {
        yield return new WaitForSecondsRealtime(2f);
        a -= 1;
    }
    IEnumerator Rotate() {
    	yield return null;

    	if (a > 0) {
    		cameraV.transform.rotation = Quaternion.Lerp(cameraV.transform.rotation, to, speed * 1.5f);
    		StartCoroutine("Rotate");
    	}
    }
}
