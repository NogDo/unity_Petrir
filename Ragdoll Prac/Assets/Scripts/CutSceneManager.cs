using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CutScene
{
    Epilogue,
    Prologue
}
public class CutSceneManager : MonoBehaviour
{
    float fTime;
    float fCutSceneTime;
    bool isStart;
    bool isTutorialStart;
    int nTimeCount;

    public GameObject[] objCutSceneImage;
    public AudioSource audioSource;
    public CutScene cutScene;

    public GameObject objOverlay;
    public GameObject objCutScene;

    public UIButtonManager uIButtonManager;

    private void Start()
    {
        fCutSceneTime = 5.0f;
        isStart = false;
        isTutorialStart = false;
        nTimeCount = 2;

        if(cutScene == CutScene.Epilogue)
        {
            StartCutScene();
        }

        Cursor.visible = false;
    }
    void Update()
    {
        if (isStart)
        {
            fTime += Time.deltaTime;
            Debug.Log(fTime);

            if(fTime >= fCutSceneTime * (nTimeCount - 1) && fTime < fCutSceneTime * nTimeCount)
            {
                if(nTimeCount - 1 < objCutSceneImage.Length)
                {
                    objCutSceneImage[nTimeCount - 1].SetActive(true);
                    nTimeCount++;
                }
                else
                {
                    if(cutScene == CutScene.Epilogue && !isTutorialStart)
                    {
                        audioSource.Stop();
                        //SceneManager.LoadScene("Tutorial");
                        uIButtonManager.StartTutorialLoading();
                        isTutorialStart = true;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (cutScene == CutScene.Epilogue)
                {
                    audioSource.Stop();
                    //SceneManager.LoadScene("Tutorial");
                    uIButtonManager.StartTutorialLoading();
                }
                else if (cutScene == CutScene.Prologue)
                {
                    //audioSource.Stop();
                }
            }
        }
    }
    public void StartCutScene()
    {
        audioSource.Play();
        isStart = true;

        if(cutScene == CutScene.Prologue)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            objOverlay.SetActive(false);
            objCutScene.SetActive(true);
        }
    }

    public void EndCutScene()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        objOverlay.SetActive(true);
        objCutScene.SetActive(false);
    }
}
