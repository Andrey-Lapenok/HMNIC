using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int requiredNumberOfTaken;
    public int numberOfTaken = 0;

    public void Open()
    {
        if (numberOfTaken == requiredNumberOfTaken) Destroy(gameObject);
    }
}
