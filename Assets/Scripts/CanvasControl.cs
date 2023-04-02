using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControl : MonoBehaviour
{
    private GameObject player;
    private GameObject UI_2;
    void Start()
    {
        player = GameObject.Find("Carl");
        UI_2 = GameObject.Find("UI_2");
    }
    public void _Start_() => SceneManager.LoadScene("learning");
    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            if (transform.GetChild(0).gameObject.activeSelf) {foreach (Transform i in transform) i.gameObject.SetActive(false);}
            else if (!transform.GetChild(0).gameObject.activeSelf) foreach (Transform i in transform) i.gameObject.SetActive(true);
            if (UI_2.transform.GetChild(0).gameObject.activeSelf) {
                foreach (Transform i in UI_2.transform) i.gameObject.SetActive(false);
                foreach (Transform i in transform) i.gameObject.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene().name != "Start UI" && (
        UI_2.transform.GetChild(0).gameObject.activeSelf || transform.GetChild(0).gameObject.activeSelf)) player.GetComponent<CharacterControl>().enabled = false;

    }
    public void Exit() => Application.Quit();
    public void Exit1() => SceneManager.LoadScene("Start UI");
    public void Exit2(){
        foreach (Transform i in UI_2.transform) i.gameObject.SetActive(false);
        foreach (Transform i in transform) i.gameObject.SetActive(true);
    }
    public void Continue1(){
        foreach (Transform i in transform) i.gameObject.SetActive(false);
        player.GetComponent<CharacterControl>().enabled = true;
        Cursor.visible = false;
    }
    public void Settings(){
        foreach (Transform i in transform) i.gameObject.SetActive(false);
        foreach (Transform i in UI_2.transform) i.gameObject.SetActive(true);
    }
}
