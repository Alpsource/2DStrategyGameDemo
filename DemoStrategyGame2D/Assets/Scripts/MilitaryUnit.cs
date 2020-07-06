using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryUnit : MonoBehaviour
{
    public bool ActiveSelf = false;
    private bool _moving = false;
    private string selfName = "Soldier";
    private Vector3 _nextPoint;
    public Vector3 SelfPosition;
    public Vector3 TargetPosition;
    private void OnEnable()
    {
        EventManager.Instance.ClickedOn += Clicked;
        EventManager.Instance.SetTarget += SetSelfTarget;
        SelfPosition = transform.position;
    }
    private void OnDisable()
    {
        EventManager.Instance.ClickedOn -= Clicked;
        EventManager.Instance.SetTarget -= SetSelfTarget;
    }

    private void SetSelfTarget(Vector3 obj)
    {
        if (ActiveSelf)
        {
            if (GridManager.Instance.TargetIsValid(obj))
            {

                TargetPosition = new Vector3(Mathf.FloorToInt(obj.x), 0.6f, Mathf.FloorToInt(obj.z));
                Debug.Log("target position is: " + TargetPosition);
                if (!_moving)
                {
                    StartCoroutine(MoveSoldier());
                    _moving = true;
                }

            }

        }
    }

    private IEnumerator MoveSoldier()
    {

        while (transform.position != TargetPosition)
        {
            if (PathFinder.Instance.GetNextPoint(transform.position, TargetPosition, out _nextPoint))
            {
                GridManager.Instance.MoveSoldier(transform.position, _nextPoint);
                while (transform.position != _nextPoint)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _nextPoint, 0.1f);
                    yield return new WaitForSeconds(0.01f);
                }
                SelfPosition = transform.position;
            }
            else
            {
                break;
            }
        }

        SelfPosition = transform.position;
        _moving = false;
    }

    private void Clicked(Vector3 clickPos)
    {
        if (ClickIsInRange(clickPos))
        {
            Debug.Log("I am Active:" + selfName);
            ActiveSelf = true;
        }
        else
        {
            ActiveSelf = false;
        }
    }
    private bool ClickIsInRange(Vector3 pos)
    {
        return pos.x > SelfPosition.x && pos.x < SelfPosition.x + 1 && pos.z > SelfPosition.z && pos.z < SelfPosition.z + 1;
    }
}
