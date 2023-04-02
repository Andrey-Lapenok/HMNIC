using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{ 
    void Start()
    {
        GameObject.Find("Carl").GetComponent<CharacterControl>().crystals += 1;
        Destroy(gameObject);
    }

}
