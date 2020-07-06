using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHolder : MonoBehaviour
{
    public GameObject BarracksGameObject;
    public GameObject PowerPlantGameObject;
    public static BuildingHolder Instance;

    private void Awake()
    {
        Instance = this;
    }

}
