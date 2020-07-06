using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class BasicButtonBehaviour : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Transform _dragTransform;
    public SpriteRenderer mySpriteRenderer;
    public Vector2Int size;
    public void InitializeButton(Vector2Int sizeVector2Int)
    {
        transform.GetComponent<Button>().onClick.AddListener(OnClickBehaviour);
        size = sizeVector2Int;
    }
    public void OnClickBehaviour()
    {
        Debug.Log("Button pressed");
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = GetMouseWorldPos();
        newPos.y = 0.6f;
        newPos.x = Mathf.FloorToInt(newPos.x);
        newPos.z = Mathf.FloorToInt(newPos.z);
        _dragTransform.position = newPos;
        mySpriteRenderer.color = GridManager.Instance.BuildingIsPlacable(newPos, size) ? Color.white : Color.red;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 0.6f;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GridManager.Instance.BuildingIsPlacable(_dragTransform.position, size))
        {
            GridManager.Instance.PlaceBuilding(_dragTransform.position, size);
            _dragTransform.GetComponent<BuildingBehaviour>().Initialize(new Vector2Int((int)_dragTransform.position.x,(int) _dragTransform.position.z));
        }
        else
        {
            Destroy(_dragTransform.gameObject);
        }
    }
}