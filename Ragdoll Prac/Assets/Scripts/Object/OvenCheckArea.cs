using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenCheckArea : MonoBehaviour
{
    public PlayerController playerController;

    public OvenManager ovenManager;

    public GameObject obj_Text;

    public bool isPlayerInArea;
    public bool isOvenInterfaceOn;

    void Update()
    {
        if (isPlayerInArea)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ovenManager.OpenOvenUI();
                isOvenInterfaceOn = true;
            }
        }

        if (isOvenInterfaceOn)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ovenManager.CloseOvenUI();
                isOvenInterfaceOn = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == playerController.gameObject)
        {
            ShowText();
            isPlayerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerController.gameObject)
        {
            HideText();
            isPlayerInArea = false;
        }
    }

    public void ShowText()
    {
        obj_Text.SetActive(true);
    }

    public void HideText()
    {
        obj_Text.SetActive(false);
    }
}
