using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEvent : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Clear>().enabled = true;
    }

}