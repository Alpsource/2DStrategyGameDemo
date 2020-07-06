using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryUnitHolder : MonoBehaviour
{
    public GameObject Soldier;
    public static MilitaryUnitHolder Instance;

    private void Awake()
    {
        Instance = this;
    }
}
