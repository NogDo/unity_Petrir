using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateManager : MonoBehaviour
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
    public GameObject obj_BakeItButton2;
    public GameObject obj_Plate;
    public Image image_Create;

    [Header("오븐열릴때 비활성화될 오브젝트")]
    public GameObject objKnifeImage;

    [Header("BGM")]
    public AudioSource audioSource_Stage;
    public AudioSource audioSource_Oven;

    [Header("플레이어 관련 스크립트")]
    public CameraControl cameraControl;
    public PlayerController playerController;
    public Grab grabLeft;
    public Grab grabRight;

    [Header("외부 매니저 파일")]
    public RecipeManager recipeManager;
    public TutorialManager tutorialManager;
    public GameUIManager gameUIManager;

    [Header("예외처리 해야하는 Sprite")]
    public Sprite sprite_PastryBag;
    public Sprite sprite_Crust;
    public Sprite sprite_BakedCrust;
    public GameObject objTartFinished;
    public GameObject objStrawberryTartFinished;
    public GameObject objShineMuskatTartFinished;
    public GameObject objRollcakeDoughFinished;
    public GameObject objRollcakeFinished;
    public GameObject objClickIt;
    public GameObject objClickItButton;
    public GameObject objArrow;
    public Sprite objRollCakeFinishedAfterCilckIt;

    private int nMaterialIndex = 0;
    private int nPastryCount = 0;

    private bool isStage2StrawberryTartEnd;

    // Start is called before the first frame update
    void Start()
    {
        isStage2StrawberryTartEnd = false;
    }

    public void OpenPlateUI()
    {
        if (chestManager.GetMaterialList().Count != 0)
        {
            list_MaterialImage = chestManager.GetMaterialList();
        }

        obj_OvenUI.SetActive(true);
        objKnifeImage.SetActive(false);
        obj_Plate.SetActive(true);

        gameUIManager.PlateUIOn();

        if (stage == Stage.Stage1_2)
        {
            objTartFinished.SetActive(false);
            objStrawberryTartFinished.SetActive(false);
            objShineMuskatTartFinished.SetActive(false);
        }
        else if (stage == Stage.Stage1_3)
        {
            objRollcakeDoughFinished.SetActive(false);
            objRollcakeFinished.SetActive(false);
        }
        image_Create.gameObject.SetActive(true);

        audioSource_Stage.Stop();
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

    public void ClosePlateUI()
    {
        obj_OvenUI.SetActive(false);
        objKnifeImage.SetActive(true);
        obj_Plate.SetActive(false);

        for (int i = 0; i < obj_Ingredient.transform.childCount; i++)
        {
            if (obj_Ingredient.transform.GetChild(i).childCount != 0)
            {
                obj_Ingredient.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = null;
                obj_Ingredient.transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
            }
        }

        gameUIManager.PlateUIOff();

        audioSource_Oven.Stop();
        audioSource_Stage.Play();

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

                    if (currentMaterial == sprite_PastryBag && nPastryCount == 0)
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

            case Stage.Stage1_2:
                if (material.GetComponent<Image>().sprite == recipeManager.GetStage2StrawberryTartRecipe()[nMaterialIndex] && !isStage2StrawberryTartEnd)
                {
                    Debug.Log("재료 맞춤");
                    Sprite currentMaterial = material.GetComponent<Image>().sprite;

                    image_Create.color = Color.white;
                    image_Create.sprite = recipeManager.GetStage2StrawberryTartCreate()[nMaterialIndex];

                    if (currentMaterial == sprite_Crust)
                    {
                        material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();
                        material.GetComponent<Image>().sprite = sprite_BakedCrust;
                        chestManager.list_Material.Remove(recipeManager.GetStage2StrawberryTartRecipe()[nMaterialIndex]);
                        chestManager.list_Material.Add(sprite_BakedCrust);
                    }
                    else if (currentMaterial == sprite_PastryBag && nPastryCount < 1)
                    {
                        material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();
                        nPastryCount++;
                    }
                    else
                    {
                        chestManager.list_Material.Remove(recipeManager.GetStage2StrawberryTartRecipe()[nMaterialIndex]);
                        material.SetActive(false);
                        material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();
                    }

                    nMaterialIndex++;
                    if (nMaterialIndex >= recipeManager.GetStage2StrawberryTartRecipe().Count)
                    {
                        obj_BakeItButton.SetActive(true);
                    }
                }
                else if (isStage2StrawberryTartEnd && material.GetComponent<Image>().sprite == recipeManager.GetStage2MuscatTartRecipe()[nMaterialIndex])
                {
                    Debug.Log("재료 맞춤");
                    Sprite currentMaterial = material.GetComponent<Image>().sprite;

                    image_Create.color = Color.white;
                    image_Create.sprite = recipeManager.GetStage2MuscatTartCreate()[nMaterialIndex];

                    chestManager.list_Material.Remove(recipeManager.GetStage2MuscatTartRecipe()[nMaterialIndex]);
                    material.SetActive(false);
                    material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();

                    nMaterialIndex++;
                    if (nMaterialIndex >= recipeManager.GetStage2MuscatTartRecipe().Count)
                    {
                        obj_BakeItButton2.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("재료 틀림");
                    material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();
                }
                break;

            case Stage.Stage1_3:
                if (material.GetComponent<Image>().sprite == recipeManager.GetStage3RollcakeRecipe()[nMaterialIndex])
                {
                    Debug.Log("재료 맞춤");
                    Sprite currentMaterial = material.GetComponent<Image>().sprite;

                    image_Create.color = Color.white;
                    image_Create.sprite = recipeManager.GetStage3RollcakeCreate()[nMaterialIndex];
                    chestManager.list_Material.Remove(recipeManager.GetStage3RollcakeRecipe()[nMaterialIndex]);

                    material.SetActive(false);
                    material.GetComponent<MaterialDrag>().Reset_Ingredient_PositionAndParent();
                    nMaterialIndex++;
                    if (nMaterialIndex >= recipeManager.GetStage3RollcakeRecipe().Count)
                    {
                        objClickIt.SetActive(true);
                        objArrow.SetActive(true);
                        objClickItButton.SetActive(true);
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

    public void StrawberryTartFinish()
    {
        image_Create = objShineMuskatTartFinished.GetComponent<Image>();
        isStage2StrawberryTartEnd = true;
        nMaterialIndex = 0;
    }

    public void Stage3_ClickIt()
    {
        image_Create.sprite = objRollCakeFinishedAfterCilckIt;
        obj_BakeItButton.SetActive(true);
    }
}
