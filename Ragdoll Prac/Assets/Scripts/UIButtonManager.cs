using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audio_StartScreen;
    public AudioSource audio_StageSelection;

    public GameObject objMain;
    public GameObject objChapter;
    public GameObject objChapter1Stage;
    public Sprite[] sprite_StageOpen;
    public Sprite[] sprite_StageLocked;

    public Texture2D texture_Cursor;

    public DontDestroy ClearCheck;

    public RandomTipManager randomTipManager;

    public GameObject[] Stage;
    public GameObject[] StageSelect;

    public bool isExhibitionFile;
    private int nIndex;

    [SerializeField]
    Image image_ProgressBar;
    public GameObject objLoading;

    private void OnEnable()
    {
        if(StageSelect[0] != null)
        {
            Cursor.SetCursor(texture_Cursor, Vector2.zero, CursorMode.ForceSoftware);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            ClearCheck = GameObject.Find("ClearCheck").GetComponent<DontDestroy>();
        }
    }

    private void Start()
    {
        if(StageSelect[0] != null)
        {
            nIndex = 0;
            for (int i = 0; i < StageSelect.Length; i++)
            {
                StageSelect[i].transform.GetChild(0).GetComponent<Image>().sprite = Stage[i].transform.GetChild(0).GetComponent<Image>().sprite;
                StageSelect[i].transform.GetChild(1).GetComponent<Image>().sprite = Stage[i].transform.GetChild(1).GetComponent<Image>().sprite;
                StageSelect[i].transform.GetChild(2).GetComponent<Image>().sprite = Stage[i].transform.GetChild(2).GetComponent<Image>().sprite;
            }
        }
    }

    public void ShowChapter()
    {
        objMain.SetActive(false);
        objChapter.SetActive(true);

        if (isExhibitionFile)
        {
            for (int i = 1; i < 5; i++)
            {
                Stage[i].transform.GetChild(1).GetComponent<Image>().sprite = sprite_StageOpen[i - 1];
            }
        }
        else
        {
            for (int i = 1; i < 5; i++)
            {
                Stage[i].transform.GetChild(1).GetComponent<Image>().sprite = sprite_StageLocked[i - 1];
            }
        }

        if (PlayerPrefs.GetInt("Stage1Clear") == 1)
        {
            Stage[0].transform.GetChild(0).gameObject.SetActive(true);
            Stage[0].transform.GetChild(2).gameObject.SetActive(true);

            Stage[1].transform.GetChild(1).GetComponent<Image>().sprite = sprite_StageOpen[0];
        }

        if (PlayerPrefs.GetInt("Stage2Clear") == 1)
        {
            Stage[1].transform.GetChild(0).gameObject.SetActive(true);
            Stage[1].transform.GetChild(2).gameObject.SetActive(true);

            Stage[2].transform.GetChild(1).GetComponent<Image>().sprite = sprite_StageOpen[1];
        }

        if (PlayerPrefs.GetInt("Stage3Clear") == 1)
        {
            Stage[2].transform.GetChild(0).gameObject.SetActive(true);
            Stage[2].transform.GetChild(2).gameObject.SetActive(true);

            Stage[3].transform.GetChild(1).GetComponent<Image>().sprite = sprite_StageOpen[2];
        }

        if (PlayerPrefs.GetInt("Stage4Clear") == 1)
        {
            Stage[3].transform.GetChild(0).gameObject.SetActive(true);
            Stage[3].transform.GetChild(2).gameObject.SetActive(true);

            Stage[4].transform.GetChild(1).GetComponent<Image>().sprite = sprite_StageOpen[3];
        }

        if (PlayerPrefs.GetInt("Stage5Clear") == 1)
        {
            Stage[4].transform.GetChild(0).gameObject.SetActive(true);
            Stage[4].transform.GetChild(2).gameObject.SetActive(true);
        }

        for (int i = 0; i < StageSelect.Length; i++)
        {
            StageSelect[i].transform.GetChild(0).GetComponent<Image>().sprite = Stage[i].transform.GetChild(0).GetComponent<Image>().sprite;
            StageSelect[i].transform.GetChild(1).GetComponent<Image>().sprite = Stage[i].transform.GetChild(1).GetComponent<Image>().sprite;
            StageSelect[i].transform.GetChild(2).GetComponent<Image>().sprite = Stage[i].transform.GetChild(2).GetComponent<Image>().sprite;
        }

        for (int i = 0; i < 3; i++)
        {
            if (Stage[i].transform.GetChild(0).gameObject.activeSelf)
            {
                StageSelect[i].transform.GetChild(0).gameObject.SetActive(true);
                StageSelect[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                StageSelect[i].transform.GetChild(0).gameObject.SetActive(false);
                StageSelect[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void QuitGame(AudioClip clickSound)
    {
        StartCoroutine(EndGame(clickSound));
    }

    IEnumerator EndGame(AudioClip clickSound)
    {
        audioSource.PlayOneShot(clickSound);
        yield return new WaitForSeconds(clickSound.length);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void StartTutorial()
    {
        if (ClearCheck.isTutorialClear)
        {
            audio_StartScreen.Stop();
            audio_StageSelection.Play();
            ShowChapter();
        }
        else
        {
            SceneManager.LoadScene("CutScene");
        }
    }

    public void SkipTutorial()
    {
        ClearCheck.isTutorialClear = true;
        PlayerPrefs.SetInt("TutorialClear", 1);

        StartTutorial();
    }

    public void PlayTutorial()
    {
        ClearCheck.isTutorialClear = false;

        StartTutorial();
    }

    public void StartTutorialLoading()
    {
        Debug.Log("튜토리얼 로딩");
        randomTipManager.RandomTutorialTip();
        StartCoroutine(LoadScenePrecess("Tutorial"));
    }

    public void StartStage01()
    {
        randomTipManager.RandomTip();
        StartCoroutine(LoadScenePrecess("1"));
    }

    public void StartStage02()
    {
        randomTipManager.RandomStage2Tip();
        StartCoroutine(LoadScenePrecess("2"));
    }

    public void StartStage03()
    {
        randomTipManager.RandomTip();
        StartCoroutine(LoadScenePrecess("3"));
    }

    public void StartStage04()
    {
        randomTipManager.RandomStage4Tip();
        StartCoroutine(LoadScenePrecess("4"));
    }

    public void StartStage05()
    {
        randomTipManager.RandomTip();
        StartCoroutine(LoadScenePrecess("5"));
    }

    public void SelectStage(int nStageCount)
    {
        nStageCount += nIndex;

        switch (nStageCount)
        {
            case 1:
                StartStage01();
                break;

            case 2:
                if(Stage[1].transform.GetChild(1).GetComponent<Image>().sprite == sprite_StageOpen[0])
                {
                    StartStage02();
                }
                break;

            case 3:
                if (Stage[2].transform.GetChild(1).GetComponent<Image>().sprite == sprite_StageOpen[1])
                {
                    StartStage03();
                }
                break;

            case 4:
                if (Stage[3].transform.GetChild(1).GetComponent<Image>().sprite == sprite_StageOpen[2])
                {
                    StartStage04();
                }
                break;

            case 5:
                if (Stage[4].transform.GetChild(1).GetComponent<Image>().sprite == sprite_StageOpen[3])
                {
                    StartStage05();
                }
                break;

            default:
                Debug.Log("스테이지 카운트 오류");
                break;
        }
    }

    IEnumerator LoadScenePrecess(string sceneName)
    {
        objLoading.SetActive(true);
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            if(op.progress < 0.5f)
            {
                image_ProgressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                Debug.Log(timer);
                image_ProgressBar.fillAmount = Mathf.Lerp(0.1f, 1.0f, timer / 10.0f);
                if (image_ProgressBar.fillAmount >= 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    public void PressLeftArrow()
    {
        if (nIndex <= 0)
        {
            return;
        }

        nIndex--;
        for (int i = 0; i < 3; i++)
        {
            StageSelect[i].transform.GetChild(0).GetComponent<Image>().sprite = Stage[i + nIndex].transform.GetChild(0).GetComponent<Image>().sprite;
            StageSelect[i].transform.GetChild(1).GetComponent<Image>().sprite = Stage[i + nIndex].transform.GetChild(1).GetComponent<Image>().sprite;
            StageSelect[i].transform.GetChild(2).GetComponent<Image>().sprite = Stage[i + nIndex].transform.GetChild(2).GetComponent<Image>().sprite;
        }

        for (int i = 0; i < 3; i++)
        {
            if (Stage[i + nIndex].transform.GetChild(0).gameObject.activeSelf)
            {
                StageSelect[i].transform.GetChild(0).gameObject.SetActive(true);
                StageSelect[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                StageSelect[i].transform.GetChild(0).gameObject.SetActive(false);
                StageSelect[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void PressRightArrow()
    {
        if (nIndex >= 2)
        {
            return;
        }

        nIndex++;
        for (int i = 0; i < 3; i++)
        {
            StageSelect[i].transform.GetChild(0).GetComponent<Image>().sprite = Stage[i + nIndex].transform.GetChild(0).GetComponent<Image>().sprite;
            StageSelect[i].transform.GetChild(1).GetComponent<Image>().sprite = Stage[i + nIndex].transform.GetChild(1).GetComponent<Image>().sprite;
            StageSelect[i].transform.GetChild(2).GetComponent<Image>().sprite = Stage[i + nIndex].transform.GetChild(2).GetComponent<Image>().sprite;
        }

        for (int i = 0; i < 3; i++)
        {
            if (Stage[i + nIndex].transform.GetChild(0).gameObject.activeSelf)
            {
                StageSelect[i].transform.GetChild(0).gameObject.SetActive(true);
                StageSelect[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                StageSelect[i].transform.GetChild(0).gameObject.SetActive(false);
                StageSelect[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }
}
