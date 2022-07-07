using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSequence : MonoBehaviour
{
    public GameObject[] objSequence;
    public GameObject[] objCreateFloor;

    public int nSequenceCount;
    public int nCreateFloorCount;

    public bool isEndSequence;

    private void Start()
    {
        nSequenceCount = 0;
        nCreateFloorCount = 0;

        isEndSequence = false;
    }

    public void CheckSequence(GameObject sequence)
    {
        if(objSequence[nSequenceCount] == sequence && !isEndSequence)
        {
            objSequence[nSequenceCount].GetComponent<MeshRenderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f);
            objSequence[nSequenceCount].transform.GetChild(0).GetComponent<ColorSequenceButton>().Checked();

            nSequenceCount++;
            if(nSequenceCount >= objSequence.Length)
            {
                StartCoroutine(VisibleCreateFloor());
                isEndSequence = true;
            }
        }
        else
        {
            for(int i = 0; i < objSequence.Length; i++)
            {
                objSequence[i].GetComponent<MeshRenderer>().material.color = Color.white;
                objSequence[i].transform.GetChild(0).GetComponent<ColorSequenceButton>().ResetChecked();
            }

            nSequenceCount = 0;
        }
    }

    public IEnumerator VisibleCreateFloor()
    {
        objCreateFloor[nCreateFloorCount].SetActive(true);
        nCreateFloorCount++;
        yield return new WaitForSeconds(0.5f);
        if(nCreateFloorCount < objCreateFloor.Length)
        {
            StartCoroutine(VisibleCreateFloor());
        }
    }
}
