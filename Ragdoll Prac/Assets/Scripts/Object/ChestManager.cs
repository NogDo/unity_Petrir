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

    [Header("외부 스크립트")]
    public TutorialManager tutorialManager;
    public OvenManager ovenManager;

    [Header("레시피 체크박스")]
    public Toggle[] toggle_RecipeCheckBox;

    private bool isEndChestTutorial;
    private bool isAlreadyInChocolate;
    private bool isChocolateCut;

    private void Start()
    {
        isEndChestTutorial = false;
        isAlreadyInChocolate = false;
        isChocolateCut = false;
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
            CheckIngredient_CheckBox(other.GetComponent<ObjectManager>());
            AddIngredientImage(other.gameObject.GetComponent<ObjectManager>().sprite_ObjectImage, other.gameObject);
        }
    }

    public List<Sprite> GetMaterialList()
    {
        return list_Material;
    }

    public void CheckIngredient_CheckBox(ObjectManager objectManager)
    {
        switch (ovenManager.stage)
        {
            case Stage.Oven:
                switch (objectManager.ingredient)
                {
                    case Ingredient.Biscuit:
                        toggle_RecipeCheckBox[0].isOn = true;
                        break;
                }
                break;

            case Stage.Tutorial:
                switch (objectManager.ingredient)
                {
                    case Ingredient.Biscuit:
                        if (toggle_RecipeCheckBox[0].isOn == false)
                        {
                            toggle_RecipeCheckBox[0].isOn = true;
                        }
                        else
                        {
                            toggle_RecipeCheckBox[1].isOn = true;
                        }
                        break;

                    case Ingredient.Marshmallow:
                        toggle_RecipeCheckBox[2].isOn = true;
                        break;

                    case Ingredient.Chocolate:
                        if (!isChocolateCut)
                        {
                            break;
                        }
                        toggle_RecipeCheckBox[3].isOn = true;
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
        

        if(ovenManager.stage == Stage.Tutorial)
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
}
