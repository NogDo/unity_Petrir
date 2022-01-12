using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MaterialDrag : MonoBehaviour, IDragHandler, IDropHandler
{
    public Vector2 vector_StartPosition;
    public GameObject obj_CreatePanel;

    public OvenManager ovenManager;

    private void Start()
    {
        vector_StartPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

        Debug.Log(obj_CreatePanel.transform.position);
    }

    public void OnDrop(PointerEventData eventData)
    {
        float fPanelWidth = obj_CreatePanel.GetComponent<RectTransform>().rect.width;
        float fPanelHeight = obj_CreatePanel.GetComponent<RectTransform>().rect.height;
        float fPanelPositionX = obj_CreatePanel.transform.position.x;
        float fPanelPositionY = obj_CreatePanel.transform.position.y;

        if ((eventData.position.x >= fPanelPositionX - fPanelWidth / 2 && eventData.position.x <= fPanelPositionX + fPanelWidth / 2)
            && (eventData.position.y >= fPanelPositionY - fPanelHeight / 2 && eventData.position.y <= fPanelPositionY + fPanelHeight / 2))
        {
            ovenManager.CheckMaterial(gameObject);
        }
        else
        {
            transform.position = vector_StartPosition;
        }
    }
}
