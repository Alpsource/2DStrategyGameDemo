using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        
        SelectObject();
        SelectSoldierTarget();
        UpdateCameraPos();
        UpdateCameraZoom();
    }

    private bool isMouseOverUi()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 0.6f;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void UpdateCameraPos()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        EventManager.Instance.CameraUpdate(new Vector3(horizontal, 0, vertical));
    }

    private void UpdateCameraZoom()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            EventManager.Instance.ZoomUpdate(-0.3f);
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            EventManager.Instance.ZoomUpdate(0.3f);
        }
    }

    private void SelectObject()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (!isMouseOverUi())
            {
                InformationMenuBehaviour.Instance.ResetMenu();
                Vector3 mousePos = GetMouseWorldPos();
                EventManager.Instance.Clicked(mousePos);
            }
        }
    }

    private void SelectSoldierTarget()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isMouseOverUi())
            {
                Vector3 mousePos = GetMouseWorldPos();
                EventManager.Instance.SetSoldierTarget(mousePos);
            }
        }
    }
}
