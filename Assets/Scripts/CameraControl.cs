using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject cameraV;
    public Transform player;
    public Transform frame;
    private bool n;
    void Update()
        {
            cameraV.transform.position = transform.position;

            switch (frame.gameObject.GetComponent<FramesControl>().staticOrFree)
            {
                case "static":
                    cameraV.SetActive(false);
                    transform.position = Vector3.Lerp(transform.position, frame.gameObject.GetComponent<FramesControl>().PosStaticCam, Time.deltaTime * frame.gameObject.GetComponent<FramesControl>().speed);
                    gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, frame.gameObject.GetComponent<FramesControl>().frameSize, Time.deltaTime * 3f);
                    cameraV.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = Mathf.Lerp(cameraV.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize, frame.gameObject.GetComponent<FramesControl>().frameSize, Time.deltaTime * 3f);
                    break;
                case "free":
                    cameraV.SetActive(true);
                    cameraV.transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, -10f), Time.deltaTime * frame.gameObject.GetComponent<FramesControl>().speed);
                    cameraV.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = Mathf.Lerp(cameraV.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize, frame.gameObject.GetComponent<FramesControl>().frameSize, Time.deltaTime * 3f);
                    cameraV.GetComponent<CinemachineConfiner>().m_BoundingShape2D = frame.GetChild(0).gameObject.GetComponent<PolygonCollider2D>();
                    // print(frame.GetChild(0));
                    break;
            }
        }
    public void CameraTeleport(string a)
    {
        if (a == "fast"){
            transform.position = frame.gameObject.GetComponent<FramesControl>().PosStaticCam;
            cameraV.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = frame.gameObject.GetComponent<FramesControl>().frameSize;
            gameObject.GetComponent<Camera>().orthographicSize = frame.gameObject.GetComponent<FramesControl>().frameSize;
        }
    }
}