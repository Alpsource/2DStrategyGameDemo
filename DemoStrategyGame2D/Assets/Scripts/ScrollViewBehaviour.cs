using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewBehaviour : MonoBehaviour
{
    public RectTransform ContentRectTransform { get; private set; }

    public List<ButtonType> ButtonList;
    private float _lastPos;
    
    private void Start()
    {
        ContentRectTransform = transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        CreateAllScrollButtons();
        ContentRectTransform.localPosition=new Vector2(70,200);
        _lastPos = 200;
        
    }

    public void UpdateInfiniteButtons()
    {
        if (FindDirection() == "up")
        {
            float firstSiblingPos = ContentRectTransform.GetChild(0).localPosition.y;
            if (firstSiblingPos + ContentRectTransform.localPosition.y < 400)
            {
                for (int i = 0; i < 4; i++)
                {
                    Transform lastSibling = ContentRectTransform.GetChild(ContentRectTransform.childCount - 1);

                    lastSibling.localPosition = new Vector2(lastSibling.localPosition.x, firstSiblingPos + 32);
                    lastSibling.SetAsFirstSibling();
                }
            }
            
        }
        else
        {
            float lastSiblingPos = ContentRectTransform.GetChild(ContentRectTransform.childCount - 1).localPosition.y;
            if (lastSiblingPos + ContentRectTransform.localPosition.y > -600)
            {
                for (int i = 0; i < 4; i++)
                {
                    Transform firstSibling = ContentRectTransform.GetChild(0);

                    firstSibling.localPosition = new Vector2(firstSibling.localPosition.x, lastSiblingPos - 32);
                    firstSibling.SetAsLastSibling();
                }
            }
        }
    }


    private List<RectTransform> FindTheDistantTransforms()
    {
        float[] distanceArray = new float[ContentRectTransform.childCount];
        float maxDistance = 0;
        for (int i = 0; i < ContentRectTransform.childCount; i++)
        {
            
            float distance = Mathf.Abs(Mathf.Abs(ContentRectTransform.GetChild(i).localPosition.y) -
                                       ContentRectTransform.localPosition.y);
            if (distance >= maxDistance)
            {
                maxDistance = distance;
                distanceArray[i] = distance;
            }
        }

        List<RectTransform> outList = new List<RectTransform>();
        for (int i = 0; i < distanceArray.Length; i++)
        {
            if (distanceArray[i] >= maxDistance - 0.01f)
            {
                outList.Add(ContentRectTransform.GetChild(i).GetComponent<RectTransform>());
            }
        }
        Debug.Log(outList[0]);
        return outList;
    }

    private string FindDirection()
    {
        if (ContentRectTransform.localPosition.y - _lastPos> 0)
        {
            _lastPos = ContentRectTransform.localPosition.y;
            Debug.Log("down");
            return "down";
        }
        else
        {
            _lastPos = ContentRectTransform.localPosition.y;
            Debug.Log("up");
            return "up";
        }
    }
    
    private void CreateAllScrollButtons()
    {
        Vector3 buttonPositionVector3 = new Vector3(-21f,-21,0);

        for (int j = 0; j < 100; j++)
        {
            foreach (var t in ButtonList)
            {
                ButtonFactory.Instance.GetButton(buttonPositionVector3, t, ContentRectTransform);
                //CreateScrollButton(t.Image,buttonPositionVector3,t.Type,t.size);
                buttonPositionVector3.x += 42;
            }

            buttonPositionVector3.x = -21;
            buttonPositionVector3.y -= 32;
        }
    }
    
}
