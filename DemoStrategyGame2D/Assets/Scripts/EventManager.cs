using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public event Action<Vector3> ClickedOn;
    public event Action<Vector3> SetTarget;
    public event Action<Vector3> CameraPosition;
    public event Action<float> ZoomEvent; 
    public event Action SpawnSoldier; 
    private void Awake()
    {
        Instance = this;
    }

    public void Clicked(Vector3 pos)
    {
        ClickedOn?.Invoke(pos);
    }

    public void SpawnSoldiers()
    {
        SpawnSoldier?.Invoke();
    }

    public void SetSoldierTarget(Vector3 posVector3)
    {
        SetTarget?.Invoke(posVector3);
    }

    public void CameraUpdate(Vector3 posVector3)
    {
        CameraPosition?.Invoke(posVector3);
    }
    public void ZoomUpdate(float zoomAmount)
    {
        ZoomEvent?.Invoke(zoomAmount);
    }
}
