using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [Header("외부 스크립트")]
    public PlayerController playerController;
    public CameraControl cameraControl;
    public PlayerManager playerManager;
    public GameUIManager gameUIManager;

    [Header("이미지")]
    public GameObject objTutorialGuideRecipeImage;
    public GameObject objTutorialStageRecipeImage;
    public GameObject objBottomArrowImage;
    public GameObject objBlackImage;
    public GameObject objExplainTextBoardImage;

    [Header("튜토리얼 진행관련")]
    public GameObject objTutorialCanvas;
    public GameObject objWalkTutorial;
    public GameObject objRunTutorial;
    public GameObject objJumpTutorial;
    public GameObject objGrabTutorial;

    [Header("플레이어가 이동해야할 지점 MovePoint")]
    public GameObject objMovePoint;
    public Vector3 vec3_WalkTutorialMovePoint;
    public Vector3 vec3_RunTutorialMovePoint;
    public Vector3 vec3_GrabTutorialMovePoint;

    [Header("Grab튜토리얼 이후 오브젝트(비스킷, 상자, 오븐, 튜토리얼 맵)")]
    public GameObject objGrabBiscuit;
    public GameObject objChest;
    public GameObject objOven;
    public GameObject objTutorialMap01;
    public GameObject objTutorialMap02;

    [Header("Oven 인터페이스 UI")]
    public GameObject objBakeItButton;

    [Header("튜토리얼 설명 텍스트")]
    public TextMeshProUGUI tmp_TutorialExplain;

    List<Dictionary<string, object>> list_TutorialGuide;

    private int nTutorialGuideIndex;
    private bool isExcuteOnce;
    private bool isCanEnter;
    private bool isStartJumpTutorial;
    private bool isStartGrabTutorial;
    private bool isEndGrabTutorialOnce;
    private bool isStartChestTutorial;
    private bool isStartOvenTutorial;
    private bool isStartDragTutorial;
    private bool isStartCreateTutorial;

    private void OnEnable()
    {
        UnPlayable();
        InitTutorial();

        list_TutorialGuide = CSVReader.Read("TutorialGuide");
    }

    private void Update()
    {
        if (nTutorialGuideIndex == 0)
        {
            ShowNextText();
            PressKey(KeyCode.Return);
        }
        else if (nTutorialGuideIndex == 6)
        {
            objBottomArrowImage.transform.LookAt(playerController.gameObject.transform);
        }

        if (Input.GetKeyDown(KeyCode.Return) && isCanEnter)
        {
            ShowNextText();
            Debug.Log(nTutorialGuideIndex);
            PressKey(KeyCode.Return);
        }
    }

    public void InitTutorial()
    {
        nTutorialGuideIndex = 0;
        objMovePoint.transform.localPosition = vec3_WalkTutorialMovePoint;
        isExcuteOnce = false;
        isCanEnter = true;
        isStartJumpTutorial = false;
        isStartGrabTutorial = false;
        isStartChestTutorial = false;
        isEndGrabTutorialOnce = false;
        isStartOvenTutorial = false;
        isStartDragTutorial = false;
        isStartCreateTutorial = false;
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
            if(nTutorialGuideIndex >= 23)
            {
                return;
            }
            tmp_TutorialExplain.text = list_TutorialGuide[nTutorialGuideIndex]["Content"].ToString();
            isExcuteOnce = true;
        }
    }

    public void PressKey(KeyCode keyCode1)
    {
        if (nTutorialGuideIndex == 2)
        {
            objBlackImage.SetActive(true);
            objTutorialGuideRecipeImage.SetActive(true);
            PlayDoTweenAnimation(objTutorialGuideRecipeImage);
        }

        if (nTutorialGuideIndex == 3)
        {
            KillDoTweenAnimation(objTutorialGuideRecipeImage);
            objTutorialGuideRecipeImage.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
        }

        if (nTutorialGuideIndex == 5)
        {
            objBlackImage.SetActive(false);
            objWalkTutorial.SetActive(true);
        }


        if (nTutorialGuideIndex == 7)
        {
            Playable();
            objBottomArrowImage.SetActive(true);
            objMovePoint.SetActive(true);
            objWalkTutorial.SetActive(false);
            objBlackImage.SetActive(false);
            objExplainTextBoardImage.SetActive(false);
        }

        if (nTutorialGuideIndex == 9)
        {
            Playable();
            objMovePoint.transform.localPosition = vec3_RunTutorialMovePoint;
            objBottomArrowImage.SetActive(true);
            objMovePoint.SetActive(true);
            objRunTutorial.SetActive(false);
            objExplainTextBoardImage.SetActive(false);
        }

        if (nTutorialGuideIndex == 11)
        {
            Playable();
            objJumpTutorial.SetActive(false);
            objExplainTextBoardImage.SetActive(false);
            isStartJumpTutorial = true;
        }

        if (nTutorialGuideIndex == 13)
        {
            Playable();
            objMovePoint.transform.localPosition = vec3_GrabTutorialMovePoint;
            objBottomArrowImage.SetActive(true);
            objMovePoint.SetActive(true);
            objGrabBiscuit.SetActive(true);
            objGrabTutorial.SetActive(false);
            objExplainTextBoardImage.SetActive(false);
            isStartGrabTutorial = true;
        }

        if (nTutorialGuideIndex == 15)
        {
            Playable();
            objExplainTextBoardImage.SetActive(false);
            isStartChestTutorial = true;
        }

        if (nTutorialGuideIndex == 17)
        {
            Playable();
            objExplainTextBoardImage.SetActive(false);
            isStartOvenTutorial = true;
        }

        if (nTutorialGuideIndex == 19)
        {
            isCanEnter = false;
            objExplainTextBoardImage.SetActive(false);
            isStartDragTutorial = true;
        }

        if (nTutorialGuideIndex == 21)
        {
            isCanEnter = false;
            objExplainTextBoardImage.SetActive(false);
            objBakeItButton.SetActive(true);
            isStartCreateTutorial = true;
        }

        if (nTutorialGuideIndex == 23)
        {
            isCanEnter = false;
            objOven.GetComponent<OvenManager>().CloseOvenUI();
            objExplainTextBoardImage.SetActive(false);
            objTutorialMap02.SetActive(true);
            playerManager.MoveToTutorialStage();
            gameUIManager.SetIsTutorialGuideFalse();
            objTutorialGuideRecipeImage.SetActive(false);
            objTutorialStageRecipeImage.SetActive(true);
            objTutorialMap01.SetActive(false);
            return;
        }

        nTutorialGuideIndex++;
        isExcuteOnce = false;
    }

    public void Playable()
    {
        isCanEnter = false;
        playerController.AblePlayerControl();
        cameraControl.StartScreenRotation();
    }

    public void UnPlayable()
    {
        isCanEnter = true;
        playerController.UnablePlayerControl();
        cameraControl.StopScreenRotation();
    }

    public void EndWalkTutorial()
    {
        UnPlayable();
        playerController.StopMoveAnimation();
        playerController.StopRunAnimation();
        playerController.SetSpeedZero();
        objExplainTextBoardImage.SetActive(true);
        objRunTutorial.SetActive(true);
        objBottomArrowImage.SetActive(false);
    }

    public void EndRunTutorial()
    {
        UnPlayable();
        playerController.StopMoveAnimation();
        playerController.StopRunAnimation();
        playerController.SetSpeedZero();
        objExplainTextBoardImage.SetActive(true);
        objJumpTutorial.SetActive(true);
        objBottomArrowImage.SetActive(false);
    }

    public void EndJumpTutorial()
    {
        UnPlayable();
        objExplainTextBoardImage.SetActive(true);
        objGrabTutorial.SetActive(true);
    }

    public void EndGrabTutorial()
    {
        if (!isEndGrabTutorialOnce)
        {
            UnPlayable();
            objExplainTextBoardImage.SetActive(true);
            objBottomArrowImage.SetActive(false);
            objMovePoint.SetActive(false);
            objChest.SetActive(true);
            isEndGrabTutorialOnce = true;
        }
    }

    public void EndChestTutorial()
    {
        UnPlayable();
        objExplainTextBoardImage.SetActive(true);
        objOven.SetActive(true);
    }

    public void EndOvenTutorial()
    {
        UnPlayable();
        objExplainTextBoardImage.SetActive(true);
    }

    public void EndDragTutorial()
    {
        UnPlayable();
        objExplainTextBoardImage.SetActive(true);
    }

    public void EndCreateTutorial()
    {
        UnPlayable();
        objExplainTextBoardImage.SetActive(true);
    }

    public bool IsStartJumpTutorial()
    {
        return isStartJumpTutorial;
    }

    public bool IsStartGrabTutorial()
    {
        return isStartGrabTutorial;
    }

    public bool IsStartChestTutorial()
    {
        return isStartChestTutorial;
    }

    public bool IsStartOvenTutorial()
    {
        return isStartOvenTutorial;
    }

    public bool IsStartDragTutorial()
    {
        return isStartDragTutorial;
    }

    public bool IsStartCreateTutorial()
    {
        return isStartCreateTutorial;
    }
}
