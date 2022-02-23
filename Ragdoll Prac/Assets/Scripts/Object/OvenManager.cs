using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Stage
{
    Oven,
    Tutorial,
}

public class OvenManager : MonoBehaviour
{
    public Stage stage;

    public ChestManager chestManager;
    public List<Sprite> list_MaterialImage;

    public GameObject obj_OvenUI;
    public GameObject obj_Ingredient;
    public GameObject obj_BakeItButton;
    public Image image_Create;

    public AudioSource audioSource_Tutorial;
    public AudioSource audioSource_Oven;

    public CameraControl cameraControl;
    public PlayerController playerController;
    public Grab grabLeft;
    public Grab grabRight;

    public RecipeManager recipeManager;
    private int nMaterialIndex = 0;

    public TutorialManager tutorialManager;

    public void OpenOvenUI()
    {
        if(chestManager.GetMaterialList().Count != 0)
        {
            list_MaterialImage = chestManager.GetMaterialList();
        }

        obj_OvenUI.SetActive(true);

        audioSource_Tutorial.Stop();
        audioSource_Oven.Play();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cameraControl.StopScreenRotation();

        playerController.UnablePlayerControl();
        grabLeft.UnAbleGrabBehavior();
        grabRight.UnAbleGrabBehavior();

        for(int i = 0; i < list_MaterialImage.Count; i++)
        {
            GameObject obj_Image = obj_Ingredient.transform.GetChild(i).transform.GetChild(0).gameObject;
            obj_Image.GetComponent<Image>().sprite = list_MaterialImage[i];
            obj_Image.SetActive(true);
        }
    }

    public void CloseOvenUI()
    {
        obj_OvenUI.SetActive(false);

        audioSource_Oven.Stop();
        audioSource_Tutorial.Play();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraControl.StartScreenRotation();

        playerController.AblePlayerControl();
        grabLeft.AbleGrabBehavior();
        grabRight.AbleGrabBehavior();
    }

    public void CheckMaterial(GameObject material)
    {
        switch (stage)
        {
            case Stage.Oven:
                Debug.Log("오븐튜토리얼확인");
                if (material.GetComponent<Image>().sprite == recipeManager.GetOvenTutorialRecipe()[nMaterialIndex])
                {
                    Debug.Log("재료 맞춤1");
                    Sprite currentMaterial = material.GetComponent<Image>().sprite;

                    image_Create.color = Color.white;
                    Debug.Log("재료 맞춤2");

                    image_Create.sprite = recipeManager.GetOvenTutorialCreate()[nMaterialIndex];
                    list_MaterialImage.Remove(recipeManager.GetOvenTutorialRecipe()[nMaterialIndex]);
                    chestManager.list_Material.Remove(recipeManager.GetOvenTutorialRecipe()[nMaterialIndex]);
                    material.SetActive(false);
                    Debug.Log("재료 맞춤3");

                    nMaterialIndex++;
                    tutorialManager.EndDragTutorial();
                }
                else
                {
                    Debug.Log("재료 틀림");
                    material.transform.position = material.GetComponent<MaterialDrag>().vector_StartPosition;
                }
                break;

            case Stage.Tutorial:
                if (material.GetComponent<Image>().sprite == recipeManager.GetTutorialRecipe()[nMaterialIndex])
                {
                    Debug.Log("재료 맞춤");
                    Sprite currentMaterial = material.GetComponent<Image>().sprite;

                    image_Create.color = Color.white;

                    image_Create.sprite = recipeManager.GetTutorialCreate()[nMaterialIndex];
                    list_MaterialImage.Remove(recipeManager.GetTutorialRecipe()[nMaterialIndex]);
                    chestManager.list_Material.Remove(recipeManager.GetTutorialRecipe()[nMaterialIndex]);
                    material.SetActive(false);

                    nMaterialIndex++;
                    if(nMaterialIndex >= recipeManager.GetTutorialRecipe().Count)
                    {
                        obj_BakeItButton.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("재료 틀림");
                    material.transform.position = material.GetComponent<MaterialDrag>().vector_StartPosition;
                }
                break;

            default:
                Debug.Log("스테이지가 정의되지 않은 오븐입니다.");
                break;
        }
    }
}
