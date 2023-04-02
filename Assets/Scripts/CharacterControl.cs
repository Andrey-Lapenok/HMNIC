using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{
	public float crystals = 0;
	public Animation death;
	public Animator anim;
	public Camera _camera;
	public GameObject _cameraV;
	public GameObject arrow;
	public Transform respawn;
	public float speed, r;
	public bool a, c, ray;
	private float force;
	private GameObject d;
	private bool b;
	private int n = 0;
	private bool x = true;
	private Vector3 s_, s, rayD;
	private Collision2D col;
	private Vector3 mousePos;
	private Vector2 angle;

	void Start()
	{
		death = GetComponent<Animation>();
		anim = GetComponent<Animator>();
		d = GameObject.Find("Dialouge");
	}
	void Update()
	{
		_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12));
		angle = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12)) - transform.position;

		arrow.transform.eulerAngles = new Vector3(0, 0, (angle[0] > 0 ? -1 : 1) * Vector2.Angle(Vector2.up, angle) + (r == 0 ? 0 : 90f * r));
		if (Input.GetKey(KeyCode.Mouse0) && !anim.GetBool("dead"))
        {
            arrow.SetActive(true);
            arrow.transform.position = new Vector3(transform.position.x, transform.position.y, -2);
            arrow.transform.localScale = new Vector3(1f, Mathf.Min(angle.magnitude, 2.4f) / 2, 0);

			force = Mathf.Min(angle.magnitude, 2.4f);
		}
		if (Input.GetKey(KeyCode.Space)) {force = 0f; arrow.SetActive(false);}
		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			if (a && gameObject.GetComponent<Rigidbody2D>().velocity.magnitude <= 18)
			{
				gameObject.GetComponent<Rigidbody2D>().AddForce(angle.normalized * force * 4.2f , ForceMode2D.Impulse);
				//gameObject.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePosition;
				//gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
				//gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0000001f, 0.0000001f), ForceMode2D.Impulse);
				//b = false;
			}
			force = 0;
			arrow.SetActive(false);	
		}
		if (Input.GetKeyDown(KeyCode.R)) {StartCoroutine("Death");}

		if (Input.GetKey(KeyCode.LeftShift) && b)
		{
			gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
			gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
		}
		else
		{
			gameObject.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePosition;
			gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0000001f, 0.0000001f), ForceMode2D.Impulse);
		}
	}
	void OnCollisionEnter2D(Collision2D collision) 
	{	
		if (collision.transform.tag == "dangerous"){
			StartCoroutine("Death");		
		}
		else
        {
			col = collision;
		}
		switch (ray) {
			case true:
				rayD = Vector3.up;
				break;
			case false:
				rayD = Vector3.right;
				break;

		}
	}
	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.transform.tag == "platform") { transform.SetParent(collision.transform); c = true;}
		else {transform.SetParent(null); c = false;}
		a = true;
		if ((Physics2D.Raycast(transform.position, rayD, 0.5f) || Physics2D.Raycast(transform.position, -rayD, 0.5f))) {
			b = true;}
		else b = false;
	}

	void OnCollisionExit2D(Collision2D collision) {
		a = false;
		b = false;
		transform.SetParent(null);
		//StartCoroutine("wV");
		//if (collision.gameObject.tag == "platform"){gameObject.GetComponent<Rigidbody2D>().AddForce(s.normalized * s.magnitude / 10f, ForceMode2D.Impulse);}
	}

	void OnTriggerEnter2D(Collider2D collider) {
        if (collider.transform.tag == "text")
        {
            arrow.transform.localScale = new Vector3(0, 0, 0); force = 0;
            d.GetComponent<TextControl>().txt = collider.gameObject.GetComponent<Text>().text;
            d.GetComponent<TextControl>().StartDialouge();
            Destroy(collider.gameObject, 1.25f);
        }
		else if (collider.transform.tag == "Event") collider.gameObject.GetComponent<MonoBehaviour>().enabled = true;
		else if (collider.transform.tag == "respawn") respawn = collider.transform;
        else if (collider.transform.tag == "frame") _camera.GetComponent<CameraControl>().frame = collider.transform;
	}
	void OnTriggerExit2D(Collider2D collider) {
		if (collider.transform.tag == "Event") collider.gameObject.GetComponent<MonoBehaviour>().enabled = false;
	}
	void OnTriggerStay2D(Collider2D collider) {
		if (collider.transform.tag == "arch" && Input.GetKey(KeyCode.E)) n++;
		if (n == 1 && x) {
			switch (collider.gameObject.GetComponent<ArchControl>().levelOrScene)
			{
				case "level":
					_camera.GetComponent<CameraControl>().frame = collider.gameObject.GetComponent<ArchControl>().To.gameObject.GetComponent<ArchControl>().frame;
					_camera.gameObject.GetComponent<CameraControl>().CameraTeleport(collider.gameObject.GetComponent<ArchControl>().slowOrFast);
					transform.position = new Vector3(collider.gameObject.GetComponent<ArchControl>().To.position.x, collider.gameObject.GetComponent<ArchControl>().To.position.y - collider.transform.lossyScale[1], -0.1f);
					gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
					gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
					transform.rotation = new Quaternion(0, 0, 0, 0);
					//while (!Physics2D.Raycast(transform.position, Vector3.down, 0.1f)) { transform.Translate(0, -0.1f, 0); print(1); } пока не работает
					x = false;
					StartCoroutine("Wait");
					break;
				case "scene":
					SceneManager.LoadScene(collider.gameObject.GetComponent<ArchControl>().scene);
					break;
			}
		}
		if (!Input.GetKey(KeyCode.E)) n = 0;
	}
	IEnumerator Wait()
	{
		yield return new WaitForSecondsRealtime(0.5f);
		x = true;
	}
	IEnumerator Death()
	{
		anim.SetBool("dead", true);
		arrow.SetActive(false);
		gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		yield return new WaitForSecondsRealtime(0.33f);
		transform.position = respawn.transform.position;
		transform.rotation = respawn.transform.rotation;
		gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		anim.SetBool("dead", false);
	}
	//IEnumerator wV()
	//{
	//	s_ = col.transform.position;
	//	yield return new WaitForSecondsRealtime(0.1f);
	//	s = s_ - col.transform.position;
	//}
}