using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PowerPlantButton : BasicButtonBehaviour,IBeginDragHandler
{
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragTransform = Instantiate(BuildingHolder.Instance.PowerPlantGameObject).transform;
        mySpriteRenderer = _dragTransform.GetChild(0).GetComponent<SpriteRenderer>();
        
    }
    
}