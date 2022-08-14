using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestManager : MonoBehaviour
{
    [Header("상자에 들어간 재료")]
    public List<Sprite> list_Material;

    [Header("예외처리해야하는 재료")]
    public Sprite sprite_Chocolate;
    public Sprite sprite_Strawberry;

    [Header("외부 스크립트")]
    public TutorialManager tutorialManager;
    public OvenManager ovenManager;
    public PlateManager plateManager;

    [Header("레시피 체크박스")]
    public Image[] Image_RecipeCheckBox;
    public Sprite sprite_O;
    public Sprite sprite_X;

    private bool isEndChestTutorial;
    private bool isAlreadyInChocolate;
    private bool isChocolateCut;
    private bool isStrawberryCut;
    private bool isKiwiCut;

    private int nBreadCount;
    private int nStrawberryCount;
    private int nBlueberryCount;
    private int nBananaCount;
    private int nKiwiCount;
    private int nOrangeCount;
    private int nPeachCount;

    private Stage stage;

    private void Start()
    {
        isEndChestTutorial = false;
        isAlreadyInChocolate = false;
        isChocolateCut = false;
        isStrawberryCut = false;

        nBreadCount = 0;
        nStrawberryCount = 0;
        nBlueberryCount = 0;
        nBananaCount = 0;
        nKiwiCount = 0;
        nOrangeCount = 0;
        nPeachCount = 0;

        if (ovenManager != null)
        {
            stage = ovenManager.stage;
        }
        else
        {
            stage = plateManager.stage;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if(tutorialManager != null)
            {
                if (tutorialManager.IsStartChestTutorial() && !isEndChestTutorial && (ovenManager.stage == Stage.Oven))
                {
                    tutorialManager.EndChestTutorial();
                    isEndChestTutorial = true;
                }
            }

            //other.gameObject.SetActive(false);
            if(other.gameObject.GetComponent<ObjectManager>() != null)
            {
                CheckIngredient_CheckBox(other.GetComponent<ObjectManager>());
                AddIngredientImage(other.gameObject.GetComponent<ObjectManager>().sprite_ObjectImage, other.gameObject);
            }
        }
    }

    public List<Sprite> GetMaterialList()
    {
        return list_Material;
    }

    public void CheckIngredient_CheckBox(ObjectManager objectManager)
    {
        switch (stage)
        {
            case Stage.Oven:
                switch (objectManager.ingredient)
                {
                    case Ingredient.Biscuit:
                        Image_RecipeCheckBox[0].sprite = sprite_O;
                        break;
                }
                break;

            case Stage.Tutorial:
                switch (objectManager.ingredient)
                {
                    case Ingredient.Biscuit:
                        if (Image_RecipeCheckBox[0].sprite == sprite_X)
                        {
                            Image_RecipeCheckBox[0].sprite = sprite_O;
                        }
                        else
                        {
                            Image_RecipeCheckBox[1].sprite = sprite_O;
                        }
                        break;

                    case Ingredient.Chocolate:
                        if (!isChocolateCut)
                        {
                            break;
                        }
                        Image_RecipeCheckBox[2].sprite = sprite_O;
                        break;

                    case Ingredient.Marshmallow:
                        Image_RecipeCheckBox[3].sprite = sprite_O;
                        break;
                }
                break;

            case Stage.Stage1_1:
                switch (objectManager.ingredient)
                {
                    case Ingredient.Bread:
                        if(nBreadCount == 0)
                        {
                            Image_RecipeCheckBox[0].sprite = sprite_O;
                        }
                        else if(nBreadCount == 1)
                        {
                            Image_RecipeCheckBox[1].sprite = sprite_O;
                        }
                        nBreadCount++;
                        break;

                    case Ingredient.Strawberry_Cut:
                        Debug.Log("딸기 상자에 넣는거 확인");
                        if (isStrawberryCut)
                        {
                            if (nStrawberryCount == 1)
                            {
                                Image_RecipeCheckBox[2].sprite = sprite_O;
                            }
                            else if (nStrawberryCount == 3)
                            {
                                Image_RecipeCheckBox[3].sprite = sprite_O;
                            }
                            nStrawberryCount++;
                            break;
                        }
                        break;

                    case Ingredient.Pastry_Bag:
                        Image_RecipeCheckBox[4].sprite = sprite_O;
                        break;
                }
                break;

            case Stage.Stage1_2:
                switch (objectManager.ingredient)
                {
                    case Ingredient.Crust:
                        Image_RecipeCheckBox[0].sprite = sprite_O;
                        Image_RecipeCheckBox[1].sprite = sprite_O;
                        break;

                    case Ingredient.Strawberry_Cut:
                        if (isStrawberryCut)
                        {
                            if(nStrawberryCount == 1)
                            {
                                Image_RecipeCheckBox[2].sprite = sprite_O;
                            }
                            nStrawberryCount++;
                        }
                        break;

                    case Ingredient.Blueberry:
                        if(nBlueberryCount == 0)
                        {
                            Image_RecipeCheckBox[3].sprite = sprite_O;
                        }
                        else if(nBlueberryCount == 1)
                        {
                            Image_RecipeCheckBox[4].sprite = sprite_O;
                        }
                        nBlueberryCount++;
                        break;

                    case Ingredient.ShineMuskat:
                        Image_RecipeCheckBox[5].sprite = sprite_O;
                        break;

                    case Ingredient.Pastry_Bag:
                        Image_RecipeCheckBox[6].sprite = sprite_O;
                        break;
                }
                break;

            case Stage.Stage1_3:
                switch (objectManager.ingredient)
                {
                    case Ingredient.Pastry_Bag:
                        Image_RecipeCheckBox[0].sprite = sprite_O;
                        break;

                    case Ingredient.Whipping_Bag:
                        Image_RecipeCheckBox[1].sprite = sprite_O;
                        break;

                    case Ingredient.Banana:
                        if(nBananaCount >= 1)
                        {
                            Image_RecipeCheckBox[2].sprite = sprite_O;
                        }
                        nBananaCount++;
                        break;

                    case Ingredient.Kiwi_Cut:
                        if (nKiwiCount >= 1)
                        {
                            Image_RecipeCheckBox[3].sprite = sprite_O;
                        }
                        nKiwiCount++;
                        break;

                    case Ingredient.Strawberry_Cut:
                        if (nStrawberryCount >= 1)
                        {
                            Image_RecipeCheckBox[4].sprite = sprite_O;
                        }
                        nStrawberryCount++;
                        break;

                    case Ingredient.Peach:
                        if (nPeachCount >= 1)
                        {
                            Image_RecipeCheckBox[5].sprite = sprite_O;
                        }
                        nPeachCount++;
                        break;

                    case Ingredient.Orange:
                        if (nOrangeCount >= 1)
                        {
                            Image_RecipeCheckBox[6].sprite = sprite_O;
                        }
                        nOrangeCount++;
                        break;
                }
                break;

            default:
                Debug.Log("스테이지가 정의되지 않은 오븐입니다. (이 디버그는 재료 체크박스에서 발생했습니다.)");
                break;
        }
    }

    public void AddIngredientImage(Sprite sprite_Ingredient, GameObject objIngredient)
    {
        if (sprite_Ingredient == sprite_Chocolate && !isChocolateCut)
        {
            return;
        }

        if (sprite_Ingredient == sprite_Chocolate && isAlreadyInChocolate)
        {
            objIngredient.SetActive(false);
            return;
        }

        if (stage == Stage.Stage1_1 && sprite_Ingredient == sprite_Strawberry)
        {
            return;
        }

        if(stage == Stage.Stage1_2 && sprite_Ingredient == sprite_Strawberry)
        {
            return;
        }

        if(stage == Stage.Tutorial)
        {
            if (sprite_Ingredient == sprite_Chocolate)
            {
                isAlreadyInChocolate = true;
            }
        }

        list_Material.Add(sprite_Ingredient);
        objIngredient.SetActive(false);
    }

    public void CutChocoloateTrue()
    {
        isChocolateCut = true;
    }

    public void CutStrawberryTrue()
    {
        isStrawberryCut = true;
    }

    public void CutKiwiTrue()
    {
        isKiwiCut = true;
    }
}
