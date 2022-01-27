using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    public AudioSource audioSource;

    public GameObject objMain;
    public GameObject objStage;

    public void GameStart()
    {
        objMain.SetActive(false);
        objStage.SetActive(true);
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
        SceneManager.LoadScene("Tutorial");
    }

    public void StartStage01()
    {

    }

    public void StartStage02()
    {

    }

    public void StartStage03()
    {

    }
}
