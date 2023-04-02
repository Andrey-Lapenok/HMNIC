using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlocks : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}