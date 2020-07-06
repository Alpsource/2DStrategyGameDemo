using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationMenuBehaviour : MonoBehaviour
{
    public static InformationMenuBehaviour Instance;
    private Text buildingName,productionText;
    private Image buildingImage, productionImage;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name.StartsWith("BuildingName"))
            {
                buildingName = child.GetComponent<Text>();
            }
            else if (child.name.StartsWith("ProductionText"))
            {
                productionText = child.GetComponent<Text>();
            }
            else if (child.name.StartsWith("BuildingImage"))
            {
                buildingImage = child.GetComponent<Image>();
            }
            else if (child.name.StartsWith("Train"))
            {
                productionImage = child.GetComponent<Image>();
                child.GetComponent<Button>().onClick.AddListener(OnSpawnSoldier);
            }
        }
        buildingName.gameObject.SetActive(false);
        buildingImage.gameObject.SetActive(false);
        productionText.gameObject.SetActive(false);
        productionImage.gameObject.SetActive(false);
    }

    public void UpdateMenu(Sprite image,string selfname,Sprite trainImage=null)
    {
        buildingName.gameObject.SetActive(true);
        buildingImage.gameObject.SetActive(true);
        buildingName.text = selfname;
        buildingImage.sprite = image;
        if (trainImage != null)
        {
            productionText.gameObject.SetActive(true);
            productionImage.gameObject.SetActive(true);
            productionImage.sprite = trainImage;
        }
        else
        {
            productionText.gameObject.SetActive(false);
            productionImage.gameObject.SetActive(false);
        }
    }

    public void ResetMenu()
    {
        buildingName.gameObject.SetActive(false);
        buildingImage.gameObject.SetActive(false);
        productionText.gameObject.SetActive(false);
        productionImage.gameObject.SetActive(false);
    }

    public void OnSpawnSoldier()
    {
        EventManager.Instance.SpawnSoldiers();
    }
}
