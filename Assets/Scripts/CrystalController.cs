using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalEvent : MonoBehaviour
{ 
    void Start()
    {
        GameObject.Find("Carl").GetComponent<CharacterControl>().crystals += 1;
        Destroy(gameObject);
    }

}
