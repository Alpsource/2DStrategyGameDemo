using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantBehaviour : BuildingBehaviour
{
    private readonly string _selfName = "Power Plant";
    private Sprite _selfSprite;
    public override void Initialize(Vector2Int pos)
    {
        Position = pos;
        _selfSprite = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }

    private void OnEnable()
    {
        EventManager.Instance.ClickedOn += Clicked;
    }
    private void OnDisable()
    {
        EventManager.Instance.ClickedOn -= Clicked;
    }
    public override void Clicked(Vector3 clickPos)
    {
        if (ClickIsInRange(clickPos))
        {
            Debug.Log("I am Active:" + _selfName);
            UpdateMenu();
        }
    }

    private bool ClickIsInRange(Vector3 pos)
    {
        return pos.x > Position.x && pos.x < Position.x + 2 && pos.z > Position.y && pos.z < Position.y + 3;
    }

    public override void UpdateMenu()
    {
        InformationMenuBehaviour.Instance.UpdateMenu(_selfSprite,_selfName);
    }
}
