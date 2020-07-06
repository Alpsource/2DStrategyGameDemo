using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksBehaviour : BuildingBehaviour
{
    private readonly string _selfName = "Barracks";
    private Sprite _selfSprite;
    private Sprite _soldierSprite;
    private bool _active = false;
    public override void Initialize(Vector2Int pos)
    {
        Position = pos;
        _selfSprite = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        _soldierSprite = MilitaryUnitHolder.Instance.Soldier.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }
    private void OnEnable()
    {
        EventManager.Instance.ClickedOn += Clicked;
        EventManager.Instance.SpawnSoldier += SpawnSoldier;
    }
    private void OnDisable()
    {
        EventManager.Instance.ClickedOn -= Clicked;
        EventManager.Instance.SpawnSoldier -= SpawnSoldier;
    }
    public override void Clicked(Vector3 clickPos)
    {
        if (ClickIsInRange(clickPos))
        {
            Debug.Log("I am Active:"+ _selfName);
            UpdateMenu();
            _active = true;
        }
        else
        {
            _active = false;
        }
    }
    private bool ClickIsInRange(Vector3 pos)
    {
        return pos.x > Position.x && pos.x < Position.x + 4 && pos.z > Position.y && pos.z < Position.y + 4;
    }

    public override void UpdateMenu()
    {
        InformationMenuBehaviour.Instance.UpdateMenu(_selfSprite, _selfName,_soldierSprite);
    }

    private void SpawnSoldier()
    {
        if (_active)
        {
            Debug.Log("spawning soldiers at position"+Position.ToString());
            for (int i = 0; i < 2; i++)
            {
                if (GridManager.Instance.BuildingIsPlacable(new Vector3(Position.x - 1, 0, Position.y + 1 + i), new Vector2Int(1, 1)))
                {
                    Instantiate(MilitaryUnitHolder.Instance.Soldier, new Vector3(Position.x-1, 0.6f, Position.y + 1 + i),
                        Quaternion.identity);
                    GridManager.Instance.PlaceSoldier(new Vector3(Position.x - 1, 0.6f, Position.y + 1 + i),new Vector2Int(1,1));
                    break;
                }
            }
            
        }
    }

}
