using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviour : MilitaryUnit
{
    private SpriteRenderer myImage;

    private void Start()
    {
        myImage = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        myImage.color = ActiveSelf ? Color.green : Color.white;
    }
}
