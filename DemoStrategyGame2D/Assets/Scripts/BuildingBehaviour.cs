using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingBehaviour : MonoBehaviour
{
    public Vector2Int Position;
    public abstract void Initialize(Vector2Int pos);
    public abstract void Clicked(Vector3 clickPos);
    public abstract void UpdateMenu();
}
