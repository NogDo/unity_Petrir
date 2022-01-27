using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialManager : MonoBehaviour
{
    public PlayerController playerController;
    public CameraControl cameraControl;

    public GameObject objRecipeImage;
    public GameObject objTutorialCanvas;

    public Text text_TutorialExplain;

    List<Dictionary<string, object>> list_TutorialGuide;

    private int nTutorialGuideIndex;
    private bool isExcuteOnce;

    private void OnEnable()
    {
        playerController.UnablePlayerControl();
        cameraControl.StopScreenRotation();
        InitTutorial();

        list_TutorialGuide = CSVReader.Read("TutorialGuide");
    }

    private void Update()
    {
        switch (nTutorialGuideIndex)
        {
            case 0:
                ShowNextText();
                PressKey(KeyCode.Space);
                break;

            case 1:
                ShowNextText();
                PressKey(KeyCode.Space);
                break;

            case 2:
                ShowNextText();
                PressKey(KeyCode.R);
                break;

            case 3:
                ShowNextText();
                PressKey(KeyCode.R);
                break;

            case 4:
                ShowNextText();
                PressKey(KeyCode.R);
                break;

            case 5:
                ShowNextText();
                PressKey(KeyCode.Space);
                break;

            case 6:
                ShowNextText();
                PressKey(KeyCode.Space);
                break;

            case 7:
                ShowNextText();
                PressKey(KeyCode.W);
                break;
        }
    }

    public void InitTutorial()
    {
        nTutorialGuideIndex = 0;
        isExcuteOnce = false;
    }

    public int GetTutorialGuideIndex()
    {
        return nTutorialGuideIndex;
    }

    public void KillDoTweenAnimation(GameObject objKillAnimation)
    {
        objKillAnimation.GetComponent<DOTweenAnimation>().DOKill();
    }

    public void PlayDoTweenAnimation(GameObject objPlayAnimation)
    {
        objPlayAnimation.GetComponent<DOTweenAnimation>().DOPlay();
    }

    public void ShowNextText()
    {
        if (!isExcuteOnce)
        {
            text_TutorialExplain.text = list_TutorialGuide[nTutorialGuideIndex]["Content"].ToString();
            isExcuteOnce = true;
        }
    }

    public void PressKey(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
            if(nTutorialGuideIndex == 1)
            {
                PlayDoTweenAnimation(objRecipeImage);
            }

            if(nTutorialGuideIndex == 2)
            {
                KillDoTweenAnimation(objRecipeImage);
                objRecipeImage.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
            }

            if(nTutorialGuideIndex == 6)
            {

            }
            nTutorialGuideIndex++;
            isExcuteOnce = false;
        }
    }
}
