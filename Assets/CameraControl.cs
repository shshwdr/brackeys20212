using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float minCemeraZoomIn;
    public float maxCemeraZoomIn;

    CinemachineVirtualCamera camera;

    public float scrollZoomScale = 1;

    private void Awake()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
    }
    public void Update()
    {
        camera.m_Lens.OrthographicSize  = Mathf.Clamp( camera.m_Lens.OrthographicSize + Input.mouseScrollDelta.y * scrollZoomScale,minCemeraZoomIn,maxCemeraZoomIn);
    }
}
