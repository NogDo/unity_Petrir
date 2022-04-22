using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isPause = false;

    public Texture2D texture_Cursor;

    public DontDestroy TutorialClearCheck;

    private void Start()
    {
        Cursor.SetCursor(texture_Cursor, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = false;

        TutorialClearCheck = GameObject.Find("TutorialClearCheck").GetComponent<DontDestroy>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (isPause)
            {
                Time.timeScale = 1;
                isPause = false;
            }
            else
            {
                Time.timeScale = 0;
                isPause = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene("UI");
        }
    }

    public void TutorialStageClear()
    {
        SceneManager.LoadScene("UI");
        TutorialClearCheck.isTutorialClear = true;
    }

    public void Chapter1_Stage1Clear()
    {
        SceneManager.LoadScene("UI");
    }
}
