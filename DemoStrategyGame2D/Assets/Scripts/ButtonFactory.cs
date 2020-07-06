using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class ButtonFactory:MonoBehaviour
{
    public static ButtonFactory Instance;
    [System.Serializable]
    public class ButtonProperty
    {
        public Sprite Image;
        public ButtonType Type;
        public Vector2Int Size;
    }

    public List<ButtonProperty> ButtonList;
    private void Awake()
    {
        Instance = this;
    }
    public  BasicButtonBehaviour GetButton(Vector3 localPosition, ButtonType type, Transform parentTransform)
    {
        GameObject targetGameObject;
        targetGameObject = CreateButton(localPosition, type, parentTransform);
        BasicButtonBehaviour buttonBehaviour;
        switch (type)
        {
            case ButtonType.Barracks:
            {
                //Debug.Log("BarracksAdded");
                buttonBehaviour = targetGameObject.AddComponent<BarracksButton>();
                break;
            }
            case ButtonType.PowerPlant:
            {
                //Debug.Log("PowerPlantAdded");
                buttonBehaviour = targetGameObject.AddComponent<PowerPlantButton>();
                break;
            }
            default:
            {
                Debug.Log("No implemented type");
                buttonBehaviour=new BasicButtonBehaviour();
                break;
            }
        }
        buttonBehaviour.InitializeButton(GetButtonSize(type));
        return targetGameObject.GetComponent<BasicButtonBehaviour>();
    }
    private GameObject CreateButton(Vector3 localPosition, ButtonType type,Transform parentTransform)
    {
        GameObject buttonGameObject = ObjectPooler.Instance.SpawnFromPool("ScrollButton", Vector3.zero, Quaternion.identity);
        buttonGameObject.transform.SetParent(parentTransform);
        RectTransform buttonRectTransform = buttonGameObject.GetComponent<RectTransform>();
        Button buttonComponent = buttonGameObject.GetComponent<Button>();
        buttonGameObject.GetComponent<Image>().sprite = GetButtonImage(type);
        buttonGameObject.transform.localPosition = localPosition;
        return buttonGameObject;
    }

    private Sprite GetButtonImage(ButtonType type)
    {
        foreach (ButtonProperty elementProperty in ButtonList)
        {
            if (elementProperty.Type == type)
            {
                return elementProperty.Image;
            }
        }

        return null;
    }
    private Vector2Int GetButtonSize(ButtonType type)
    {
        foreach (ButtonProperty elementProperty in ButtonList)
        {
            if (elementProperty.Type == type)
            {
                return elementProperty.Size;
            }
        }

        return new Vector2Int(1,1);
    }
}

public enum ButtonType
{
    Barracks,
    PowerPlant
}
