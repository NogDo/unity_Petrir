using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    float fTime;
    float fCutSceneTime;

    public GameObject[] objCutSceneImage;

    public AudioSource audioSource;

    private void Start()
    {
        fCutSceneTime = 5.0f;

        Cursor.visible = false;
    }

    void Update()
    {
        fTime += Time.deltaTime;
        Debug.Log(fTime);

        if (fTime >= fCutSceneTime && fTime < fCutSceneTime * 2)
        {
            objCutSceneImage[1].SetActive(true);
        }
        else if (fTime >= fCutSceneTime * 2 && fTime < fCutSceneTime * 3)
        {
            objCutSceneImage[2].SetActive(true);
        }
        else if (fTime >= fCutSceneTime * 3 && fTime < fCutSceneTime * 4)
        {
            objCutSceneImage[3].SetActive(true);
        }
        else if (fTime >= fCutSceneTime * 4 && fTime < fCutSceneTime * 5)
        {
            objCutSceneImage[4].SetActive(true);
        }
        else if (fTime >= fCutSceneTime * 5 && fTime < fCutSceneTime * 6)
        {
            objCutSceneImage[5].SetActive(true);
        }
        else if(fTime >= fCutSceneTime * 6)
        {
            SceneManager.LoadScene("Tutorial");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.Stop();
            SceneManager.LoadScene("Tutorial");
        }
    }
}
