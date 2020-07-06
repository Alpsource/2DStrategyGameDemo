using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BarracksButton : BasicButtonBehaviour,IBeginDragHandler
{

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragTransform = Instantiate(BuildingHolder.Instance.BarracksGameObject).transform;
        mySpriteRenderer = _dragTransform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    
}