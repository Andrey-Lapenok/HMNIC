using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchControl : MonoBehaviour
{
    public Transform frame;
    public Transform To;
    public string scene;
    public enum typeM { level = 1, scene = 2 };
    public enum typeM1 { slow = 1, fast = 2 };
    public typeM typeOfMovement;
    public typeM1 typeOfMovement1;
    public string levelOrScene;
    public string slowOrFast;
    void Start()
    {
        switch (typeOfMovement)
        {
            case typeM.level: levelOrScene = "level"; break;
            case typeM.scene: levelOrScene = "scene"; break;
        }
        switch (typeOfMovement1)
        {
            case typeM1.slow: slowOrFast = "slow"; break;
            case typeM1.fast: slowOrFast = "fast"; break;
        }
    }
}