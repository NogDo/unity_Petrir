using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    public AudioSource audio;

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
        audio.PlayOneShot(startSound);
        yield return new WaitForSeconds(startSound.length);

        SceneManager.LoadScene("Tutorial");
    }
    
    IEnumerator EndGame(AudioClip endSound)
    {
        audio.PlayOneShot(endSound);
        yield return new WaitForSeconds(endSound.length);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
