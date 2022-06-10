﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isPause = false;

    public Texture2D texture_Cursor;

    public DontDestroy ClearCheck;

    private void Start()
    {
        Cursor.SetCursor(texture_Cursor, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = false;

        ClearCheck = GameObject.Find("ClearCheck").GetComponent<DontDestroy>();
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

        if (Input.GetKeyDown(KeyCode.F4))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void TutorialStageClear()
    {
        SceneManager.LoadScene("UI");
        ClearCheck.isTutorialClear = true;
        PlayerPrefs.SetInt("TutorialClear", 1);
    }

    public void Stage1Clear()
    {
        SceneManager.LoadScene("UI");
        ClearCheck.isStage1Clear = true;
        PlayerPrefs.SetInt("Stage1Clear", 1);
    }

    public void Stage2Clear()
    {
        SceneManager.LoadScene("UI");
        ClearCheck.isStage2Clear = true;
        PlayerPrefs.SetInt("Stage2Clear", 1);
    }

}
