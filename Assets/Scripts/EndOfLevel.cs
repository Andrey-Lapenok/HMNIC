using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
	public int level;
    void Start()
    {
        PlayerPrefs.SetInt("level" + level.ToString(), 1);
        Destroy(gameObject);
    }
}
