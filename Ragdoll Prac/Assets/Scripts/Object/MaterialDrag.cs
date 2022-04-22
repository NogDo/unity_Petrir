using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MaterialDrag : MonoBehaviour, IDragHandler, IDropHandler
{
    public Vector2 vector_StartPosition;
    public GameObject objCreatePanel;
    public GameObject objMainCanvas;
    public GameObject objIngredientImage;

    public OvenManager ovenManager;

    private void Start()
    {
        vector_StartPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.SetParent(objMainCanvas.transform);

        Debug.Log(objCreatePanel.transform.position);
    }

    public void OnDrop(PointerEventData eventData)
    {
        float fPanelWidth = objCreatePanel.GetComponent<RectTransform>().rect.width;
        float fPanelHeight = objCreatePanel.GetComponent<RectTransform>().rect.height;
        float fPanelPositionX = objCreatePanel.transform.position.x;
        float fPanelPositionY = objCreatePanel.transform.position.y;

        if ((eventData.position.x >= fPanelPositionX - fPanelWidth / 2 && eventData.position.x <= fPanelPositionX + fPanelWidth / 2)
            && (eventData.position.y >= fPanelPositionY - fPanelHeight / 2 && eventData.position.y <= fPanelPositionY + fPanelHeight / 2))
        {
            Debug.Log("OnDrop 중 재료가 안에 들어간경우 실행");
            ovenManager.CheckMaterial(gameObject);
        }
        else
        {
            Reset_Ingredient_PositionAndParent();
        }
    }

    public void Reset_Ingredient_PositionAndParent()
    {
        transform.position = vector_StartPosition;
        transform.SetParent(objIngredientImage.transform);
    }
}
