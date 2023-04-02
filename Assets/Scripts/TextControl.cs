using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    public GameObject player;
    public bool active = false;
    private bool a = true;
    public string txt;
    public Transform aim;
    public Text label;
    public Text enter;
    public Text enter1;
    public Transform _camera;
    private float time = 0.04f;
    private int count = 1;
    private int count1 = 0;

    IEnumerator Wait()
    {
        if (count1 + count <= txt.Length)
        {
            if (txt[count1 + count - 1].ToString() == " ")
            {
                label.text = txt.Substring(count1, count) + "<color=#ffffff00>" + txt.Substring(count1 + count) + "</color>"; count += 1;
            }
            if (txt[count1 + count - 1].ToString() == "$")
            {
                enter.gameObject.SetActive(true);
                a = false;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enter.gameObject.SetActive(false);
                    label.text = "";
                    count1 += count;
                    count = 1;
                }
            }
            else
            {
                label.text = txt.Substring(count1, count) + "<color=#ffffff00>" + txt.Substring(count1 + count) + "</color>"; count += 1;
                a = true;
                yield return new WaitForSecondsRealtime(time);
            }
            if (Input.GetKey(KeyCode.Return) && a)
            {
                time = 0;
            }
            else
            {
                time = 0.04f;
            }
            yield return new WaitForSecondsRealtime(0);
            StartCoroutine("Wait");
        }
        else
        {
            enter1.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                enter1.gameObject.SetActive(false);
                count = 1; count1 = 0;
                label.text = "";
                active = false;
            }
            else
            {
                yield return new WaitForSecondsRealtime(0);
                StartCoroutine("Wait");
            }

        }
    }
    public void StartDialouge() { active = true; StartCoroutine("Wait"); }

    void Update()
    {
        switch (active)
        {
            case true:
                transform.position = Vector3.Lerp(transform.position, new Vector3(_camera.position.x, _camera.position.y, _camera.position.z + 7), Time.deltaTime * 7);
                player.GetComponent<CharacterControl>().enabled = false; break;
            default:
                transform.position = Vector3.Lerp(transform.position, new Vector3(_camera.position.x, _camera.position.y - 10f, _camera.position.z), Time.deltaTime * 7);
                player.GetComponent<CharacterControl>().enabled = true; label.text = null; break;
        }
    }
}