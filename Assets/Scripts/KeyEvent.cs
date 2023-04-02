using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyEvent : MonoBehaviour
{
    public GameObject door;
    void Start()
    {
        door.GetComponent<DoorController>().numberOfTaken += 1;
        door.GetComponent<DoorController>().Open();
        Destroy(gameObject);
    }

}
