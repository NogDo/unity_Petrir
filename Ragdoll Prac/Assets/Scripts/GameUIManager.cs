using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public GameObject objRecipePopupSmall;
    public GameObject objRecipePopupLarge;

    public TutorialManager tutorialManager;

    void Update()
    {
        // 레시피 열기
        if(tutorialManager.GetTutorialGuideIndex() >= 2)
        {
            if (Input.GetKeyDown(KeyCode.R))
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
}
