using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    public AudioSource audioSource;

    public void GameStart(AudioClip startSound)
    {
        StartCoroutine(StartGame(startSound));
    }

    public void QuitGame(AudioClip endSound)
    {
        StartCoroutine(EndGame(endSound));
    }

    IEnumerator StartGame(AudioClip startSound)
    {
        audioSource.PlayOneShot(startSound);
        yield return new WaitForSeconds(startSound.length);

        SceneManager.LoadScene("Tutorial");
    }
    
    IEnumerator EndGame(AudioClip endSound)
    {
        audioSource.PlayOneShot(endSound);
        yield return new WaitForSeconds(endSound.length);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
