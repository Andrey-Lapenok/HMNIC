using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramesControl : MonoBehaviour
{
	public float speed = 2; 
    public float frameSize;
    public enum typeM {staticCam = 1, freeCam = 2};
    public typeM typeOfCamera;
    public Vector3 PosStaticCam = new Vector3(0, 0, -10f);
    public string staticOrFree;
    public bool m;
    void Start()
    {
        switch (typeOfCamera)
        {
            case typeM.staticCam:
                staticOrFree = "static"; break;
            case typeM.freeCam:
                staticOrFree = "free"; break;
        }
    }
}