using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameObject objRecipePopupSmallTutorialGuide;
    public GameObject objRecipePopupLargeTutorialGuide;
    public GameObject objRecipePopupSmall;
    public GameObject objRecipePopupLarge;

    public GameObject objKnifeImage;
    public GameObject objKnife;

    public TutorialManager tutorialManager;

    public bool isTutorialGuide;

    void Update()
    {
        // 레시피 열기
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isTutorialGuide)
            {
                if (!objRecipePopupSmallTutorialGuide.activeSelf && !objRecipePopupLargeTutorialGuide.activeSelf)
                {
                    objRecipePopupSmallTutorialGuide.SetActive(true);
                }
                else if (objRecipePopupSmallTutorialGuide.activeSelf && !objRecipePopupLargeTutorialGuide.activeSelf)
                {
                    objRecipePopupSmallTutorialGuide.SetActive(false);
                    objRecipePopupLargeTutorialGuide.SetActive(true);
                }
                else if (!objRecipePopupSmallTutorialGuide.activeSelf && objRecipePopupLargeTutorialGuide.activeSelf)
                {
                    objRecipePopupLargeTutorialGuide.SetActive(false);
                }
            }
            else
            {
                if (!objRecipePopupSmall.activeSelf && !objRecipePopupLarge.activeSelf)
                {
                    objRecipePopupSmall.SetActive(true);
                }
                else if (objRecipePopupSmall.activeSelf && !objRecipePopupLarge.activeSelf)
                {
                    objRecipePopupSmall.SetActive(false);
                    objRecipePopupLarge.SetActive(true);
                }
                else if (!objRecipePopupSmall.activeSelf && objRecipePopupLarge.activeSelf)
                {
                    objRecipePopupLarge.SetActive(false);
                }
            }
            
        }

        // 칼 꺼내기
        if (Input.GetKeyDown(KeyCode.F))
        {
            objKnifeImage.GetComponent<Image>().color = new Color(200.0f / 255.0f, 200.0f / 255.0f, 200.0f / 255.0f, 1.0f);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            objKnifeImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            objKnife.SetActive(true);
        }
    }

    public void SetIsTutorialGuideFalse()
    {
        isTutorialGuide = false;
    }

    public void SetKnifeImageVisible()
    {
        objKnifeImage.SetActive(true);
    }
}
