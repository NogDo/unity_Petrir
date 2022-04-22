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
    public GameObject objChapter2Stage;
    public GameObject objChapter3Stage;

    public Texture2D texture_Cursor;

    public DontDestroy TutorialClearCheck;

    private void OnEnable()
    {
        Cursor.SetCursor(texture_Cursor, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        TutorialClearCheck = GameObject.Find("TutorialClearCheck").GetComponent<DontDestroy>();
    }

    public void ShowChapter()
    {
        objMain.SetActive(false);
        objChapter.SetActive(true);
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
        if (TutorialClearCheck.isTutorialClear)
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

    public void StartStage01()
    {
        SceneManager.LoadScene("1-1");
    }

    public void StartStage02()
    {

    }

    public void StartStage03()
    {

    }
}
