using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestManager : MonoBehaviour
{
    public List<Sprite> list_Material;

    public TutorialManager tutorialManager;
    public OvenManager ovenManager;

    public Toggle[] toggle_RecipeCheckBox;

    private bool isEndChestTutorial;

    private void Start()
    {
        isEndChestTutorial = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (tutorialManager.IsStartChestTutorial() && !isEndChestTutorial && (ovenManager.stage == Stage.Oven))
            {
                tutorialManager.EndChestTutorial();
                isEndChestTutorial = true;
            }

            other.gameObject.SetActive(false);
            CheckIngredient_CheckBox(other.GetComponent<ObjectManager>());
            list_Material.Add(other.gameObject.GetComponent<ObjectManager>().sprite_ObjectImage);
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
                        toggle_RecipeCheckBox[3].isOn = true;
                        break;
                }
                break;

            default:
                Debug.Log("스테이지가 정의되지 않은 오븐입니다. (이 디버그는 재료 체크박스에서 발생했습니다.)");
                break;
        }
    }
}
