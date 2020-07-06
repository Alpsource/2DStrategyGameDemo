using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    
    private Vector3 vel =Vector3.zero;
    private Camera _myCamera;

    private void Start()
    {
        _myCamera = transform.GetComponent<Camera>();
        EventManager.Instance.CameraPosition += MoveCamera;
        EventManager.Instance.ZoomEvent += ZoomCamera;
    }

    private void OnDisable()
    {
        EventManager.Instance.CameraPosition -= MoveCamera;
        EventManager.Instance.ZoomEvent -= ZoomCamera;
    }

    public void MoveCamera(Vector3 targetVector3)
    {
        transform.position += targetVector3;

    }

    public void ZoomCamera(float amount)
    {
        _myCamera.orthographicSize += amount;
    }
}
