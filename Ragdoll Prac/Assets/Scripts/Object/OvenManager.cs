using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Stage
{
    Oven,
    Tutorial,
    Stage1_1,
}

public class OvenManager : MonoBehaviour
{
    [Header("스테이지 선택")]
    public Stage stage;

    [Header("상자 매니저, 현재 보여지는 재료 리스트")]
    public ChestManager chestManager;
    public List<Sprite> list_MaterialImage;

    [Header("오븐 UI 이미지, 버튼")]
    public GameObject obj_OvenUI;
    public GameObject obj_Ingredient;
    public GameObject obj_BakeItButton;
    public Image image_Create;

    [Header("BGM")]
    public AudioSource audioSource_Tutorial;
    public AudioSource audioSource_Oven;

    [Header("플레이어 관련 스크립트")]
    public CameraControl cameraControl;
    public PlayerController playerController;
    public Grab grabLeft;
    public Grab grabRight;

    [Header("외부 매니저 파일")]
    public RecipeManager recipeManager;
    public TutorialManager tutorialManager;

    [Header("예외처리 해야하는 Sprite")]
    public Sprite sprite_PastryBag;

    private int nMaterialIndex = 0;
    private int nPastryCount = 0;

    public void OpenOvenUI()
    {
        if (chestManager.GetMaterialList().Count != 0)
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

        for (int i = 0; i < list_MaterialImage.Count; i++)
        {
            GameObject obj_Image = obj_Ingredient.transform.GetChild(i).transform.GetChild(0).gameObject;
            obj_Image.GetComponent<Image>().sprite = list_MaterialImage[i];
            obj_Image.SetActive(true);
        }
    }

    public void CloseOvenUI()
    {
        obj_OvenUI.SetActive(false);
        for (int i = 0; i < obj_Ingredient.transform.childCount; i++)
        {
            if (obj_Ingredient.transform.GetChild(i).childCount != 0)
            {
                obj_Ingredient.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = null;
                obj_Ingredient.transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
            }
        }

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
                    Sprite currentMaterial = material.GetComponent<Image>().sprite;

                    image_Create.color = Color.white;

                    image_Create.sprite = recipeManager.GetOvenTutorialCreate()[nMaterialIndex];
                    chestManager.list_Material.Remove(recipeManager.GetOvenTutorialRecipe()[nMaterialIndex]);

                    material.SetActive(false);
                    material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();

                    nMaterialIndex++;
                    tutorialManager.EndDragTutorial();
                }
                else
                {
                    material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();
                }
                break;

            case Stage.Tutorial:
                if (material.GetComponent<Image>().sprite == recipeManager.GetTutorialRecipe()[nMaterialIndex])
                {
                    Sprite currentMaterial = material.GetComponent<Image>().sprite;

                    image_Create.color = Color.white;

                    image_Create.sprite = recipeManager.GetTutorialCreate()[nMaterialIndex];
                    chestManager.list_Material.Remove(recipeManager.GetTutorialRecipe()[nMaterialIndex]);

                    material.SetActive(false);
                    material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();

                    nMaterialIndex++;
                    if (nMaterialIndex >= recipeManager.GetTutorialRecipe().Count)
                    {
                        obj_BakeItButton.SetActive(true);
                    }
                }
                else
                {
                    material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();
                }
                break;

            case Stage.Stage1_1:
                if (material.GetComponent<Image>().sprite == recipeManager.GetStage1Recipe()[nMaterialIndex])
                {
                    Debug.Log("재료 맞춤");
                    Sprite currentMaterial = material.GetComponent<Image>().sprite;

                    image_Create.color = Color.white;
                    image_Create.sprite = recipeManager.GetStage1Create()[nMaterialIndex];

                    if(currentMaterial == sprite_PastryBag && nPastryCount == 0)
                    {
                        material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();
                        nPastryCount++;
                    }
                    else
                    {
                        chestManager.list_Material.Remove(recipeManager.GetStage1Recipe()[nMaterialIndex]);
                        material.SetActive(false);
                        material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();
                    }

                    nMaterialIndex++;
                    if (nMaterialIndex >= recipeManager.GetStage1Recipe().Count)
                    {
                        obj_BakeItButton.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("재료 틀림");
                    material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();
                }
                break;

            default:
                Debug.Log("스테이지가 정의되지 않은 오븐입니다. (이 오류는 오븐매니저에서 발생했습니다.)");
                break;
        }
    }
}
