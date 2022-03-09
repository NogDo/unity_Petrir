using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public GameObject objRecipePopupSmallTutorialGuide;
    public GameObject objRecipePopupLargeTutorialGuide;
    public GameObject objRecipePopupSmall;
    public GameObject objRecipePopupLarge;

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
    }

    public void SetIsTutorialGuideFalse()
    {
        isTutorialGuide = false;
    }
}
