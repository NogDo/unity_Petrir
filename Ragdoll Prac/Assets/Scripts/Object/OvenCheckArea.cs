using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Manager
{
    Oven,
    Plate
}

public class OvenCheckArea : MonoBehaviour
{
    public Manager manager;

    public PlayerController playerController;

    public OvenManager ovenManager;
    public PlateManager plateManager;
    public TutorialManager tutorialManager;

    public GameObject obj_Text;

    public Animator animator_Oven;

    public bool isPlayerInArea;
    public bool isOvenInterfaceOn;

    private bool isEndOvenTutorial;

    private void Start()
    {
        isEndOvenTutorial = false;
    }

    void Update()
    {
        if (isPlayerInArea)
        {
            if(manager == Manager.Oven)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    animator_Oven.SetBool("isF", true);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    OpenUI();
                }
            }
        }

        if (isOvenInterfaceOn)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (manager == Manager.Oven)
                {
                    animator_Oven.SetBool("isF", false);
                    ovenManager.CloseOvenUI();
                }
                else if (manager == Manager.Plate)
                {
                    plateManager.ClosePlateUI();
                }
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

    public void OpenUI()
    {
        if (tutorialManager != null)
        {
            if (tutorialManager.IsStartOvenTutorial() && !isEndOvenTutorial && (ovenManager.stage == Stage.Oven))
            {
                tutorialManager.EndOvenTutorial();
                isEndOvenTutorial = true;
            }
        }

        if (manager == Manager.Oven)
        {
            ovenManager.OpenOvenUI();
        }
        else if (manager == Manager.Plate)
        {
            plateManager.OpenPlateUI();
        }
        isOvenInterfaceOn = true;
    }
}
