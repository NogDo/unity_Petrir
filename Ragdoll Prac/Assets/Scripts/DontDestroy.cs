using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public bool isTutorialClear;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
