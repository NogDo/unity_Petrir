using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MaterialDrag : MonoBehaviour, IDragHandler, IDropHandler
{
    public Vector2 vector_StartPosition;

    private void Start()
    {
        vector_StartPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 vector_MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        transform.position = vector_MousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop 작동 확인");
        if (eventData.position != vector_StartPosition)
        {
            transform.position = vector_StartPosition;
        }
    }
}
