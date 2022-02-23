using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isPause = false;

    public Texture2D texture_Cursor;

    private void Start()
    {
        Cursor.SetCursor(texture_Cursor, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = false;
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
    }
}
