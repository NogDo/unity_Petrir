using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAerialWay : MonoBehaviour
{
    public GameObject[] objAerials;

    public int nAerialsCount;
    public bool isStartVisible;

    private void Start()
    {
        nAerialsCount = 0;
        isStartVisible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_Foot") && !isStartVisible)
        {
            StartCoroutine(SetVisibleTrueAerial());
            isStartVisible = true;
        }
    }

    IEnumerator SetVisibleTrueAerial()
    {
        objAerials[nAerialsCount].SetActive(true);
        nAerialsCount++;
        yield return new WaitForSeconds(0.1f);
        if (!(nAerialsCount >= objAerials.Length))
        {
            StartCoroutine(SetVisibleTrueAerial());
        }
        else
        {
            StartCoroutine(SetVisibleFalseAerials());
            nAerialsCount = 0;
        }
    }

    IEnumerator SetVisibleFalseAerials()
    {
        yield return new WaitForSeconds(10.0f);
        for(int i = 0; i < objAerials.Length; i++)
        {
            objAerials[i].SetActive(false);
        }
        isStartVisible = false;
    }
}
