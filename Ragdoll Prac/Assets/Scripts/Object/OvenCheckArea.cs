using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenCheckArea : MonoBehaviour
{
    public PlayerController playerController;

    public OvenManager ovenManager;
    public TutorialManager tutorialManager;

    public GameObject obj_Text;

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
                if (tutorialManager.IsStartOvenTutorial() && !isEndOvenTutorial && (ovenManager.stage == Stage.Oven))
                {
                    tutorialManager.EndOvenTutorial();
                    isEndOvenTutorial = true;
                }

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
