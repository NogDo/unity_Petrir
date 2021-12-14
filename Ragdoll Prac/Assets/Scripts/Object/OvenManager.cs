using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvenManager : MonoBehaviour
{
    public ChestManager chestManager;
    public List<Sprite> list_MaterialImage;

    public GameObject obj_OvenUI;

    public AudioSource audioSource_Tutorial;
    public AudioSource audioSource_Oven;

    public CameraControl cameraControl;
    public PlayerController playerController;
    public Grab grabLeft;
    public Grab grabRight;

    public void OpenOvenUI()
    {
        if(chestManager.GetMaterialList().Count != 0)
        {
            list_MaterialImage = chestManager.GetMaterialList();
        }

        obj_OvenUI.SetActive(true);

        audioSource_Tutorial.Stop();
        audioSource_Oven.Play();

        cameraControl.StopScreenRotation();
        Cursor.lockState = CursorLockMode.None;

        playerController.UnablePlayerControl();
        grabLeft.UnAbleGrabBehavior();
        grabRight.UnAbleGrabBehavior();

        for(int i = 0; i < list_MaterialImage.Count; i++)
        {
            GameObject obj_Image = obj_OvenUI.transform.GetChild(1).transform.GetChild(i).gameObject;
            obj_Image.GetComponent<Image>().sprite = list_MaterialImage[i];
            obj_Image.SetActive(true);
        }
    }

    public void CloseOvenUI()
    {
        obj_OvenUI.SetActive(false);

        audioSource_Oven.Stop();
        audioSource_Tutorial.Play();

        cameraControl.StartScreenRotation();
        Cursor.lockState = CursorLockMode.Locked;

        playerController.AblePlayerControl();
        grabLeft.AbleGrabBehavior();
        grabRight.AbleGrabBehavior();
    }
}
