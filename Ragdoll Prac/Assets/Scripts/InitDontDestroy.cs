using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitDontDestroy : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("UI");
    }
}
