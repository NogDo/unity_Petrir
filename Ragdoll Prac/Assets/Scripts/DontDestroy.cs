using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public bool isTutorialClear;
    public bool isStage1Clear;
    public bool isStage2Clear;
    public bool isStage3Clear;
    public bool isStage4Clear;
    public bool isStage5Clear;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if(PlayerPrefs.GetInt("TutorialClear") == 1)
        {
            isTutorialClear = true;
        }

        if (PlayerPrefs.GetInt("Stage1Clear") == 1)
        {
            isStage1Clear = true;
        }

        if (PlayerPrefs.GetInt("Stage2Clear") == 1)
        {
            isStage2Clear = true;
        }
    }
}
