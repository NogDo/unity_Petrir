using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameObject objRecipePopupSmallTutorialGuide;
    public GameObject objRecipePopupLargeTutorialGuide;
    public GameObject objRecipePopupRingTutorialGuide;
    public GameObject objRecipePopupSmall;
    public GameObject objRecipePopupLarge;
    public GameObject objRecipePopupRing;
    public GameObject objOptionCanvas;

    public GameObject objKnifeImage;
    public GameObject objKnife;
    public AudioSource audioSource_KnifeTakeOut;

    public TutorialManager tutorialManager;

    public bool isTutorialGuide;
    public bool isOvenUIOn;
    public bool isPlateUIOn;
    public bool isQuitCanvasOn;

    private void Start()
    {
        isOvenUIOn = false;
        isPlateUIOn = false;
        isQuitCanvasOn = false;
    }

    void Update()
    {
        // 옵션창
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isOvenUIOn && !isPlateUIOn && !isQuitCanvasOn)
            {
                objOptionCanvas.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }

        // 레시피 열기
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isTutorialGuide)
            {
                if (!objRecipePopupSmallTutorialGuide.activeSelf && !objRecipePopupLargeTutorialGuide.activeSelf)
                {
                    objRecipePopupSmallTutorialGuide.SetActive(true);
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                }
                else if (objRecipePopupSmallTutorialGuide.activeSelf && !objRecipePopupLargeTutorialGuide.activeSelf)
                {
                    objRecipePopupLargeTutorialGuide.SetActive(true);
                    objRecipePopupRingTutorialGuide.SetActive(true);
                }
                else if (objRecipePopupSmallTutorialGuide.activeSelf && objRecipePopupLargeTutorialGuide.activeSelf)
                {
                    objRecipePopupSmallTutorialGuide.SetActive(false);
                    objRecipePopupLargeTutorialGuide.SetActive(false);
                    objRecipePopupRingTutorialGuide.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
            else
            {
                if (!objRecipePopupSmall.activeSelf && !objRecipePopupLarge.activeSelf)
                {
                    objRecipePopupSmall.SetActive(true);
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                }
                else if (objRecipePopupSmall.activeSelf && !objRecipePopupLarge.activeSelf)
                {
                    objRecipePopupLarge.SetActive(true);
                    objRecipePopupRing.SetActive(true);
                }
                else if (objRecipePopupSmall.activeSelf && objRecipePopupLarge.activeSelf)
                {
                    objRecipePopupSmall.SetActive(false);
                    objRecipePopupLarge.SetActive(false);
                    objRecipePopupRing.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }

        }

        // 칼 꺼내기
        if (!isOvenUIOn && !isPlateUIOn)
        {
            objKnifeImage.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                objKnifeImage.GetComponent<Image>().color = new Color(200.0f / 255.0f, 200.0f / 255.0f, 200.0f / 255.0f, 1.0f);
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                objKnifeImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                objKnife.SetActive(true);
                objKnife.GetComponent<ObjectManager>().ResetTransform();
                audioSource_KnifeTakeOut.Play();
            }
        }
        else
        {
            objKnifeImage.SetActive(false);
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

    public void OvenUIOn()
    {
        isOvenUIOn = true;
    }

    public void OvenUIOff()
    {
        isOvenUIOn = false;
    }

    public void PlateUIOn()
    {
        isPlateUIOn = true;
    }

    public void PlateUIOff()
    {
        isPlateUIOn = false;
    }

    public void QuitCanvasOn()
    {
        isQuitCanvasOn = true;
    }

    public void QuitCanvasOff()
    {
        isQuitCanvasOn = false;
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
