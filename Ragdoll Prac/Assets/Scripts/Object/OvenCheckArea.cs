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
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator_Oven.SetBool("isF", true);
            }
        }

        if (isOvenInterfaceOn)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (manager == Manager.Oven)
                {
                    ovenManager.CloseOvenUI();
                }
                else if (manager == Manager.Plate)
                {
                    plateManager.ClosePlateUI();
                }
                isOvenInterfaceOn = false;
            }

            animator_Oven.SetBool("isF", false);
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
