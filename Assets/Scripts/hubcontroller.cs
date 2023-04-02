using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hubcontroller : MonoBehaviour
{	
	public int numberOfLevels;
    void Start()
    {
		for (int i = 0; i < numberOfLevels + 1; i++)
		{
			if (PlayerPrefs.GetInt("level" + i.ToString()) == 1)
			{
				GameObject.Find("level" + i.ToString()).tag = "arch";
			}
		}
    }
}
